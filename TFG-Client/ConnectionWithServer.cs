////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\ConnectionWithServer.cs </file>
///
/// <copyright file="ConnectionWithServer.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase ConnectionWithServer.\n
///             Implements the connection with server class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gestiona todo el flujo de datos cliente-servidor.\n
    ///             Manages the entire client-server data flow. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ConnectionWithServer {

        private static MainFormProgram loginForm;
        private static Panel loadPanel;
        private static string encryptKey;
        private static string ivString;
        private static string jsonGetKey;
        private static string jsonLoginData;
        private static string emailUser;
        private static string nameOfUser;
        private static NetworkStream serverStream;
        private static bool readServerData = true;
        private static bool checkNewQuestion = false;
        private static Button loginButton;
        private static MyOwnCircleComponent userImage;
        private static TcpClient clientSocket;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicia el hilo del formulario recibido como parámetro.\n
        ///             Runs the given login form parameter. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <exception cref="Exception">    Lanza una excepción cuando se produce un error.\n
        ///                                 Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="loginFormParam">   Formulario del login del programa.\n
        ///                                 The login form parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void run(MainFormProgram loginFormParam) {

            LoginForm = loginFormParam;

            // Reseteo de variable en caso de login fallido
            readServerData = true;

            increaseLoadingBar();
            try {
                clientSocket = new TcpClient();
                clientSocket.Connect("178.62.40.25", 12345);
                increaseLoadingBar();

                serverStream = clientSocket.GetStream();
                increaseLoadingBar();

                // Antes debe hacer una petición para obtener la clave de encriptación
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(JsonGetKey);

                serverStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                serverStream.Flush();

                // Recibo de datos

                byte[] buffer = new byte[1024];
                int recv = clientSocket.Client.Receive(buffer);
                string serverMessage = Encoding.ASCII.GetString(buffer, 0, recv);

                JSonObjectArray answerServer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessage);

                // Recibo y almacenamiento de clave para encriptado de datos
                if (answerServer.A_Title.Equals("key")) {
                    EncryptKey = answerServer.B_Content[0];
                    IvString = answerServer.B_Content[1];
                    // Debe usar la clave recibida para cifrar los datos del usuario y enviarlos

                    byte[] byteArrayLoginData = Encoding.ASCII.GetBytes(Utilities.Encrypt(JsonLoginData, EncryptKey, IvString));

                    serverStream.Write(byteArrayLoginData, 0, byteArrayLoginData.Length);
                    // Envio de datos mediante flush
                    serverStream.Flush();

                    // Conexión con el servidor establecida
                    MainFormProgram.checkConnectionWithServer = true;
                    while (ReadServerData) {

                        buffer = new byte[120024];
                        recv = clientSocket.Client.Receive(buffer);
                        serverMessage = Encoding.ASCII.GetString(buffer, 0, recv);

                        string serverMessageDesencrypt = Utilities.Decrypt(serverMessage, IvString, EncryptKey);

                        if (serverMessageDesencrypt == "") {
                            // Conexión con el servidor perdida, cierre de app y vuelta a login

                            // Cierre de todos los formularios pop-up abiertos
                            closeAllPopUps();

                            Utilities.customErrorInfo("Error, el servidor se cerró inesperadamente");
                            resetLoadingBar();
                            MainFormProgram.checkConnectionWithServer = false;
                            readServerData = false;
                            loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                            resetAllDataConnection();
                        } else {
                            // Conversión del mensaje recibido a Json para poder leer el título
                            // Con esto sabemos que formato va a tener el mensaje recibido
                            JObject json = JObject.Parse(serverMessageDesencrypt);


                            if (json.First.ToString().Contains("loginStatus")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                if (singleAnswer.B_Content.Equals("correct")) {
                                    // Pasaria a la ventana del programa principal
                                    // Peticion de nombre del usuario al servidor
                                    string getNameJson = Utilities.generateSingleDataRequest("getNameOfMail", emailUser);
                                    if (getNameJson == "") {
                                        throw new Exception("Error, valor vacío detectado");
                                    }
                                    byte[] byteArrayNameData = Encoding.ASCII.GetBytes(Utilities.Encrypt(getNameJson, EncryptKey, IvString));

                                    serverStream.Write(byteArrayNameData, 0, byteArrayNameData.Length);
                                    // Envio de datos mediante flush
                                    serverStream.Flush();

                                } else if (singleAnswer.B_Content.Equals("incorrect")) {
                                    resetLoadingBar();
                                    // Mensaje de error de datos invalidos en el login
                                    Utilities.customErrorInfo("Datos de login incorrectos");
                                    loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                                }
                            } else if (json.First.ToString().Contains("connectionStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);

                                if (singleAnswer.B_Content.Equals("closedForTimeOut")) {
                                    resetLoadingBar();
                                    // Debe borrar ventana de usuario y volver a mostrar la de login
                                    Utilities.customErrorInfo("Su tiempo de inactividad ha alcanzado el límite,\n se ha desconectado del servidor");
                                    resetLoadingBar();
                                    MainFormProgram.checkConnectionWithServer = false;
                                    readServerData = false;

                                    loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                                    resetAllDataConnection();

                                }
                            } else if (json.First.ToString().Contains("userNameData")) {

                                // Tras login correcto, se ha pedido el nombre de usuario al servidor
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                nameOfUser = singleAnswer.B_Content;

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.Visible = false; }));

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.createUserPanel(nameOfUser, emailUser); }));

                            } else if (json.First.ToString().Contains("allSubjects")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allSubjects = complexAnswer.B_Content;
                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.UserControlPanelObject.fillAllSubjects(allSubjects); }));

                            } else if (json.First.ToString().Contains("allThemesNames")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allThemesNames = complexAnswer.B_Content;
                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.fillAllThemes(allThemesNames); }));

                            } else if (json.First.ToString().Contains("allNamesFromSpecificSubject")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allThemesNames = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.SelectSubjectFormObject.fillAllThemes(allThemesNames); }));

                            } else if (json.First.ToString().Contains("allNamesModelsFromSpecificSubject")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allThemesNames = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.SelectSubjectFormModelsObject.fillAllThemes(allThemesNames); }));

                            } else if (json.First.ToString().Contains("allThemesForTest")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allThemesNames = complexAnswer.B_Content;
                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionTypeTest.fillAllThemes(allThemesNames); }));

                            } else if (json.First.ToString().Contains("checkIfThemeExist")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {

                                    checkNewQuestion = false;
                                } else {
                                    checkNewQuestion = true;
                                }
                            } else if (json.First.ToString().Contains("checkIfQuestionExist")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un una pregunta con este nombre, pruebe con otro nombre \n" +
                                                              " o contante con el administrador del sistema");
                                } else {
                                    if (checkNewQuestion) {
                                        // petición de agregación de nueva pregunta
                                        LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.addNewQuestionRequest(); }));
                                    } else {
                                        Utilities.customErrorInfo("El nombre de la pregunta es valido, pero  el tema \n " +
                                                                  "que está intentando crear ya existe, pruebe con otro nombre \n" +
                                                                  "o contante con el andministrador");
                                    }
                                }

                            } else if (json.First.ToString().Contains("checkTestQuestion")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un una pregunta con este nombre, pruebe con otro nombre \n" +
                                                              " o contante con el administrador del sistema");
                                } else {
                                    if (checkNewQuestion) {
                                        // petición de agregación de nueva pregunta
                                        LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionTypeTest.addNewQuestionRequest(); }));
                                    } else {
                                        Utilities.customErrorInfo("El nombre de la pregunta es valido, pero  el tema \n " +
                                                                  "que está intentando crear ya existe, pruebe con otro nombre \n" +
                                                                  "o contante con el andministrador");
                                    }
                                }

                            } else if (json.First.ToString().Contains("insertNewTestStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionTypeTest.addDataOfNewQuestionRequest(false); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar el tema al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("insertNewThemeStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.addDataOfNewQuestionRequest(false); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar el tema al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("insertNewTestQuestion")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionTypeTest.openSuccessAddQuestionForm(); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar la pregunta al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("insertNewQuestionStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.openSuccessAddQuestionForm(); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar la pregunta al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("checkIfQuestionSelectedTheme")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un una pregunta con este nombre, pruebe con otro nombre \n" +
                                                              " o contante con el administrador del sistema");
                                } else {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.addDataOfNewQuestionRequest(true); }));
                                }

                            } else if (json.First.ToString().Contains("checkTestIfQuestionSelectedTheme")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un una pregunta con este nombre, pruebe con otro nombre \n" +
                                                              " o contante con el administrador del sistema");
                                } else {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionTypeTest.addDataOfNewQuestionRequest(true); }));
                                }

                            } else if (json.First.ToString().Contains("normalQuestionsNotFound")) {

                                // No se han encontrado preguntas normales de las asignatura
                                LoginForm.Invoke(new MethodInvoker(delegate { loginForm.ListAllNormalQuestions.hide_show_dataGridView(false); }));

                            } else if (json.First.ToString().Contains("normalForModificationQuestionsNotFound")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { loginForm.ListAllNormalQuestionsModificationsObject.hide_show_dataGridView(false); }));

                            } else if (json.First.ToString().Contains("allNormalForModificationQuestions")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.ListAllNormalQuestionsModificationsObject.hide_show_dataGridView(true);
                                    string[] allQuestions = complexAnswer.B_Content;
                                    loginForm.ListAllNormalQuestionsModificationsObject.fillDataGridView(allQuestions);
                                }));

                            } else if (json.First.ToString().Contains("TestForModificationQuestionsNotFound")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { loginForm.ListAllTestQuestionsModificationsObject.hide_show_dataGridView(false); }));

                            } else if (json.First.ToString().Contains("allTestForModificationQuestions")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.ListAllTestQuestionsModificationsObject.hide_show_dataGridView(true);
                                    string[] allQuestions = complexAnswer.B_Content;
                                    loginForm.ListAllTestQuestionsModificationsObject.fillDataGridView(allQuestions);
                                }));

                            } else if (json.First.ToString().Contains("allNormalQuestionsSpecificSubject")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allQuestions = complexAnswer.B_Content;
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.ListAllNormalQuestions.fillDataGridView(allQuestions);
                                    loginForm.ListAllNormalQuestions.hide_show_dataGridView(true);
                                }));

                            } else if (json.First.ToString().Contains("insertNewNormalModification")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Petición de modificación enviada correctamente
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.ListAllNormalQuestions.openSuccessAddModificationNormalQuest(); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar la modicación al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("TestQuestionsNotFound")) {

                                // No se han encontrado preguntas de tipo test de las asignatura
                                LoginForm.Invoke(new MethodInvoker(delegate { loginForm.ListAllTestQuestions.hide_show_dataGridView(false); }));

                            } else if (json.First.ToString().Contains("allTestQuestionsSpecificSubject")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allTestQuestions = complexAnswer.B_Content;
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.ListAllTestQuestions.fillDataGridView(allTestQuestions);
                                    loginForm.ListAllTestQuestions.hide_show_dataGridView(true);
                                }));

                            } else if (json.First.ToString().Contains("insertNewModificationTest")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Petición de modificación enviada correctamente
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.ListAllTestQuestions.openSuccessAddModificationNormalQuest(); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar la modicación al sistema, contacte con el administrador");
                                }

                            } else if (json.First.ToString().Contains("normalQuestionsCreateExamNotFound")) {

                                // Error de preguntas no encontradas
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.CreateNormalExamObject.showHideElements(false);
                                    loginForm.CreateNormalExamObject.showHideLabelWait(false);
                                    loginForm.CreateNormalExamObject.showHideErrorMessage(true);
                                    loginForm.CreateNormalExamObject.showHideBackButton(true);
                                }));

                            } else if (json.First.ToString().Contains("allNormalCreateExamQuestions")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allQuestions = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.CreateNormalExamObject.fillDataGridView(allQuestions);
                                    loginForm.CreateNormalExamObject.showHideElements(true);
                                    loginForm.CreateNormalExamObject.showHideLabelWait(false);
                                    loginForm.CreateNormalExamObject.showHideErrorMessage(false);
                                    loginForm.CreateNormalExamObject.showHideErrorMessage(true);
                                }));

                            } else if (json.First.ToString().Contains("testQuestionsCreateExamNotFound")) {

                                // Error de preguntas no encontradas
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.CreateTestExamObject1.showHideElements(false);
                                    loginForm.CreateTestExamObject1.showHideLabelWait(false);
                                    loginForm.CreateTestExamObject1.showHideErrorMessage(true);
                                    loginForm.CreateTestExamObject1.showHideBackButton(true);
                                }));

                            } else if (json.First.ToString().Contains("allTestCreateExamQuestions")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] allQuestions = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    loginForm.CreateTestExamObject1.fillDataGridView(allQuestions);
                                    loginForm.CreateTestExamObject1.showHideElements(true);
                                    loginForm.CreateTestExamObject1.showHideLabelWait(false);
                                    loginForm.CreateTestExamObject1.showHideErrorMessage(false);
                                    loginForm.CreateTestExamObject1.showHideBackButton(true);
                                }));

                            } else if (json.First.ToString().Contains("checkNormalNameModelExist")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un modelo con este nombre, pruebe otro");
                                } else {
                                    // Petición de creación del modelo
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataNormalModelObject.createNormalModelRequest(); }));
                                }

                            } else if (json.First.ToString().Contains("checkTestNameModelExist")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Ya existe un modelo con este nombre, pruebe otro");
                                } else {
                                    // Petición de creación del modelo
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataTestModel.createTestModelRequest(); }));
                                }

                            } else if (json.First.ToString().Contains("createNormalModel")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "0") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Hubo un error al intentar guardar el modelo solicitado");
                                } else {
                                    // Petición de creación del examen normal
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataNormalModelObject.generateExamRequest(serverAnswer); }));
                                }

                            } else if (json.First.ToString().Contains("createTestModel")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "0") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    Utilities.customErrorInfo("Hubo un error al intentar guardar el modelo solicitado");
                                } else {
                                    // Petición de creación del examen normal
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataTestModel.generateExamRequest(serverAnswer); }));
                                }

                            } else if (json.First.ToString().Contains("updateNormalQuestionNewModelStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Petición de generación de examen con el listado de preguntas
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataNormalModelObject.generateFilesExam(); }));
                                } else {
                                    // Petición de creación del modelo
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataNormalModelObject.generateErrorMessage(); }));
                                }

                            } else if (json.First.ToString().Contains("updateTestQuestionNewModelStatus")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Petición de generación de examen con el listado de preguntas
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataTestModel.generateFilesExam(); }));
                                } else {
                                    // Petición de creación del modelo
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AllDataTestModel.generateErrorMessage(); }));
                                }

                            } else if (json.First.ToString().Contains("normalExamCreatedSucces")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.CreateNormalExamObject.normalExamGenerateSuccess(); }));

                            } else if (json.First.ToString().Contains("normalModelExamCreated")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.FormNormalModelToUse.normalExamGenerateSuccess(); }));

                            } else if (json.First.ToString().Contains("testModelExamCreated")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.FormNormalModelToUse.testExamGenerateSuccess(); }));

                            } else if (json.First.ToString().Contains("TestExamCreatedSucces")) {

                                LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.CreateTestExamObject1.testExamGenerateSuccess(); }));

                            } else if (json.First.ToString().Contains("allNormalDataModels")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] alldataNormalModels = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    if (alldataNormalModels.Length == 0) {
                                        loginForm.SelectNormalModelObject.showNothingMessage();
                                    } else {
                                        loginForm.SelectNormalModelObject.createAndShowModels(alldataNormalModels);
                                    }
                                }));

                            } else if (json.First.ToString().Contains("allTestDataModels")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] alldataNormalModels = complexAnswer.B_Content;
                                Thread.Sleep(2000);
                                LoginForm.Invoke(new MethodInvoker(delegate {
                                    if (alldataNormalModels.Length == 0) {
                                        loginForm.SelectNormalModelObject.showNothingMessage();
                                    } else {
                                        loginForm.SelectNormalModelObject.createAndShowModels(alldataNormalModels);
                                    }
                                }));

                            } else if (json.First.ToString().Contains("allNormalModelQuestionsList")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] alldataNormalQuestionsOfModel = complexAnswer.B_Content;
                                loginForm.SelectNormalModelObject.Invoke(new MethodInvoker(delegate {
                                    loginForm.SelectNormalModelObject.createPopUpMessage(alldataNormalQuestionsOfModel);
                                }));

                            } else if (json.First.ToString().Contains("allTestModelQuestionsList")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] alldataTestQuestionsOfModel = complexAnswer.B_Content;
                                loginForm.SelectNormalModelObject.Invoke(new MethodInvoker(delegate {
                                    loginForm.SelectNormalModelObject.createPopUpMessage(alldataTestQuestionsOfModel);
                                }));

                            } else if (json.First.ToString().Contains("allTestModifications")) {

                                JSonObjectArray complexAnswer = JsonConvert.DeserializeObject<JSonObjectArray>(serverMessageDesencrypt);
                                string[] alldataTestQuestionsOfModifications = complexAnswer.B_Content;
                                loginForm.ListAllTestQuestionsModificationsObject.Invoke(new MethodInvoker(delegate {
                                    loginForm.ListAllTestQuestionsModificationsObject.openPopUpWithModifications(alldataTestQuestionsOfModifications);
                                }));

                            } else if (json.First.ToString().Contains("statusPermissionsOfChanges")) {

                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string singleAnswerContent = singleAnswer.B_Content;
                                Thread.Sleep(3000);

                                if (singleAnswerContent.Equals("withOutPermissions")) {
                                    loginForm.AskTypeDataChangesObject1.Invoke(new MethodInvoker(delegate {
                                        LoginForm.UserControlPanelObject.labelChanges.Click += new EventHandler(LoginForm.UserControlPanelObject.labelChanges_Click);
                                        loginForm.AskTypeDataChangesObject1.createErrorCredentials();
                                    }));

                                } else {
                                    loginForm.AskTypeDataChangesObject1.Invoke(new MethodInvoker(delegate {
                                        LoginForm.UserControlPanelObject.labelChanges.Click += new EventHandler(LoginForm.UserControlPanelObject.labelChanges_Click);
                                        loginForm.AskTypeDataChangesObject1.showHideElements(true);
                                    }));
                                }
                            }
                        }
                    }
                } else {
                    resetLoadingBar();
                    Utilities.customErrorInfo("No se pudo obtener la clave de conexión con el servidor, intentelo más tarde");
                }
            } catch (Exception ex) {
                resetLoadingBar();
                MainFormProgram.checkConnectionWithServer = false;
                readServerData = false;
                loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 500, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto FormNormalModelToUse.\n
        ///             Sets form normal model to use. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="formNormalModelToUseObject">   Formulario a almacenar.\n
        ///                                             The form normal model to use object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setFormNormalModelToUse(FormNormalModelToUse formNormalModelToUseObject) {
            loginForm.FormNormalModelToUse = formNormalModelToUseObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto AddNewQuestion.\n
        ///             Sets new question from. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="addNewQuestion">   Formulario a almacenar.\n
        ///                                 The add new question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setNewQuestionFrom(AddNewQuestion addNewQuestion) {
            loginForm.AddNewQuestionObject = addNewQuestion;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto AllDataNormalModel.\n
        ///             Sets all data normal model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="allDataNormalModelObject"> Formulario a almacenar.\n
        ///                                         all data normal model object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setAllDataNormalModel(AllDataNormalModel allDataNormalModelObject) {
            loginForm.AllDataNormalModelObject = allDataNormalModelObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto AllDataTestModel.\n
        ///             Sets all data test model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="allDataTestModelObject">   Formulario a almacenar.\n
        ///                                         all data test model object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setAllDataTestModel(AllDataTestModel allDataTestModelObject) {
            LoginForm.AllDataTestModel = allDataTestModelObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto CreateNormalExam.\n
        ///             Sets create normal exam. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="createNormalExam"> Formulario a almacenar.\n
        ///                                 The create normal exam. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setCreateNormalExam(CreateNormalExam createNormalExam) {
            loginForm.CreateNormalExamObject = createNormalExam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto CreateTestExam.\n
        ///             Sets create test exam. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="createTestExam">   Formulario a almacenar.\n
        ///                                 The create test exam. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setCreateTestExam(CreateTestExam createTestExam) {
            loginForm.CreateTestExamObject1 = createTestExam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto SelectSubjectForm.\n
        ///             Sets selected s ubject form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="selectSubjectFormParam">   Formulario a almacenar.\n
        ///                                         The select subject form parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setSelectedSUbjectForm(SelectSubjectForm selectSubjectFormParam) {
            loginForm.SelectSubjectFormObject = selectSubjectFormParam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto AddNewQuestionTypeTest.\n
        ///             Sets new question form test type. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="addNewQuestionTypeObject"> Formulario a almacenar.\n
        ///                                         The add new question type object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setNewQuestionFormTestType(AddNewQuestionTypeTest addNewQuestionTypeObject) {
            loginForm.AddNewQuestionTypeTest = addNewQuestionTypeObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto SelectSubjecteFormModels.\n
        ///             Sets new select subject form models. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="selectSubjectFormModelsObject">    Formulario a almacenar.\n
        ///                                                 The select subject form models object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setNewSelectSubjectFormModels(SelectSubjectFormModels selectSubjectFormModelsObject) {
            loginForm.SelectSubjectFormModelsObject = selectSubjectFormModelsObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece el objeto SelectNormalModel.\n
        ///             Sets new select normal model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="selectNormalModelObject">  Formulario a almacenar.\n
        ///                                         The select normal model object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void setNewSelectNormalModel(SelectNormalModel selectNormalModelObject) {
            loginForm.SelectNormalModelObject = selectNormalModelObject;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Cierra todas las ventanas pop-up que tenga el sistema abierto.\n
        ///             Closes all pop ups. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void closeAllPopUps() {
            try {
                loginForm.Invoke(new MethodInvoker(delegate {
                    if (loginForm.FormNewNormalModification != null) {
                        loginForm.FormNewNormalModification.Dispose();
                    }
                    if (loginForm.ModelWindowsMessage != null) {
                        loginForm.ModelWindowsMessage.Dispose();
                    }
                    if (loginForm.ModelWindowsMessageWithBroder != null) {
                        loginForm.ModelWindowsMessageWithBroder.Dispose();
                    }
                    if (loginForm.ModelWindowsMessageWithBroderWarning != null) {
                        loginForm.ModelWindowsMessageWithBroderWarning.Dispose();
                    }
                    if (loginForm.FormNewTestModification != null) {
                        loginForm.FormNewTestModification.Dispose();
                    }
                    if (loginForm.FormNormalModelToUse != null) {
                        loginForm.FormNormalModelToUse.Dispose();
                    }
                    if (LoginForm.FormNewNormalModificationForModel != null) {
                        loginForm.FormNewNormalModificationForModel.Dispose();
                    }
                    if (LoginForm.FormTestModifications != null) {
                        loginForm.FormTestModifications.Dispose();
                    }
                    if (LoginForm.FormNewTestModificationAddOrDelete != null) {
                        loginForm.FormNewTestModificationAddOrDelete.Dispose();
                    }
                }));
            } catch (Exception ex) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Incrementa la barra de carga del login.\n
        ///             Increase loading bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void increaseLoadingBar() {
            try {
                LoadPanel.Invoke(new Action(() => {
                    LoadPanel.Width += 50;
                }));
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 402, LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Resetea la barra de carga del login.\n
        ///             Resets the loading bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void resetLoadingBar() {
            try {
                MainFormProgram.tConnection = null;

                LoadPanel.Invoke(new Action(() => {
                    LoadPanel.Visible = false;
                    LoadPanel.Width = 50;
                }));
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 403, LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Resetea todas las variables de la conexión con el servidor.\n
        ///             Reset all connection variables to default. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void resetAllDataConnection() {
            if (LoginForm.UserControlPanelObject != null) {
                LoginForm.Invoke(new MethodInvoker(delegate {
                    LoginForm.UserControlPanelObject.Visible = false;
                    LoginForm.Visible = true;
                }));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto ServerStream.\n
        ///             Gets or sets the server stream. </summary>
        ///
        /// <value> Objeto ServerStream.\n
        ///         The server stream. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static NetworkStream ServerStream { get => serverStream; set => serverStream = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto LoadPanel.\n
        ///             Gets or sets the load panel.</summary>
        ///
        /// <value> Objeto LoadPanel.\n
        ///         The load panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Panel LoadPanel { get => loadPanel; set => loadPanel = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto EncryptKey.\n
        ///             Gets or sets the EncryptKey.</summary>
        ///
        /// <value> Objeto EncryptKey.\n
        ///         The EncryptKey. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string EncryptKey { get => encryptKey; set => encryptKey = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto IvString.\n
        ///             Gets or sets the IvString.</summary>
        ///
        /// <value> Objeto IvString.\n
        ///         The IvString. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string IvString { get => ivString; set => ivString = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto JsonGetKey.\n
        ///             Gets or sets the JsonGetKey.</summary>
        ///
        /// <value> Objeto JsonGetKey.\n
        ///         The JsonGetKey. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string JsonGetKey { get => jsonGetKey; set => jsonGetKey = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto JsonLoginData.\n
        ///             Gets or sets the JsonLoginData.</summary>
        ///
        /// <value> Objeto JsonLoginData.\n
        ///         The JsonLoginData. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string JsonLoginData { get => jsonLoginData; set => jsonLoginData = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto ReadServerData.\n
        ///             Gets or sets the ReadServerData.</summary>
        ///
        /// <value> Objeto ReadServerData.\n
        ///         The ReadServerData. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool ReadServerData { get => readServerData; set => readServerData = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto LoginButton.\n
        ///             Gets or sets the LoginButton.</summary>
        ///
        /// <value> Objeto LoginButton.\n
        ///         The LoginButton. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Button LoginButton { get => loginButton; set => loginButton = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto EmailUser.\n
        ///             Gets or sets the EmailUser.</summary>
        ///
        /// <value> Objeto EmailUser.\n
        ///         The EmailUser. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string EmailUser { get => emailUser; set => emailUser = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto UserImage.\n
        ///             Gets or sets the UserImage.</summary>
        ///
        /// <value> Objeto UserImage.\n
        ///         The UserImage. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static MyOwnCircleComponent UserImage { get => userImage; set => userImage = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto NameOfUser.\n
        ///             Gets or sets the NameOfUser.</summary>
        ///
        /// <value> Objeto NameOfUser.\n
        ///         The NameOfUser. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string NameOfUser { get => nameOfUser; set => nameOfUser = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del objeto LoginForm.\n
        ///             Gets or sets the LoginForm.</summary>
        ///
        /// <value> Objeto LoginForm.\n
        ///         The LoginForm. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MainFormProgram LoginForm { get => loginForm; set => loginForm = value; }
    }
}

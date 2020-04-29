//============================================================================
// Name        : ConnectionWithServer.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : Connect with the server and send/receive data
//               through JSon encrypted objects
//============================================================================

///
/// Todos los using de la clase
/// 
/// All using of the class
///
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
    /// <summary>
    /// Connecta con el servidor y permite enviar y recibir datos del mismo en forma de objetos JSon encriptados
    /// 
    /// Connect with the server and allow to send/receive data.
    /// </summary>
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

        /// <summary>
        /// Constructor del objeto conexión
        /// 
        /// Constructor of connection object
        /// </summary>
        /// <param name="loadPanelParam">Panel, barra de carga que será avanzará según la conexión con el servidor se establezca</param>
        /// <param name="loadPanelParam">Panel, load bar that change when the connection progress</param>
        /// <param name="jSonObjectParam">string, objeto JSon convertido a string para enviarselo al servidor</param>
        /// <param name="jSonObjectParam">string, JSon object converted to string for to sernd to server</param>

        /// <summary>
        /// Run del hilo conexión
        /// 
        /// Run thread connection
        /// </summary>
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

                    // AQUI
                    // Debe usar la clave recibida para cifrar los datos del usuario y enviarlos
                    // Envio de datos

                    // Array de datos del cliente encriptados
                    //MessageBox.Show(encryptKey);
                    //MessageBox.Show(ivString);

                    byte[] byteArrayLoginData = Encoding.ASCII.GetBytes(Utilities.Encrypt(JsonLoginData, EncryptKey, IvString));

                    serverStream.Write(byteArrayLoginData, 0, byteArrayLoginData.Length);
                    // Envio de datos mediante flush
                    serverStream.Flush();

                    // Conexión con el servidor establecida
                    MainFormProgram.checkConnectionWithServer = true;
                    while (ReadServerData) {

                        buffer = new byte[1024];
                        recv = clientSocket.Client.Receive(buffer);
                        serverMessage = Encoding.ASCII.GetString(buffer, 0, recv);

                        string serverMessageDesencrypt = Utilities.Decrypt(serverMessage, IvString, EncryptKey);


                        if (serverMessageDesencrypt == "") {
                            // Conexión con el servidor perdida, cierre de app y vuelta a login
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

                            } else if (json.First.ToString().Contains("checkIfThemeExist")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    // Mensaje de error, se encontró un tema con el mismo nombre
                                    //Utilities.customErrorInfo("Ya existe un tema con este nombre, pruebe con otro nombre \n" +
                                    //                          " o contante con el administrador del sistema");
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
                            } else if (json.First.ToString().Contains("insertNewThemeStatus")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                string serverAnswer = singleAnswer.B_Content;
                                if (serverAnswer == "true") {
                                    LoginForm.Invoke(new MethodInvoker(delegate { LoginForm.AddNewQuestionObject.addDataOfNewQuestionRequest(false); }));
                                } else {
                                    // Carga formulario de error de insercción de los datos
                                    Utilities.customErrorInfo("Hubo un error al intentar agregar el tema al sistema, contacte con el administrador");
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

        internal static void setNewQuestionFrom(AddNewQuestion addNewQuestion) {
            loginForm.AddNewQuestionObject = addNewQuestion;
        }




        /// <summary>
        /// Incrementa la barra de carga del formulario del login
        /// 
        /// Increment loading bar in login screen
        /// </summary>
        private static void increaseLoadingBar() {
            try {
                LoadPanel.Invoke(new Action(() => {
                    LoadPanel.Width += 50;
                }));
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 402, LoginForm);
            }
        }

        /// <summary>
        /// Resetea la barra de carga del login
        /// 
        /// Reset loading bar in login screen
        /// </summary>
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

        private static void resetAllDataConnection() {
            if (LoginForm.UserControlPanelObject != null) {
                LoginForm.Invoke(new MethodInvoker(delegate {
                    LoginForm.UserControlPanelObject.Visible = false;
                    LoginForm.Visible = true;
                }));
            }
        }

        // Gets y sets
        public static NetworkStream ServerStream { get => serverStream; set => serverStream = value; }
        public static Panel LoadPanel { get => loadPanel; set => loadPanel = value; }
        public static string EncryptKey { get => encryptKey; set => encryptKey = value; }
        public static string IvString { get => ivString; set => ivString = value; }
        public static string JsonGetKey { get => jsonGetKey; set => jsonGetKey = value; }
        public static string JsonLoginData { get => jsonLoginData; set => jsonLoginData = value; }
        public static bool ReadServerData { get => readServerData; set => readServerData = value; }
        public static Button LoginButton { get => loginButton; set => loginButton = value; }
        public static string EmailUser { get => emailUser; set => emailUser = value; }
        internal static MyOwnCircleComponent UserImage { get => userImage; set => userImage = value; }
        public static string NameOfUser { get => nameOfUser; set => nameOfUser = value; }
        public static MainFormProgram LoginForm { get => loginForm; set => loginForm = value; }
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\MainFormProgram.cs </file>
///
/// <copyright file="MainFormProgram.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase MainFormProgram.\n
///             Implements the main form program class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Formulario principal de la App.\n
    ///             Main form. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class MainFormProgram : Form {
        private bool clickMouse = false;
        private Point startPoint = new Point(0, 0);
        private string[] charsToRemove = new string[] { ",", ";", "'", '"'.ToString() };
        public static Thread tConnection;
        public static bool checkConnectionWithServer = false;
        private MainFormProgram loginForm;
        private static UserControlPanel userControlPanelObject;
        private static AddNewQuestion addNewQuestionObject;
        private static SelectSubjectForm selectSubjectFormObject;
        private static CreateNormalExam createNormalExamObject;
        private static CreateTestExam CreateTestExamObject;
        private static AllDataNormalModel allDataNormalModelObject;
        private static AllDataTestModel allDataTestModel;
        private static SelectSubjectFormModels selectSubjectFormModelsObject;
        private static SelectNormalModel selectNormalModelObject;

        private static AddNewQuestionTypeTest addNewQuestionTypeTest;
        private static ListAllNormalQuestions listAllNormalQuestions;
        private static ListAllTestQuestions listAllTestQuestions;
        private static FormNewNormalModification formNewNormalModification;
        private static FormNewTestModification formNewTestModification;
        private static FormNormalModelToUse formNormalModelToUse;
        private static ModelWindowsMessage modelWindowsMessage;
        private static ModelWindowsMessageWithBroder modelWindowsMessageWithBroder;
        private static ModelWindowsMessageWithBroderWarning modelWindowsMessageWithBroderWarning;
        private static FormNewNormalModificationForModel formNewNormalModificationForModel;
        private static FormNewTestModificationForModel formNewTestModificationForModel;
        private static AskTypeDataChanges AskTypeDataChangesObject;
        private static ListAllNormalQuestionsModifications listAllNormalQuestionsModificationsObject;
        private static ListAllTestQuestionsModifications listAllTestQuestionsModificationsObject;
        private static FormNewNormalModificationAddOrDelete FormNewNormalModificationAddOrDelete;
        private static FormTestModifications formTestModifications;
        private static FormNewTestModificationAddOrDelete formNewTestModificationAddOrDelete;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainFormProgram() {
            try {
                InitializeComponent();
                loginForm = this;
                Utilities.checkWindowsFormPositon(loginForm);
                ActiveControl = titleLabel;
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 404, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera el evento <see cref="E:System.Windows.Forms.Form.FormClosed" />.\n
        ///             Generate the event <see cref="E:System.Windows.Forms.Form.FormClosed" />.
        ///             </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <exception cref="Exception">    Se lanza cuando ocurre una excepción.\n
        ///                                 Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="e">
        /// Objeto <see cref="T:System.Windows.Forms.FormClosedEventArgs" /> que contiene los datos del
        /// evento.\n
        ///  Object <see cref="T:System.Windows.Forms.FormClosedEventArgs" /> that contain all data of the event.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnFormClosed(FormClosedEventArgs e) {
            try {
                if (checkConnectionWithServer) {
                    string jsonMessage = Utilities.generateSingleDataRequest("client_disconnect");
                    if (jsonMessage == "") {
                        throw new Exception("Error, valor vacío detectado");
                    }
                    byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessage, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                    ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                    // Envio de datos mediante flush
                    ConnectionWithServer.ServerStream.Flush();
                }
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 501, null);
            }

            base.OnFormClosed(e);
            Utilities.saveWindowsFormPosition(loginForm);
            if (UserControlPanelObject != null) {
                Utilities.saveWindowsFormPosition(UserControlPanelObject);
            }
            Application.Exit();
        }

        /// <summary>
        /// Constantes en la API de Windows:
        /// 0x84 = WM_NCHITTEST - Prueba de captura del raton
        /// 0x1 = HTCLIENT      - Área del cliente de la aplicación
        /// 0x2 = HTCAPTION     - Barra de título de la aplicación
        /// 
        /// Esta función intercepta todos los comandos enviados a la aplicación, verificando si
        /// el mensaje enviado en un click del mouse y pasando dicha acción a la barra de título,
        /// permitiendo así la funcionalidad de arrastrar y soltar.
        /// 
        /// Constants in Windows API:
        /// 0x84 = WM_NCHITTEST - Mouse Capture Test
        /// 0x1 = HTCLIENT      - Application Client Area
        /// 0x2 = HTCAPTION     - Application Title Bar
        /// 
        /// This function intercepts all the commands sent to the application.
        /// It checks to see of the message is a mouse click in the application. 
        /// It passes the action to the base action by default. It reassigns
        /// the action to the title bar if it occured in the client area
        /// to allow the drag and move behavior.
        /// </summary>
        /// <param name="m">Message, referencia del comando enviado</param>
        /// <param name="m">Message, reference about sent command</param>
        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de carga del formulario.\n
        ///             Load event of the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFormProgram_Load(object sender, EventArgs e) {
            try {
                layoutOptions.Visible = false;
                if (!Utilities.CheckForInternetConnection()) {
                    // Mensaje de error por no tener conexión a internet
                    Utilities.customErrorInfo("No tiene conexión a internet, no se pudo cargar el programa");
                    Application.Exit();
                    // Cierre de la App
                }
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 404, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la barra de opciones, si ya está visible, la esconde, en caso contrario, la muestra.\n
        ///             Click event about options bar, if this bar is visible, hide, in the opposite case, show. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void optionsIcon_Click(object sender, EventArgs e) {
            if (layoutOptions.Visible) {
                layoutOptions.Visible = false;
            } else {
                layoutOptions.Visible = true;
                layoutOptions.Focus();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la imagen de salir, cierra el formulario.\n
        ///             Click event about exit image, close this form and the program. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitImage_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click para cerrar el formulario y la aplicación.\n
        ///             Click event to close this form and close the App </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitLabel_Click_1(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click para cerrar el formulario y la aplicación.\n
        ///             Click event to close this form and close the App </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutExit_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click para minimizar el formulario. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void minimizeLabel_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click para minimizar el formulario. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox9_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click para minimizar el formulario. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutMinimize_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que permite mover el formulario al hacer click sobre el y arrrastrarlo.\n
        ///             Event to allow drag and drop the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información sobre el evento de Mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e) {
            clickMouse = true;
            startPoint = new Point(e.X, e.Y);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que permite mover el formulario al hacer click sobre el y arrrastrarlo.\n
        ///             Event to allow drag and drop the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información sobre el evento de Mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {
            if (clickMouse) {
                Point newLocation = PointToScreen(e.Location);
                Location = new Point(newLocation.X - startPoint.X, newLocation.Y - startPoint.Y);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que permite saber cuando el botón del ratón ha sido levantado.\n
        ///             Event to know when the user leave the button of the mouse. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información sobre el evento de Mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e) {
            clickMouse = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de perdida de foco para esconder las opciones del menú.\n
        ///             Focus lost event to hide menu options. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutOptions_Leave(object sender, EventArgs e) {
            layoutOptions.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta cuando el usuario hace click sobre la caja de texto para introducir el usuario.\n
        ///             Detect when user does click into email text box. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxUser_Enter(object sender, EventArgs e) {
            if (textBoxUser.Text == "Correo") {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta cuando la caja de texto del usuario pierde el foco, si la caja está vacía, resetea sus valores.\n
        ///             Detect when user text box lost the focus and, if this box is empty, reset his values. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxUser_Leave(object sender, EventArgs e) {
            if (textBoxUser.Text == "") {
                textBoxUser.Text = "Correo";
                textBoxUser.ForeColor = Color.DarkGray;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta cuando el usuario hace click sobre la caja de texto para introducir la contraseña, en caso de dejarla vacía, resetea sus valores.\n
        ///             Detect whe user click into password text box for to introduce the password, in the case of the user set this text box empty, reset his values. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxPasswd_Enter(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "Contraseña") {
                textBoxPasswd.Text = "";
                textBoxPasswd.ForeColor = Color.Black;
                textBoxPasswd.UseSystemPasswordChar = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta cuando la caja de la contraseña pierde el foco, si está vacía, la resetea.\n
        ///             Detect when password text box lost focus, if this box is empty, reset his values. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxPasswd_Leave(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "") {
                textBoxPasswd.Text = "Contraseña";
                textBoxPasswd.ForeColor = Color.DarkGray;
                textBoxPasswd.UseSystemPasswordChar = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la imagen del usuario, permite al usuario elegir una imagen para cargarla, la redimensiona adecuadamanete
        ///             y verifica su posición, en caso de estar errónea, la gira automaticamente.\n
        ///             Click event about user image, when the user press the image, the user can select a image to load, this methos resize this image and rotate the image
        ///             if is necessary. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void userImage_Click(object sender, EventArgs e) {
            try {
                if (tConnection == null) {
                    if (layoutOptions.Visible) {
                        layoutOptions.Visible = false;
                    }

                    OpenFileDialog fileDialogObject = new OpenFileDialog();
                    fileDialogObject.Filter = "Image Files(*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";

                    if (fileDialogObject.ShowDialog() == DialogResult.OK) {
                        try {
                            Bitmap userSelectedImage = new Bitmap(fileDialogObject.FileName);
                            Utilities.GetOrientation((Image)userSelectedImage).ToString();
                            userImage.Image = Utilities.FixedSize(userSelectedImage, 320, 320, true);
                        } catch (Exception exImage) {
                            Utilities.createErrorMessage(exImage.Message.ToString(), Utilities.showDevelopMessages, 405, null);
                        }
                    }
                }
            } catch (Exception exOpenFile) {
                Utilities.createErrorMessage(exOpenFile.Message.ToString(), Utilities.showDevelopMessages, 600, loginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón de login.\n
        ///             Click event about login button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <exception cref="Exception">    Lanza una excepción cuando un error ocurre.\n
        ///                                 Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void loginButton_Click(object sender, EventArgs e) {
            try {
                // Desactivación del botón hasta que finaliza proceso de login
                loginButton.Enabled = false;
                /**
                 * Pasa el control activo a la barra de título para que no se quede el botón de login marcado
                 * 
                 * Transers ActiveControl to titleBar for to the login button don't show clicked status
                 */
                ActiveControl = titleLabel;

                if (Utilities.CheckForInternetConnection()) {
                    // Tiene internet
                    // Have internet connection
                    loadInternalPanel.Visible = true;
                    loadInternalPanel.Width += 50;

                    if (textBoxUser.Text.Trim().Length == 0 || textBoxPasswd.Text.Trim().Length == 0 || (textBoxUser.Text.Trim() == "Correo" || textBoxPasswd.Text.Trim() == "Contraseña")) {
                        // Error de valores inválidos
                        // Error, invalid login data
                        loadInternalPanel.Visible = false;
                        loadInternalPanel.Width = 50;
                        loginButton.Enabled = true;
                        Utilities.customErrorInfo("Valores de login incorrectos");
                    } else {
                        /**
                         * Crea un objeto JSon con los datos del login, lo encripta y lo evía al servidor.
                         * La conexión con el servidor es un objeto de tipo hilo.
                         * 
                         * Create JSon object with login data, after encrypt these datas and send to server.
                         * Conection with the server is a thread object.
                         */


                        // Limpieza de caracteres extraños

                        string userData = textBoxUser.Text.Trim();
                        string userPasswdData = textBoxPasswd.Text.Trim();

                        foreach (string c in charsToRemove) {
                            userData = userData.Replace(c, string.Empty);
                            userPasswdData = userPasswdData.Replace(c, string.Empty);
                        }

                        loadInternalPanel.Width += 50;
                        //JSonObject foo = new JSonObject();

                        //foo.Content = new string[] {textBoxUser.Text.Trim(), textBoxPasswd.Text.Trim()};
                        //foo.Title = "Connect";

                        string jsonStringKey = Utilities.generateSingleDataRequest("GetPasswd");
                        if (jsonStringKey == "") {
                            throw new Exception("Error, valor vacío detectado");
                        }
                        string jsonStringUserData = Utilities.generateJsonObjectArrayString("loginCredentials", new string[] { userData, userPasswdData });
                        if (jsonStringUserData == "") {
                            throw new Exception("Error, valor vacío detectado");
                        }
                        ConnectionWithServer.LoadPanel = loadInternalPanel;
                        ConnectionWithServer.JsonGetKey = jsonStringKey;
                        ConnectionWithServer.JsonLoginData = jsonStringUserData;
                        ConnectionWithServer.EmailUser = userData;
                        ConnectionWithServer.UserImage = userImage;
                        ConnectionWithServer.LoginButton = loginButton;

                        loadInternalPanel.Width += 50;
                        if (checkConnectionWithServer) {
                            // Ya se ha realizado la conexión, se intenta iniciar sesión
                            byte[] byteArrayLoginData = Encoding.ASCII.GetBytes(Utilities.Encrypt(ConnectionWithServer.JsonLoginData, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

                            ConnectionWithServer.ServerStream.Write(byteArrayLoginData, 0, byteArrayLoginData.Length);
                            // Envio de datos mediante flush
                            ConnectionWithServer.ServerStream.Flush();
                        } else {
                            /**
                             * Primer intento de inicio de sesión, se crea la conexión inicial como hilo para lectura de datos
                             * del servidor
                             */
                            //tConnection = new Thread(new ThreadStart(ConnectionWithServer.run));
                            tConnection = new Thread(() => ConnectionWithServer.run(loginForm));
                            tConnection.IsBackground = true;
                            tConnection.Start();
                        }
                    }

                } else {
                    // Carga ventana de error de conexión
                    // Load error window
                    loadInternalPanel.Visible = false;
                    loadInternalPanel.Width = 50;
                }
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 502, loginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que detecta cuando el usuario presiona la tecla ENTER, si es presionada, simula una pulsación al botón de login.\n
        ///             Event to detect when user press ENTER key, if this key is pressed, simulate press login button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información de la tecla presionada.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                loginButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que detecta cuando el usuario presiona la tecla ENTER, si es presionada, simula una pulsación al botón de login.\n
        ///             Event to detect when user press ENTER key, if this key is pressed, simulate press login button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información de la tecla presionada.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxPasswd_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                loginButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Acerca de...' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Acerca de...' option, it this case, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutAbout_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Acerca de...' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Acerca de...' option, it this case, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void aboutLabel_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Acerca de...' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Acerca de...' option, it this case, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void aboutIcon_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Soporte' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Soporte' option, it this case, show Support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void layoutSupport_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Soporte' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Soporte' option, it this case, show Support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void supportLabel_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario ha hecho click sobre la opción 'Soporte' y muestra el formulario correspondiente.\n
        ///             Detect if the user click in 'Soporte' option, it this case, show Support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="sender">   Objecto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void supportIcon_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Permite crear el panel del usuario.\n
        ///             Allow to create user panel. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="nameOfUserParam">  Nombre del usuario.\n
        ///                                 Name of the user parameter. </param>
        /// <param name="emailUserParam">   Correo del usuario.\n
        ///                                 The email user parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void createUserPanel(string nameOfUserParam, string emailUserParam) {
            UserControlPanelObject = new UserControlPanel(nameOfUserParam, emailUserParam, userImage);
            UserControlPanelObject.Show();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  UserControlPanel.\n
        ///             Get and set about UserControlPanel</summary>
        ///
        /// <value> Objeto UserControlPanel.\n
        ///         UserControlPanel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserControlPanel UserControlPanelObject { get => userControlPanelObject; set => userControlPanelObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  AddNewQuestion.\n
        ///             Get and set about AddNewQuestion</summary>
        ///
        /// <value> Objeto AddNewQuestion.\n
        ///         AddNewQuestion object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AddNewQuestion AddNewQuestionObject { get => addNewQuestionObject; set => addNewQuestionObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  AddNewQuestionTypeTest.\n
        ///             Get and set about AddNewQuestionTypeTest</summary>
        ///
        /// <value> Objeto AddNewQuestionTypeTest.\n
        ///         AddNewQuestionTypeTest object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AddNewQuestionTypeTest AddNewQuestionTypeTest { get => addNewQuestionTypeTest; set => addNewQuestionTypeTest = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ListAllNormalQuestions.\n
        ///             Get and set about ListAllNormalQuestions</summary>
        ///
        /// <value> Objeto ListAllNormalQuestions.\n
        ///         ListAllNormalQuestions object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListAllNormalQuestions ListAllNormalQuestions { get => listAllNormalQuestions; set => listAllNormalQuestions = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ListAllTestQuestions.\n
        ///             Get and set about ListAllTestQuestions</summary>
        ///
        /// <value> Objeto ListAllTestQuestions.\n
        ///         ListAllTestQuestions object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListAllTestQuestions ListAllTestQuestions { get => listAllTestQuestions; set => listAllTestQuestions = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewNormalModification.\n
        ///             Get and set about FormNewNormalModification</summary>
        ///
        /// <value> Objeto FormNewNormalModification.\n
        ///         FormNewNormalModification object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModification FormNewNormalModification { get => formNewNormalModification; set => formNewNormalModification = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ModelWindowsMessage.\n
        ///             Get and set about ModelWindowsMessage</summary>
        ///
        /// <value> Objeto ModelWindowsMessage.\n
        ///         ModelWindowsMessage object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessage ModelWindowsMessage { get => modelWindowsMessage; set => modelWindowsMessage = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ModelWindowsMessageWithBroder.\n
        ///             Get and set about ModelWindowsMessageWithBroder</summary>
        ///
        /// <value> Objeto ModelWindowsMessageWithBroder.\n
        ///         ModelWindowsMessageWithBroder object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessageWithBroder ModelWindowsMessageWithBroder { get => modelWindowsMessageWithBroder; set => modelWindowsMessageWithBroder = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ModelWindowsMessageWithBroderWarning.\n
        ///             Get and set about ModelWindowsMessageWithBroderWarning</summary>
        ///
        /// <value> Objeto ModelWindowsMessageWithBroderWarning.\n
        ///         ModelWindowsMessageWithBroderWarning object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessageWithBroderWarning ModelWindowsMessageWithBroderWarning { get => modelWindowsMessageWithBroderWarning; set => modelWindowsMessageWithBroderWarning = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewTestModification.\n
        ///             Get and set about FormNewTestModification</summary>
        ///
        /// <value> Objeto FormNewTestModification.\n
        ///         FormNewTestModification object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewTestModification FormNewTestModification { get => formNewTestModification; set => formNewTestModification = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  SelectSubjectForm.\n
        ///             Get and set about SelectSubjectForm</summary>
        ///
        /// <value> Objeto SelectSubjectForm.\n
        ///         SelectSubjectForm object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SelectSubjectForm SelectSubjectFormObject { get => selectSubjectFormObject; set => selectSubjectFormObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  CreateNormalExam.\n
        ///             Get and set about CreateNormalExam</summary>
        ///
        /// <value> Objeto CreateNormalExam.\n
        ///         CreateNormalExam object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CreateNormalExam CreateNormalExamObject { get => createNormalExamObject; set => createNormalExamObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  AllDataNormalModel.\n
        ///             Get and set about AllDataNormalModel</summary>
        ///
        /// <value> Objeto AllDataNormalModel.\n
        ///         AllDataNormalModel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AllDataNormalModel AllDataNormalModelObject { get => allDataNormalModelObject; set => allDataNormalModelObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  CreateTestExam.\n
        ///             Get and set about CreateTestExam</summary>
        ///
        /// <value> Objeto CreateTestExam.\n
        ///         CreateTestExam object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CreateTestExam CreateTestExamObject1 { get => CreateTestExamObject; set => CreateTestExamObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  AllDataTestModel.\n
        ///             Get and set about AllDataTestModel</summary>
        ///
        /// <value> Objeto AllDataTestModel.\n
        ///         AllDataTestModel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AllDataTestModel AllDataTestModel { get => allDataTestModel; set => allDataTestModel = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  SelectSubjectFormModels.\n
        ///             Get and set about SelectSubjectFormModels</summary>
        ///
        /// <value> Objeto SelectSubjectFormModels.\n
        ///         SelectSubjectFormModels object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SelectSubjectFormModels SelectSubjectFormModelsObject { get => selectSubjectFormModelsObject; set => selectSubjectFormModelsObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  SelectNormalModel.\n
        ///             Get and set about SelectNormalModel</summary>
        ///
        /// <value> Objeto SelectNormalModel.\n
        ///         SelectNormalModel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SelectNormalModel SelectNormalModelObject { get => selectNormalModelObject; set => selectNormalModelObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNormalModelToUse.\n
        ///             Get and set about FormNormalModelToUse</summary>
        ///
        /// <value> Objeto FormNormalModelToUse.\n
        ///         FormNormalModelToUse object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNormalModelToUse FormNormalModelToUse { get => formNormalModelToUse; set => formNormalModelToUse = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewNormalModificationForModel.\n
        ///             Get and set about FormNewNormalModificationForModel</summary>
        ///
        /// <value> Objeto FormNewNormalModificationForModel.\n
        ///         FormNewNormalModificationForModel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModificationForModel FormNewNormalModificationForModel { get => formNewNormalModificationForModel; set => formNewNormalModificationForModel = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewTestModificationForModel.\n
        ///             Get and set about FormNewTestModificationForModel</summary>
        ///
        /// <value> Objeto FormNewTestModificationForModel.\n
        ///         FormNewTestModificationForModel object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewTestModificationForModel FormNewTestModificationForModel { get => formNewTestModificationForModel; set => formNewTestModificationForModel = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  AskTypeDataChanges.\n
        ///             Get and set about AskTypeDataChanges</summary>
        ///
        /// <value> Objeto AskTypeDataChanges.\n
        ///         AskTypeDataChanges object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AskTypeDataChanges AskTypeDataChangesObject1 { get => AskTypeDataChangesObject; set => AskTypeDataChangesObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ListAllNormalQuestionsModifications.\n
        ///             Get and set about ListAllNormalQuestionsModifications</summary>
        ///
        /// <value> Objeto ListAllNormalQuestionsModifications.\n
        ///         ListAllNormalQuestionsModifications object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListAllNormalQuestionsModifications ListAllNormalQuestionsModificationsObject { get => listAllNormalQuestionsModificationsObject; set => listAllNormalQuestionsModificationsObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewNormalModificationAddOrDelete.\n
        ///             Get and set about FormNewNormalModificationAddOrDelete</summary>
        ///
        /// <value> Objeto FormNewNormalModificationAddOrDelete.\n
        ///         FormNewNormalModificationAddOrDelete object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModificationAddOrDelete FormNewNormalModificationAddOrDelete1 { get => FormNewNormalModificationAddOrDelete; set => FormNewNormalModificationAddOrDelete = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  ListAllTestQuestionsModifications.\n
        ///             Get and set about ListAllTestQuestionsModifications</summary>
        ///
        /// <value> Objeto ListAllTestQuestionsModifications.\n
        ///         ListAllTestQuestionsModifications object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListAllTestQuestionsModifications ListAllTestQuestionsModificationsObject { get => listAllTestQuestionsModificationsObject; set => listAllTestQuestionsModificationsObject = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormTestModifications.\n
        ///             Get and set about FormTestModifications</summary>
        ///
        /// <value> Objeto FormTestModifications.\n
        ///         FormTestModifications object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormTestModifications FormTestModifications { get => formTestModifications; set => formTestModifications = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set de  FormNewTestModificationAddOrDelete.\n
        ///             Get and set about FormNewTestModificationAddOrDelete</summary>
        ///
        /// <value> Objeto FormNewTestModificationAddOrDelete.\n
        ///         FormNewTestModificationAddOrDeleted object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewTestModificationAddOrDelete FormNewTestModificationAddOrDelete { get => formNewTestModificationAddOrDelete; set => formNewTestModificationAddOrDelete = value; }
    }
}

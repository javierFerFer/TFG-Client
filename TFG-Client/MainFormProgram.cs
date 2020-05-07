//============================================================================
// Name        : MainFormProgram.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : Login screen of the program
//               Connect with the server and create connection object
//============================================================================

///
/// Todos los using de la clase
/// 
/// All using of the class
///
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
    /// <summary>
    /// 
    /// Formulario de inicio de sesión
    /// 
    /// FALTA:
    /// - Clase para la encriptación de la comunicación
    /// - Al hacer click en el botón login, petición al servidor para obtener clave pública y encriptar con ella
    /// - Agregar los #region
    /// 
    /// Login form
    /// </summary>
    public partial class MainFormProgram : Form {
        private bool clickMouse = false;
        private Point startPoint = new Point(0, 0);
        private string [] charsToRemove = new string[] { ",", ";", "'", '"'.ToString() };
        public static Thread tConnection;
        public static bool checkConnectionWithServer = false;
        private MainFormProgram loginForm;
        private static UserControlPanel userControlPanelObject;
        private static AddNewQuestion addNewQuestionObject;
        private static SelectSubjectForm selectSubjectFormObject;
        private static CreateNormalExam createNormalExamObject;
        private static AllDataNormalModel allDataNormalModelObject;

        private static AddNewQuestionTypeTest addNewQuestionTypeTest;
        private static ListAllNormalQuestions listAllNormalQuestions;
        private static ListAllTestQuestions listAllTestQuestions;
        private static FormNewNormalModification formNewNormalModification;
        private static FormNewTestModification formNewTestModification;
        private static ModelWindowsMessage modelWindowsMessage;
        private static ModelWindowsMessageWithBroder modelWindowsMessageWithBroder;
        private static ModelWindowsMessageWithBroderWarning modelWindowsMessageWithBroderWarning;
        /// <summary>
        /// 
        /// Constructor de la clase
        /// 
        /// Constructor of the class
        /// </summary>
        public MainFormProgram() {
            try {
                InitializeComponent();
                loginForm = this;
                Utilities.checkWindowsFormPositon(loginForm);
                /**
                 * Se usa para que el textbox de usuario no establezca el foco.
                 * 
                 * This is for to remove focus of the user textBox.
                 */
                ActiveControl = titleLabel;
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 404, null);
            }
        }

        

        /// <summary>
        /// Evento de cierre sobreescrito para que, antes de cerrar el formulario, almacene la posición del mismo en el registro de windows
        /// 
        /// Closed login form event override, in this case, the program before close, save the position into windows registry.
        /// </summary>
        /// <param name="e">FormClosedEventArgs, evento de cierre recibido como parámetro</param>
        /// <param name="e">FormClosedEventArgs, closed event received as parameter</param>
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

        /// <summary>
        /// Evento de carga del formulario, oculta la barra de opciones al cargar el formulario.
        /// 
        /// Load event of login form, hide options bar when this form load.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
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

        /// <summary>
        /// Evento de click sobre la barra de opciones, si ya estaba visible, la esconde, en caso contrario la muestra
        /// 
        /// Click event about options bar, if this bar is visible, set invisible, if this bar is invisible, set visible.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void optionsIcon_Click(object sender, EventArgs e) {
            if (layoutOptions.Visible) {
                layoutOptions.Visible = false;
            } else {
                layoutOptions.Visible = true;
                layoutOptions.Focus();
            }
        }

        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void exitImage_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void exitLabel_Click_1(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutExit_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(loginForm);
            Application.Exit();
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void minimizeLabel_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void pictureBox9_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutMinimize_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento que permite mover el formulario al hacer click sobre el y arrastrarlo
        /// 
        /// Event for to move this form when user click and drag
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e) {
            clickMouse = true;
            startPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Evento que permite mover el formulario al hacer click sobre el y arrastrarlo
        /// 
        /// Event for to move this form when user click and drag
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {
            if (clickMouse) {
                Point newLocation = PointToScreen(e.Location);
                Location = new Point(newLocation.X - startPoint.X, newLocation.Y - startPoint.Y);
            }
        }

        /// <summary>
        /// Evento de ratón, que detecta cuando el ratón ha sido levantado
        /// 
        /// Event of mouse that detect when the user drop click button of mouse.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e) {
            clickMouse = false;
        }

        /// <summary>
        /// Evento que detecta cuando el usuario hacer click en algo que no son las opciones y las esconde.
        /// 
        /// Event that detect when user click in other zone that not is bar options and hide this bar.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutOptions_Leave(object sender, EventArgs e) {
            layoutOptions.Visible = false;
        }

        /// <summary>
        /// Detecta cuando el usuario hace click sobre la caja de texto para introducir el usuario
        /// En caso de que dicha caja esté vacía, resetea sus valores por defecto
        /// 
        /// Event that detect when user click into user text box and, if the content is empty, reset this text box
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void textBoxUser_Enter(object sender, EventArgs e) {
            if (textBoxUser.Text == "Correo") {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Detecta cuando la caja de texto del usuario pierde el foco, si la caja está vacía, resetea sus valores
        /// 
        /// Event that detect when this text box lose focus, if this text box is empty, reset this text box.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void textBoxUser_Leave(object sender, EventArgs e) {
            if (textBoxUser.Text == "") {
                textBoxUser.Text = "Correo";
                textBoxUser.ForeColor = Color.DarkGray;
            }
        }

        /// <summary>
        /// Detecta cuando el usuario hace click sobre la caja de texto para introducir la contraseña
        /// En caso de que dicha caja esté vacía, resetea sus valores por defecto
        /// 
        /// Event that detect when user click into password text box and, if the content is empty, reset this text box
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void textBoxPasswd_Enter(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "Contraseña") {
                textBoxPasswd.Text = "";
                textBoxPasswd.ForeColor = Color.Black;
                textBoxPasswd.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Detecta cuando la caja de texto de la contraseña pierde el foco, si la caja está vacía, resetea sus valores
        /// 
        /// Event that detect when this text box lose focus, if this text box is empty, reset this text box.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void textBoxPasswd_Leave(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "") {
                textBoxPasswd.Text = "Contraseña";
                textBoxPasswd.ForeColor = Color.DarkGray;
                textBoxPasswd.UseSystemPasswordChar = false;
            }
        }

        

        /// <summary>
        /// Evento de click sobre la imagen del usuario, permite al usuario elegir una imagen para cargarla, la redimensiona adecuadamente
        /// y verifica su posición, si estuviera girada, la intentaría poner recta.
        /// 
        /// Event of click about user imagen, the user can select one image for to load into login form, this method resize this image
        /// and check their position, if this image are rotated, try to put this image into good position.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
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

        



        

        /// <summary>
        /// Evento de click sobre el botón de login
        /// 
        /// Click event about login form button
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
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
                            //MessageBox.Show("NO soy el hilo");
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
                            //MessageBox.Show("soy el hilo");
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

        /// <summary>
        /// Evento que detecta si el usuario ha presionado la tecla 'Enter' en la caja de texto del usuario,
        /// si es así, emula un click sobre el botón de login del formulario
        /// 
        /// Event that detect if the user press 'Enter' in the user text box, if thi is case, this method will emulate
        /// click button about login button.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">KeyPressEventArgs, evento activado de teclado</param>
        /// <param name="e">KeyPressEventArgs, Activated event of keyboard</param>
        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char) 13) {
                loginButton.PerformClick();
            }
        }

        /// <summary>
        /// Evento que detecta si el usuario ha presionado la tecla 'Enter' en la caja de texto de la contraseña,
        /// si es así, emula un click sobre el botón de login del formulario
        /// 
        /// Event that detect if the user press 'Enter' in the password text box, if thi is case, this method will emulate
        /// click button about login button.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">KeyPressEventArgs, evento activado de teclado</param>
        /// <param name="e">KeyPressEventArgs, Activated event of keyboard</param>
        private void textBoxPasswd_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                loginButton.PerformClick();
            }
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutAbout_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void aboutLabel_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void aboutIcon_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutSupport_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void supportLabel_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void supportIcon_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        private void sendData_Click(object sender, EventArgs e) {

            string jsonString = Utilities.generateSingleDataRequest("test", "");

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void createUserPanel(string nameOfUserParam, string emailUserParam) {
            UserControlPanelObject = new UserControlPanel(nameOfUserParam, emailUserParam, userImage);
            UserControlPanelObject.Show();
        }

        public UserControlPanel UserControlPanelObject { get => userControlPanelObject; set => userControlPanelObject = value; }
        public AddNewQuestion AddNewQuestionObject { get => addNewQuestionObject; set => addNewQuestionObject = value; }
        public AddNewQuestionTypeTest AddNewQuestionTypeTest { get => addNewQuestionTypeTest; set => addNewQuestionTypeTest = value; }
        public  ListAllNormalQuestions ListAllNormalQuestions { get => listAllNormalQuestions; set => listAllNormalQuestions = value; }
        public ListAllTestQuestions ListAllTestQuestions { get => listAllTestQuestions; set => listAllTestQuestions = value; }
        public FormNewNormalModification FormNewNormalModification { get => formNewNormalModification; set => formNewNormalModification = value; }
        public ModelWindowsMessage ModelWindowsMessage { get => modelWindowsMessage; set => modelWindowsMessage = value; }
        public ModelWindowsMessageWithBroder ModelWindowsMessageWithBroder { get => modelWindowsMessageWithBroder; set => modelWindowsMessageWithBroder = value; }
        public ModelWindowsMessageWithBroderWarning ModelWindowsMessageWithBroderWarning { get => modelWindowsMessageWithBroderWarning; set => modelWindowsMessageWithBroderWarning = value; }
        public FormNewTestModification FormNewTestModification { get => formNewTestModification; set => formNewTestModification = value; }
        public SelectSubjectForm SelectSubjectFormObject { get => selectSubjectFormObject; set => selectSubjectFormObject = value; }
        public CreateNormalExam CreateNormalExamObject { get => createNormalExamObject; set => createNormalExamObject = value; }
        public AllDataNormalModel AllDataNormalModelObject { get => allDataNormalModelObject; set => allDataNormalModelObject = value; }
    }
}

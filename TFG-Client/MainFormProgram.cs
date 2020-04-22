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
        /// <summary>
        /// 
        /// Constructor de la clase
        /// 
        /// Constructor of the class
        /// </summary>
        public MainFormProgram() {
            InitializeComponent();
            checkWindowsFormPositon();
            /**
             * Se usa para que el textbox de usuario no establezca el foco.
             * 
             * This is for to remove focus of the user textBox.
             */
            ActiveControl = titleLabel;
        }
        /// <summary>
        /// Comprueba la posición de la ventana, el usuario y la imagen del mismo en el registro de windows y carga los datos en caso de encontrarlos en el mismo.
        /// 
        /// Check windows form position, user data and user image in the windows registry. Load these datas if found in the windows registry.
        /// </summary>
        private void checkWindowsFormPositon() {

            bool checkPositionRegistryKey = OpenKey("positionX");

            if (!checkPositionRegistryKey) {
                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config");
                keyPosition.SetValue("positionX", Left);
                keyPosition.SetValue("positionY", Top);

                ImageConverter imgConv = new ImageConverter();
                byte[] imgArrayBytes = (byte[])imgConv.ConvertTo(userImage.Image, typeof(byte []));
                keyPosition.SetValue("userImage", imgArrayBytes);

                keyPosition.SetValue("user", textBoxUser.Text);

                keyPosition.Close();
            } else {
                RegistryKey keyPosition = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config", true);
                string positionX = keyPosition.GetValue("positionX", true).ToString();
                string positionY = keyPosition.GetValue("positionY", true).ToString();
                string userName = keyPosition.GetValue("user", true).ToString();

                byte [] imageArrayBytes = (byte []) keyPosition.GetValue("userImage", true);
                userImage.Image = byteArrayToImage(imageArrayBytes);

                Left = Int32.Parse(positionX);
                Top = Int32.Parse(positionY);
                StartPosition = FormStartPosition.Manual;
                Location = new Point(Left, Top);

                textBoxUser.Text = userName;
                /**
                 * Restablece el placeholder del input text asociado al usuario
                 * 
                 * Restarted user input placeholder.
                 */
                if (textBoxUser.Text == "Usuario") {
                    textBoxUser.ForeColor = Color.DarkGray;
                } else {
                    textBoxUser.ForeColor = Color.Black;
                }
                

            }

        }

        /// <summary>
        /// Convierte el array de bytes en una imagen
        /// 
        /// Convert byte array into image
        /// </summary>
        /// <param name="byteArrayParam">byte [], Array de bytes que contiene toda la info sobre la imagen antes de ser convertida a imagen</param>
        /// <param name="byteArrayParam">byte [], array of bytes that contain all information about image before that convert into image</param>
        /// <returns>
        /// El array de bytes convertido a imagen
        /// 
        /// Array of bytes convert into image
        /// </returns>
        public Image byteArrayToImage(byte [] byteArrayParam) {
            using (var ms = new MemoryStream(byteArrayParam)) {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Almacena la posición de la ventana al ser cerrada por el usuario
        /// 
        /// Stored position of login form when user close the login screen
        /// </summary>
        private void saveWindowsFormPosition() {
            if (WindowState != FormWindowState.Minimized) {
                int positionX = Left;
                int positionY = Top;

                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config");
                keyPosition.SetValue("positionX", positionX);
                keyPosition.SetValue("positionY", positionY);
                ImageConverter imgConv = new ImageConverter();
                byte[] imgArrayBytes = (byte[])imgConv.ConvertTo(userImage.Image, typeof(byte[]));
                keyPosition.SetValue("userImage", imgArrayBytes);
                keyPosition.SetValue("user", textBoxUser.Text);
                keyPosition.Close();
            }
        }

        /// <summary>
        /// Revisa si el valor recibido como parámetro se encuentra en el registro de windows
        /// 
        /// Check if parameter value exist into windows registry.
        /// </summary>
        /// <param name="value">string, valor a buscar en el registro de windows</param>
        /// <param name="value">string, value to find into windows registry</param>
        /// <returns>
        /// True, si encuentra el valor.
        /// False, si no lo encuentra.
        /// 
        /// True, if this valor exist.
        /// False, if this valor don't exist.
        /// </returns>
        private bool OpenKey(string value) {
            try {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config", true);
                if (key == null) {
                    throw new Exception();
                } else {
                    return true;
                }
            } catch (Exception ex) {
                return false;
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
                    JSonSingleData clientDisconnectMessage = new JSonSingleData();
                    clientDisconnectMessage.A_Title = "client_disconnect";
                    // No puede ir vacio, si no salta excepción en el servidor y se cierra la conexión
                    clientDisconnectMessage.B_Content = "";
                    string jsonString = JsonConvert.SerializeObject(clientDisconnectMessage);
                    byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(ConnectionWithServer.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                    ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                    // Envio de datos mediante flush
                    ConnectionWithServer.ServerStream.Flush();
                }
            } catch (Exception ex) {
            }
            
            base.OnFormClosed(e);
            saveWindowsFormPosition();
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
            layoutOptions.Visible = false;
            if (!CheckForInternetConnection()) {
                // Mensaje de error por no tener conexión a internet
                MessageBox.Show("No tienes internet");
                Application.Exit();
                // Cierre de la App
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
        private void exitLabel_Click(object sender, EventArgs e) {
            saveWindowsFormPosition();
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
        private void exitImage_Click(object sender, EventArgs e) {
            saveWindowsFormPosition();
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
            saveWindowsFormPosition();
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
            saveWindowsFormPosition();
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
            if (textBoxUser.Text == "Usuario") {
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
                textBoxUser.Text = "Usuario";
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
        /// Detecta si el usuario tiene conexión a internet.
        /// 
        /// Function that detect if this user has a internet connection
        /// </summary>
        /// <returns>
        /// True, si el servidor al que se conecta responde (Tiene conexión)
        /// False, si el servidor al que se conecta no responde (No tiene conexión)
        /// 
        /// True, If the server that you have connected to responds (Have internet connection)
        /// False, If the server that you have connected not to responds (Don't have internet connection)
        /// </returns>
        private bool CheckForInternetConnection() {
            try {
                WebClient client = new WebClient();
                client.OpenRead("http://google.com/generate_204");
                return true;
            } catch (Exception) {
                return false;
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
            if (tConnection == null) {
                if (layoutOptions.Visible) {
                    layoutOptions.Visible = false;
                }

                OpenFileDialog fileDialogObject = new OpenFileDialog();
                fileDialogObject.Filter = "Image Files(*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";

                if (fileDialogObject.ShowDialog() == DialogResult.OK) {
                    try {
                        Bitmap userSelectedImage = new Bitmap(fileDialogObject.FileName);
                        GetOrientation((Image)userSelectedImage).ToString();
                        userImage.Image = FixedSize(userSelectedImage, 320, 320, true);
                    } catch (Exception) {
                        // Error de carga de imagen
                    }
                }
            } else {
                // Mensaje de error, no se puede cambiar la imagen durante el login
            }
        }

        /// <summary>
        /// Permite mirar la horientación de la imagen y establecer en las propiedades de la misma
        /// que esté recta en caso de ser necesario.
        /// 
        /// Check if the image are in wrong position, if this case are real, change the position of image.
        /// </summary>
        /// <param name="image">Image, imagen recibida como parámetro para revisar</param>
        /// <param name="image">Image, image as paramter to check</param>
        /// <returns>
        /// ImageOrientation, Horientación de la imagen en vertical
        /// ImageOrientation, Horientation of image into vertical.
        /// </returns>
        private static ImageOrientation GetOrientation(Image image) {
            PropertyItem pi = SafeGetPropertyItem(image, 0x112);
            return ImageOrientation.Vertical;
        }

        /// <summary>
        /// Almacena las propiedades de la imagen trás ser modificadas para que la imagen esté en vertical.
        /// 
        /// Store image properties when the image has changed.
        /// </summary>
        /// <param name="image">Image, imagen como parámetro</param>
        /// <param name="image">Image, imagen has parameter</param>
        /// <param name="propid">int, Id de la imagen</param>
        /// <param name="propid">int, Id about image</param>
        /// <returns>
        /// PropertyItem, Propiedades de la imagen modificadas
        /// PropertyItem, Properties of image changed.
        /// 
        /// null, Si el archivo que se intentó modificar no tiene un archivo de registro EXIF.
        /// null, If this image hasn't EXIF file (Properties file)
        /// </returns>
        private static PropertyItem SafeGetPropertyItem(Image image, int propid) {
            try {
                return image.GetPropertyItem(propid);
            } catch (ArgumentException) {
                return null;
            }
        }

        /// <summary>
        /// Permite redimensionar la imagen.
        /// 
        /// Resize image
        /// </summary>
        /// <param name="image">Image, imagen como parámetro</param>
        /// <param name="image">Image, image as param</param>
        /// <param name="Width">int, anchura de la imagen deseada</param>
        /// <param name="Width">int, width of image that login form need</param>
        /// <param name="Height">int, altura de la imagen deseada</param>
        /// <param name="Height">int, height of image that login form need</param>
        /// <param name="needToFill">bool, indica si la imagen necesita ser llenada</param>
        /// <param name="needToFill">bool, tell if this image needs to fill</param>
        /// <returns></returns>
        private Image FixedSize(Image image, int Width, int Height, bool needToFill) {

            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill) {
                nScale = Math.Min(nScaleH, nScaleW);
            } else {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            Bitmap bmPhoto = null;
            try {
                bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            } catch (Exception ex) {}

            using (Graphics grPhoto = Graphics.FromImage(bmPhoto)) {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);

                return bmPhoto;
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
            // Desactivación del botón hasta que finaliza proceso de login
            loginButton.Enabled = false;
            /**
             * Pasa el control activo a la barra de título para que no se quede el botón de login marcado
             * 
             * Transers ActiveControl to titleBar for to the login button don't show clicked status
             */
            ActiveControl = titleLabel;

            if (CheckForInternetConnection()) {
                // Tiene internet
                // Have internet connection
                loadInternalPanel.Visible = true;
                loadInternalPanel.Width += 50;
                
                if (textBoxUser.Text.Trim().Length == 0 || textBoxPasswd.Text.Trim().Length == 0 || (textBoxUser.Text.Trim() == "Usuario" || textBoxPasswd.Text.Trim() == "Contraseña")) {
                    // Error de valores inválidos
                    // Error, invalid login data
                    loadInternalPanel.Visible = false;
                    loadInternalPanel.Width = 50;
                    loginButton.Enabled = true;
                } else {
                    /**
                     * Crea un objeto JSon con los datos del login, lo encripta y lo evía al servidor.
                     * La conexión con el servidor es un objeto de tipo hilo.
                     * 
                     * Create JSon object with login data, after encrypt these datas and send to server.
                     * Conection with the server is a thread object.
                     */
                    
                    JSonSingleData getPasswd = new JSonSingleData();
                    getPasswd.A_Title = "GetPasswd";

                    JSonObjectArray userLoginData = new JSonObjectArray();

                    userLoginData.A_Title = "loginCredentials";
                    // Limpieza de caracteres extraños
                    
                    string userData = textBoxUser.Text.Trim();
                    string userPasswdData = textBoxPasswd.Text.Trim();

                    foreach (string c in charsToRemove) {
                        userData = userData.Replace(c, string.Empty);
                        userPasswdData = userPasswdData.Replace(c, string.Empty);
                    }

                    userLoginData.B_Content = new string[] { userData, userPasswdData};

                    loadInternalPanel.Width += 50;
                    //JSonObject foo = new JSonObject();

                    //foo.Content = new string[] {textBoxUser.Text.Trim(), textBoxPasswd.Text.Trim()};
                    //foo.Title = "Connect";

                    string jsonStringKey = JsonConvert.SerializeObject(getPasswd);
                    string jsonStringUserData = JsonConvert.SerializeObject(userLoginData);
                    ConnectionWithServer.LoadPanel = loadInternalPanel;
                    ConnectionWithServer.JsonGetKey = jsonStringKey;
                    ConnectionWithServer.JsonLoginData = jsonStringUserData;
                    ConnectionWithServer.LoginButton = loginButton;

                    loadInternalPanel.Width += 50;
                    if (checkConnectionWithServer) {
                        //MessageBox.Show("NO soy el hilo");
                        // Ya se ha realizado la conexión, se intenta iniciar sesión
                        byte[] byteArrayLoginData = Encoding.ASCII.GetBytes(ConnectionWithServer.Encrypt(ConnectionWithServer.JsonLoginData, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

                        ConnectionWithServer.ServerStream.Write(byteArrayLoginData, 0, byteArrayLoginData.Length);
                        // Envio de datos mediante flush
                        ConnectionWithServer.ServerStream.Flush();
                    } else {
                        /**
                         * Primer intento de inicio de sesión, se crea la conexión inicial como hilo para lectura de datos
                         * del servidor
                         */
                        //MessageBox.Show("soy el hilo");
                        tConnection = new Thread(new ThreadStart(ConnectionWithServer.run));
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
            createAboutForm();
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
            createAboutForm();
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
            createAboutForm();
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
            createSupportForm();
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
            createSupportForm();
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
            createSupportForm();
        }

        /// <summary>
        /// Crea y muestra el formulario de soporte al usuario
        /// 
        /// Create and show support form.
        /// </summary>
        private void createSupportForm() {
            ModelWindowsMessage supportForm = new ModelWindowsMessage();
            supportForm.StartPosition = FormStartPosition.CenterParent;
            supportForm.title.Text = "Soporte";
            supportForm.messageLabel.Text = "Para cualquier problema o duda, \n" +
                                            "envie un correo a javierferfer99@gmail.com \n" +
                                            "gracias por su colaboración";

            Point centerLocation = new Point(supportForm.messageLabel.Location.X + 120, supportForm.messageLabel.Location.Y);
            supportForm.messageLabel.Location = centerLocation;
            supportForm.ImageSchool.Visible = false;
            supportForm.ShowDialog();
        }

        /// <summary>
        /// Crea y muestra el formulario de 'Acerca de...' al usuario
        /// 
        /// Create and show About form.
        /// </summary>
        private void createAboutForm() {
            ModelWindowsMessage aboutForm = new ModelWindowsMessage();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.title.Text = "Acerca de...";
            aboutForm.messageLabel.Text = "Este proyecto ha sido creado \n" +
                                          "por Javier Fernández Fernández \n" +
                                          "como trabajo de final de grado.";
            aboutForm.ShowDialog();
        }

        private void sendData_Click(object sender, EventArgs e) {

            JSonSingleData clientDisconnectMessage = new JSonSingleData();
            clientDisconnectMessage.A_Title = "test";
            clientDisconnectMessage.B_Content = "";
            string jsonString = JsonConvert.SerializeObject(clientDisconnectMessage);

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(ConnectionWithServer.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }
    }
}

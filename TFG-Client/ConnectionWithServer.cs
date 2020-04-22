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
        private static UserControlPanel userControlPanelObject;
        private static Panel loadPanel;
        private static string encryptKey;
        private static string ivString;
        private static string jsonGetKey;
        private static string jsonLoginData;
        private static string emailUser;
        private static NetworkStream serverStream;
        private static bool readServerData = true;
        private static Button loginButton;
        private static MyOwnCircleComponent userImage;

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
            try {
                loginForm = loginFormParam;
                // Reseteo de variable en caso de login fallido
                readServerData = true;

                increaseLoadingBar();

                TcpClient clientSocket = new TcpClient();
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
                            MessageBox.Show("Se ha cerrado la conexion");
                            MainFormProgram.checkConnectionWithServer = false;
                            readServerData = false;
                            loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                            resetLoadingBar();
                        } else {
                            // Conversión del mensaje recibido a Json para poder leer el título
                            // Con esto sabemos que formato va a tener el mensaje recibido
                            JObject json = JObject.Parse(serverMessageDesencrypt);

                            if (json.First.ToString().Contains("loginStatus")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                if (singleAnswer.B_Content.Equals("correct")) {
                                    // Pasaria a la ventana del programa principal
                                    MessageBox.Show("Login correcto");

                                    // Peticion de nombre del usuario al servidor


                                    //loginForm.Invoke(new MethodInvoker(delegate { loginForm.Visible = false; }));
                                    //userControlPanelObject = new UserControlPanel(emailUser, userImage);
                                    //userControlPanelObject.ShowDialog();
                                } else if (singleAnswer.B_Content.Equals("incorrect")) {
                                    // Mensaje de error de datos invalidos en el login
                                    MessageBox.Show("Login incorrecto");
                                    loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                                }
                            } else if (json.First.ToString().Contains("connectionStatus")) {
                                JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                                if (singleAnswer.B_Content.Equals("closedForTimeOut")) {
                                    MessageBox.Show("Conexión con el servidor finalizada por time out");
                                    resetLoadingBar();
                                    MainFormProgram.checkConnectionWithServer = false;
                                    readServerData = false;
                                    loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
                                }
                            }




                            //JSonSingleData answerServer = JsonConvert.DeserializeObject<JSonObjectArray>(mensajeServidor);
                        }
                    }

                } else {
                    // Mensaje de error al no poder obtener la key
                }
                //Console.WriteLine(mensajeServidor);



                // Desencriptación del mensaje recibido por el servidor
                // Si es correcto, abre la siguiente interfaz, en caso contrario error

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                // Error al intentar acceder al sistema, el servidor no está funcionando
                resetLoadingBar();
                MainFormProgram.checkConnectionWithServer = false;
                readServerData = false;
                loginButton.Invoke(new MethodInvoker(delegate { loginButton.Enabled = true; }));
            }

        }

        


        

        /// <summary>
        /// Incrementa la barra de carga del formulario del login
        /// 
        /// Increment loading bar in login screen
        /// </summary>
        private static void increaseLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Width += 50;
            }));
        }

        /// <summary>
        /// Resetea la barra de carga del login
        /// 
        /// Reset loading bar in login screen
        /// </summary>
        private static void resetLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Visible = false;
                LoadPanel.Width = 50;
            }));
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
    }
}

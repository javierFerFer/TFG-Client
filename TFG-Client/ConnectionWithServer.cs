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
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    public class ConnectionWithServer {

        private Panel loadPanel;
        private string encryptKey;
        private string ivString;
        private NetworkStream serverStream;
        private string jsonGetKey;
        private string jsonLoginData;
        private static bool readServerData = true;

        /// <summary>
        /// Constructor del objeto conexión
        /// 
        /// Constructor of connection object
        /// </summary>
        /// <param name="loadPanelParam">Panel, barra de carga que será avanzará según la conexión con el servidor se establezca</param>
        /// <param name="loadPanelParam">Panel, load bar that change when the connection progress</param>
        /// <param name="jSonObjectParam">string, objeto JSon convertido a string para enviarselo al servidor</param>
        /// <param name="jSonObjectParam">string, JSon object converted to string for to sernd to server</param>
        public ConnectionWithServer(Panel loadPanelParam, string jsonKeyParam, string jsonUserLoginDataParam) {
            LoadPanel = loadPanelParam;
            jsonGetKey = jsonKeyParam;
            jsonLoginData = jsonUserLoginDataParam;
        }

        /// <summary>
        /// Run del hilo conexión
        /// 
        /// Run thread connection
        /// </summary>
        public void run() {
            //try {

                increaseLoadingBar();

                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect("178.62.40.25", 12345);
                increaseLoadingBar();

                serverStream = clientSocket.GetStream();
                increaseLoadingBar();

                // Antes debe hacer una petición para obtener la clave de encriptación
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(jsonGetKey);
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
                    encryptKey = answerServer.B_Content[0];
                    ivString = answerServer.B_Content[1];

                // AQUI
                // Debe usar la clave recibida para cifrar los datos del usuario y enviarlos
                // Envio de datos

                // Array de datos del cliente encriptados
                //MessageBox.Show(encryptKey);
                //MessageBox.Show(ivString);

                    byte[] byteArrayLoginData = Encoding.ASCII.GetBytes(Encrypt(jsonLoginData, encryptKey, ivString));

                    serverStream.Write(byteArrayLoginData, 0, byteArrayLoginData.Length);
                    // Envio de datos mediante flush
                    serverStream.Flush();


                while (readServerData) {

                    buffer = new byte[1024];
                    recv = clientSocket.Client.Receive(buffer);
                    serverMessage = Encoding.ASCII.GetString(buffer, 0, recv);

                    string serverMessageDesencrypt = Decrypt(serverMessage, ivString, encryptKey);

                    // Conversión del mensaje recibido a Json para poder leer el título
                    // Con esto sabemos que formato va a tener el mensaje recibido
                    JObject json = JObject.Parse(serverMessageDesencrypt);

                    if (json.First.ToString().Contains("loginStatus")) {
                        JSonSingleData singleAnswer = JsonConvert.DeserializeObject<JSonSingleData>(serverMessageDesencrypt);
                        if (singleAnswer.B_Content.Equals("correct")) {
                            S// Pasaria a la ventana del programa principal
                        }
                    }


                    

                    //JSonSingleData answerServer = JsonConvert.DeserializeObject<JSonObjectArray>(mensajeServidor);

                }

                } else {
                    // Mensaje de error al no poder obtener la key
                }
                //Console.WriteLine(mensajeServidor);



                // Desencriptación del mensaje recibido por el servidor
                // Si es correcto, abre la siguiente interfaz, en caso contrario error





            //} catch (Exception ex) {
                // Reset all values
                // Cierre de la conexion
                //clientSocket.Client.Close();
               // resetLoadingBar();
              //  MainFormProgram.tConnection = null;
            //}            
        }

        public static string Decrypt(string encryptedInputBase64, string ivStringParam, string passwd) {

            using (AesCryptoServiceProvider aesEncryptor = new AesCryptoServiceProvider()) {
                var encryptedData = Convert.FromBase64String(encryptedInputBase64);
                var btKey = System.Text.Encoding.ASCII.GetBytes(passwd);
                byte[] iv = Encoding.ASCII.GetBytes(ivStringParam);

                var keyString = System.Text.Encoding.Unicode.GetString(aesEncryptor.Key);
                aesEncryptor.Mode = CipherMode.CBC;
                aesEncryptor.Padding = PaddingMode.PKCS7;
                aesEncryptor.KeySize = 256;
                aesEncryptor.BlockSize = 128;
                aesEncryptor.Key = btKey;

                aesEncryptor.IV = iv;

                return InternalDecrypt(aesEncryptor, encryptedData);
            }
        }


        private static string InternalDecrypt(AesCryptoServiceProvider aesEncryptor, byte[] encryptedData) {
            using (ICryptoTransform decryptor = aesEncryptor.CreateDecryptor(aesEncryptor.Key,
                                                                             aesEncryptor.IV)) {
                byte[] decrypted;
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptedData)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                                                                     decryptor,
                                                                     CryptoStreamMode.Read)) {
                        decrypted = new byte[encryptedData.Length];
                        var byteCount = csDecrypt.Read(decrypted, 0, encryptedData.Length);
                        string strResult = Encoding.ASCII.GetString(decrypted);
                        int pos = strResult.IndexOf('\0');
                        if (pos >= 0)
                            strResult = strResult.Substring(0, pos);
                        return strResult;
                    }
                }
            }
        }


        private static string Encrypt(string message, string KeyString, string IVString) {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = ASCIIEncoding.UTF8.GetBytes(IVString);

            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;

            try {
                MemoryStream ms = new MemoryStream();

                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write)) {
                    using (StreamWriter sw = new StreamWriter(cs)) {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            } catch (CryptographicException e) {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            } catch (UnauthorizedAccessException e) {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            } catch (Exception e) {
                Console.WriteLine("An error occurred: {0}", e.Message);
            } finally {
                rj.Clear();
            }
            return encrypted;
        }

        /// <summary>
        /// Incrementa la barra de carga del formulario del login
        /// 
        /// Increment loading bar in login screen
        /// </summary>
        private void increaseLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Width += 50;
            }));
        }

        /// <summary>
        /// Resetea la barra de carga del login
        /// 
        /// Reset loading bar in login screen
        /// </summary>
        private void resetLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Visible = false;
                LoadPanel.Width = 50;
            }));
        }

        // Gets y sets
        public NetworkStream ServerStream { get => serverStream; set => serverStream = value; }
        public Panel LoadPanel { get => loadPanel; set => loadPanel = value; }

    }
}

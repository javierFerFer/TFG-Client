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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        private NetworkStream serverStream;
        private string jSonObject;

        /// <summary>
        /// Constructor del objeto conexión
        /// 
        /// Constructor of connection object
        /// </summary>
        /// <param name="loadPanelParam">Panel, barra de carga que será avanzará según la conexión con el servidor se establezca</param>
        /// <param name="loadPanelParam">Panel, load bar that change when the connection progress</param>
        /// <param name="jSonObjectParam">string, objeto JSon convertido a string para enviarselo al servidor</param>
        /// <param name="jSonObjectParam">string, JSon object converted to string for to sernd to server</param>
        public ConnectionWithServer(Panel loadPanelParam, string jSonObjectParam) {
            LoadPanel = loadPanelParam;
            jSonObject = jSonObjectParam;
        }

        /// <summary>
        /// Run del hilo conexión
        /// 
        /// Run thread connection
        /// </summary>
        public void run() {
            try {

                increaseLoadingBar();

                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect("178.62.40.25", 12345);
                increaseLoadingBar();

                serverStream = clientSocket.GetStream();
                increaseLoadingBar();

                // Antes debe hacer una petición para obtener la clave de encriptación
                // Antes debe encriptar

                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(jSonObject);
                serverStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                serverStream.Flush();

                // Recibo de datos
                while (true) {
                    Thread.Sleep(1000);
                    //MessageBox.Show("pasa");
                    //MessageBox.Show(clientSocket.Connected.ToString());
                    byte[] buffer = new byte[1024];
                    int recv = clientSocket.Client.Receive(buffer);
                    string mensajeServidor = Encoding.ASCII.GetString(buffer, 0, recv);
                    Console.WriteLine(mensajeServidor);
                }



                // Desencriptación del mensaje recibido por el servidor
                // Si es correcto, abre la siguiente interfaz, en caso contrario error





            } catch (Exception ex) {
                // Reset all values
                // Cierre de la conexion
                //clientSocket.Client.Close();
                resetLoadingBar();
                MainFormProgram.tConnection = null;
            }            
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

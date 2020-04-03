using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public class ConnectionWithServer {

        private Panel loadPanel;
        private NetworkStream serverStream;
        private string jSonObject;

        public ConnectionWithServer(Panel loadPanelParam, string jSonObjectParam) {
            LoadPanel = loadPanelParam;
            jSonObject = jSonObjectParam;
        }


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
                byte[] buffer = new byte[1024];
                int recv = clientSocket.Client.Receive(buffer);
                string mensajeServidor = Encoding.ASCII.GetString(buffer, 0, recv);
                Console.WriteLine(mensajeServidor);


                // Desencriptación del mensaje recibido por el servidor
                // Si es correcto, abre la siguiente interfaz, en caso contrario error

                // Cierre de la conexion
                //clientSocket.Client.Close();

            } catch (SocketException timeOutEx) {
                // Reset all values
                resetLoadingBar();
                MainFormProgram.tConnection = null;
            }
        }

        private void increaseLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Width += 50;
            }));
        }

        private void resetLoadingBar() {
            LoadPanel.Invoke(new Action(() => {
                LoadPanel.Visible = false;
                LoadPanel.Width = 50;
            }));
        }

        public NetworkStream ServerStream { get => serverStream; set => serverStream = value; }
        public Panel LoadPanel { get => loadPanel; set => loadPanel = value; }

    }
}

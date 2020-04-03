using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {
    public class ConnectionWithServer {

        public void run() {
            try {
                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect("178.62.40.25", 12345);

            } catch (SocketException timeOutEx) {
                Console.WriteLine("Error de tiempo");
            }
        }

    }
}

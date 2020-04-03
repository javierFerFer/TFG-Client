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

        public ConnectionWithServer(Panel loadPanelParam) {
            loadPanel = loadPanelParam;
        }

        public void run() {
            try {

                increaseLoadingBar();

                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect("178.62.40.25", 12345);

                increaseLoadingBar();



            } catch (SocketException timeOutEx) {
                // Reset all values
                resetLoadingBar();
                MainFormProgram.tConnection = null;
            }
        }

        private void increaseLoadingBar() {
            loadPanel.Invoke(new Action(() => {
                loadPanel.Width += 50;
            }));
        }

        private void resetLoadingBar() {
            loadPanel.Invoke(new Action(() => {
                loadPanel.Visible = false;
                loadPanel.Width = 50;
            }));
        }

    }
}

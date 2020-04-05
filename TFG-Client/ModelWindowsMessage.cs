using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    partial class ModelWindowsMessage : Form {
        public ModelWindowsMessage() {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void exitButton_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}

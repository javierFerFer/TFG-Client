///
/// Todos los using de la clase
/// 
/// All using of the class
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    /// <summary>
    /// 
    /// Formulario de inicio de sesión
    /// 
    /// Login form
    /// </summary>
    public partial class MainFormProgram : Form {
        private bool clickMouse = false;
        private Point startPoint = new Point(0, 0);
        /// <summary>
        /// 
        /// Constructor de la clase
        /// 
        /// Constructor of the class
        /// </summary>
        public MainFormProgram() {
            InitializeComponent();
        }




        private void MainFormProgram_Load(object sender, EventArgs e) {
            layoutOptions.Visible = false;
        }

        private void optionsIcon_Click(object sender, EventArgs e) {
            if (layoutOptions.Visible) {
                layoutOptions.Visible = false;
            } else {
                layoutOptions.Visible = true;
                layoutOptions.Focus();
            }
        }

        private void exitLabel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void exitImage_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void exitLabel_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }

        private void layoutExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void minimizeLabel_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox9_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void layoutMinimize_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e) {
            clickMouse = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {
            if (clickMouse) {
                Point newLocation = PointToScreen(e.Location);
                Location = new Point(newLocation.X - startPoint.X, newLocation.Y - startPoint.Y);
            }
        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e) {
            clickMouse = false;
        }

        private void layoutOptions_Leave(object sender, EventArgs e) {
            layoutOptions.Visible = false;
        }
    }
}

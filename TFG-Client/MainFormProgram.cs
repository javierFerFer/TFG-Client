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
    /// FALTA:
    /// - Añadir ventana de soporte(Contacto)
    /// - Añadir ventana de Acerca de...
    /// - Al cargar la ventana, debe mirar si la posición de la misma está almacenada en el registro de windows y cargarla en caso de ser así
    /// - Al cargar la ventana, debe mirar registro de windows para cargar usuario, contraseña y foto en caso de que haya
    /// - Al cerrar el programa, se debe guardar la posición de la ventana, el usuario, la contraseña y la foto del mismo en el registro de windows
    /// - Al hacer click en el botón de logín, debe comprobar que el usuario tiene red
    /// - Al hacer click en el boton de la foto, debe permitir cargar otra foto, y esta automáticamente se guardará en el registro de windows
    /// - Comentar WndProc en Español
    /// - 
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
            /**
             * Se usa para que el textbox de usuario no establezca el foco.
             * 
             * This is for to remove focus of the user textBox.
             */
            ActiveControl = titleLabel;
        }


        /*
        Constants in Windows API
        0x84 = WM_NCHITTEST - Mouse Capture Test
        0x1 = HTCLIENT - Application Client Area
        0x2 = HTCAPTION - Application Title Bar

        This function intercepts all the commands sent to the application. 
        It checks to see of the message is a mouse click in the application. 
        It passes the action to the base action by default. It reassigns 
        the action to the title bar if it occured in the client area
        to allow the drag and move behavior.
        */

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
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox9_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void layoutMinimize_Click(object sender, EventArgs e) {
            layoutOptions.Visible = false;
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

        private void textBoxUser_Enter(object sender, EventArgs e) {
            if(textBoxUser.Text == "Usuario"){
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e) {
            if (textBoxUser.Text == "") {
                textBoxUser.Text = "Usuario";
                textBoxUser.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxPasswd_Enter(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "Contraseña") {
                textBoxPasswd.Text = "";
                textBoxPasswd.ForeColor = Color.Black;
                textBoxPasswd.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPasswd_Leave(object sender, EventArgs e) {
            if (textBoxPasswd.Text == "") {
                textBoxPasswd.Text = "Contraseña";
                textBoxPasswd.ForeColor = Color.DarkGray;
                textBoxPasswd.UseSystemPasswordChar = false;
            }
        }
    }
}

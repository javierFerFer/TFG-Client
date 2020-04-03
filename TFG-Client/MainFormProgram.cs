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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            if (textBoxUser.Text == "Usuario") {
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


        private void userImage_Click(object sender, EventArgs e) {
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
        }

        private static ImageOrientation GetOrientation(Image image) {
            PropertyItem pi = SafeGetPropertyItem(image, 0x112);
            return ImageOrientation.Vertical;
        }

        // A file without the desired EXIF property record will throw ArgumentException.
        private static PropertyItem SafeGetPropertyItem(Image image, int propid) {
            try {
                return image.GetPropertyItem(propid);
            } catch (ArgumentException) {
                return null;
            }
        }

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
            } catch (Exception ex) {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
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
    }
}

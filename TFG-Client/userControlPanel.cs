using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class UserControlPanel : Form {

        private bool clickMouse = false;
        private string emailUser;
        private int counterSubject = 5;
        private Point startPoint = new Point(0, 0);
        private ArrayList allSubjectObjects = new ArrayList();

        public UserControlPanel(string userMailParam, string emailUserParam ,MyOwnCircleComponent userImageParam) {
            try {
                InitializeComponent();
                emailUser = emailUserParam;
                userNameLabel.Text = userMailParam;
                iconUser.Image = userImageParam.Image;
                showHideRightPanel();
                fillAllSubjectsIntoArray();
                addClickEventToSUbjects();
                Utilities.openForm(new EmptyDataForm(), dataPanel, rightDock);
                Utilities.checkWindowsFormPositon(this);

            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 407, null);
            }
        }

        /// <summary>
        /// Constantes en la API de Windows:
        /// 0x84 = WM_NCHITTEST - Prueba de captura del raton
        /// 0x1 = HTCLIENT      - Área del cliente de la aplicación
        /// 0x2 = HTCAPTION     - Barra de título de la aplicación
        /// 
        /// Esta función intercepta todos los comandos enviados a la aplicación, verificando si
        /// el mensaje enviado en un click del mouse y pasando dicha acción a la barra de título,
        /// permitiendo así la funcionalidad de arrastrar y soltar.
        /// 
        /// Constants in Windows API:
        /// 0x84 = WM_NCHITTEST - Mouse Capture Test
        /// 0x1 = HTCLIENT      - Application Client Area
        /// 0x2 = HTCAPTION     - Application Title Bar
        /// 
        /// This function intercepts all the commands sent to the application.
        /// It checks to see of the message is a mouse click in the application. 
        /// It passes the action to the base action by default. It reassigns
        /// the action to the title bar if it occured in the client area
        /// to allow the drag and move behavior.
        /// </summary>
        /// <param name="m">Message, referencia del comando enviado</param>
        /// <param name="m">Message, reference about sent command</param>
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

        private void addClickEventToSUbjects() {
            for (int counter = 0; counter < allSubjectObjects.Count; counter++) {
                Label tempLabel;
                tempLabel = (Label)allSubjectObjects[counter];
                tempLabel.Click -= new EventHandler(labelSubjectClick);
                tempLabel.Click += new EventHandler(labelSubjectClick);
            }
        }

        protected void labelSubjectClick(object sender, EventArgs e) {
            //attempt to cast the sender as a label
            Label tempLabel = sender as Label;
            // AQUI puedo saber la asignatura seleccionada
            Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
        }

        private void fillAllSubjectsIntoArray() {
            allSubjectObjects.Clear();
            allSubjectObjects.Add(asignatura1);
            asignatura1.Visible = false;
            allSubjectObjects.Add(asignatura2);
            asignatura2.Visible = false;
            allSubjectObjects.Add(asignatura3);
            asignatura3.Visible = false;
            allSubjectObjects.Add(asignatura4);
            asignatura4.Visible = false;
            allSubjectObjects.Add(asignatura5);
            asignatura5.Visible = false;
            addClickEventToSUbjects();
        }

        /// <summary>
        /// Evento que permite mover el formulario al hacer click sobre el y arrastrarlo
        /// 
        /// Event for to move this form when user click and drag
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutUp_MouseDown(object sender, MouseEventArgs e) {
            clickMouse = true;
            startPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Evento que permite mover el formulario al hacer click sobre el y arrastrarlo
        /// 
        /// Event for to move this form when user click and drag
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutUp_MouseMove(object sender, MouseEventArgs e) {
            if (clickMouse) {
                Point newLocation = PointToScreen(e.Location);
                Location = new Point(newLocation.X - startPoint.X, newLocation.Y - startPoint.Y);
            }
        }

        /// <summary>
        /// Evento de ratón, que detecta cuando el ratón ha sido levantado
        /// 
        /// Event of mouse that detect when the user drop click button of mouse.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">MouseEventArgs, evento activado</param>
        /// <param name="e">MouseEventArgs, Activated event</param>
        private void flowLayoutUp_MouseUp(object sender, MouseEventArgs e) {
            clickMouse = false;
        }


        private void userImageCircle_Click(object sender, EventArgs e) {
            showHideRightPanel();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void supportLabel_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void supportIcon_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Soporte' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'Support' option, show support form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutSupport_MouseClick(object sender, MouseEventArgs e) {
            Utilities.createSupportForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void aboutLabel_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void aboutIcon_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Detecta si se ha hecho click sobre la opción de 'Acerca de...' y muestra su formulario.
        /// 
        /// Detect if the user does click into 'About' option, show about form.
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutAbout_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void minimizeLabel_Click(object sender, EventArgs e) {
            rightDock.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void minimizeIcon_Click(object sender, EventArgs e) {
            rightDock.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento de click para minimizar el formulario
        /// 
        /// Click event for to minimize this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutMinimize_Click(object sender, EventArgs e) {
            rightDock.Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void exitLabel_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }
        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void exitImage_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }

        /// <summary>
        /// Evento de click para cerrar el formulario
        /// 
        /// Click event for to close this form
        /// </summary>
        /// <param name="sender">object, Objecto que avtiva el evento</param>
        /// <param name="sender">object, Object that active this event</param>
        /// <param name="e">EventArgs, evento activado</param>
        /// <param name="e">EventArgs, Activated event</param>
        private void layoutExit_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }

        private void userNameLabel_Click(object sender, EventArgs e) {
            showHideRightPanel();
        }

        private void showHideLeftPanel() {
            if (leftPanel.Width == 54) {
                leftPanel.Width = 216;
            } else {
                leftPanel.Width = 54;
            }
        }

        private void showHideRightPanel() {
            if (rightDock.Width == 177) {
                rightDock.Width = 0;
            } else {
                rightDock.Width = 177;
            }
        }

        private void subjectPicture_Click(object sender, EventArgs e) {
            if (leftPanel.Width == 54) {
                getAllSubjects();
            } else {
                showHideLeftPanel();
                fillAllSubjectsIntoArray();
            }
        }

        private void createExamPicture_Click(object sender, EventArgs e) {
            showHideLeftPanel();
        }

        private void modelsPicture_Click(object sender, EventArgs e) {
            showHideLeftPanel();
        }

        private void changesPicture_Click(object sender, EventArgs e) {
            showHideLeftPanel();
        }

        public void fillAllSubjects(string [] allSubjectsParam) {
            Label temLabel;
            showHideLeftPanel();
            for (int counter = 0; counter < allSubjectsParam.Length; counter++) {
                 temLabel = (Label)allSubjectObjects[counter];
                 temLabel.Text = allSubjectsParam[counter];
                temLabel.Visible = true;
            }
            for (int counterHideLabels = allSubjectsParam.Length; counterHideLabels < counterSubject; counterHideLabels++) {
                temLabel = (Label)allSubjectObjects[counterHideLabels];
                temLabel.Visible = false;
            }
        }

        

        private void getAllSubjects() {
            string jsonString = Utilities.generateSingleDataRequest("getAllSubjects", emailUser);

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

    }
}

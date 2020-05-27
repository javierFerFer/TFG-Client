////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\userControlPanel.cs </file>
///
/// <copyright file="userControlPanel.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase UserControlPanel.\n
///             Implements the user control panel class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Panel de control del usuario.\n
    ///             User control panel. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class UserControlPanel : Form {

        private bool clickMouse = false;
        private string emailUser;
        private int counterSubject = 5;
        private Point startPoint = new Point(0, 0);
        private ArrayList allSubjectObjects = new ArrayList();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="userMailParam">    Nombre del usuario.\n
        ///                                 User name. </param>
        /// <param name="emailUserParam">   Email del usuario.\n
        ///                                 User email. </param>
        /// <param name="userImageParam">   Imagen del usuario.\n
        ///                                 User image </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserControlPanel(string userMailParam, string emailUserParam, MyOwnCircleComponent userImageParam) {
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que agrega eventos de click a las asignaturas del menú.\n
        ///             Event that add click events to all subjects of the menu. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void addClickEventToSUbjects() {
            for (int counter = 0; counter < allSubjectObjects.Count; counter++) {
                Label tempLabel;
                tempLabel = (Label)allSubjectObjects[counter];
                tempLabel.Click -= new EventHandler(labelSubjectClick);
                tempLabel.Click += new EventHandler(labelSubjectClick);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la asignatura.\n
        ///             Click event about subject. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void labelSubjectClick(object sender, EventArgs e) {
            //attempt to cast the sender as a label
            Label tempLabel = sender as Label;
            EmptyDataForm tempEmptyForm = new EmptyDataForm();

            if (tempLabel.Name.ToString().Equals(asignatura1.Name.ToString())) {
                Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura2.Name.ToString())) {
                Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura3.Name.ToString())) {
                Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura4.Name.ToString())) {
                Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura5.Name.ToString())) {
                Utilities.openForm(new AskOperation(tempLabel.Text, dataPanel, rightDock), dataPanel, rightDock);
            }

            if (tempLabel.Name.ToString().Equals(asignatura11.Name.ToString())) {
                Utilities.openForm(new AskTypeDataNewExam(dataPanel, rightDock, tempEmptyForm, asignatura11.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura22.Name.ToString())) {
                Utilities.openForm(new AskTypeDataNewExam(dataPanel, rightDock, tempEmptyForm, asignatura22.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura33.Name.ToString())) {
                Utilities.openForm(new AskTypeDataNewExam(dataPanel, rightDock, tempEmptyForm, asignatura33.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura44.Name.ToString())) {
                Utilities.openForm(new AskTypeDataNewExam(dataPanel, rightDock, tempEmptyForm, asignatura44.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura55.Name.ToString())) {
                Utilities.openForm(new AskTypeDataNewExam(dataPanel, rightDock, tempEmptyForm, asignatura55.Text.ToString()), dataPanel, rightDock);
            }

            if (tempLabel.Name.ToString().Equals(asignatura111.Name.ToString())) {
                Utilities.openForm(new AskTypeDataModel(dataPanel, rightDock, tempEmptyForm, asignatura111.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura222.Name.ToString())) {
                Utilities.openForm(new AskTypeDataModel(dataPanel, rightDock, tempEmptyForm, asignatura222.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura333.Name.ToString())) {
                Utilities.openForm(new AskTypeDataModel(dataPanel, rightDock, tempEmptyForm, asignatura333.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura444.Name.ToString())) {
                Utilities.openForm(new AskTypeDataModel(dataPanel, rightDock, tempEmptyForm, asignatura444.Text.ToString()), dataPanel, rightDock);
            } else if (tempLabel.Name.ToString().Equals(asignatura555.Name.ToString())) {
                Utilities.openForm(new AskTypeDataModel(dataPanel, rightDock, tempEmptyForm, asignatura555.Text.ToString()), dataPanel, rightDock);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Llena todas las asignaturas en un array.\n
        ///             Fill all subjects into array. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
            allSubjectObjects.Add(asignatura11);
            asignatura11.Visible = false;
            allSubjectObjects.Add(asignatura22);
            asignatura22.Visible = false;
            allSubjectObjects.Add(asignatura33);
            asignatura33.Visible = false;
            allSubjectObjects.Add(asignatura44);
            asignatura44.Visible = false;
            allSubjectObjects.Add(asignatura55);
            asignatura55.Visible = false;
            allSubjectObjects.Add(asignatura111);
            asignatura111.Visible = false;
            allSubjectObjects.Add(asignatura222);
            asignatura222.Visible = false;
            allSubjectObjects.Add(asignatura333);
            asignatura333.Visible = false;
            allSubjectObjects.Add(asignatura444);
            asignatura444.Visible = false;
            allSubjectObjects.Add(asignatura555);
            asignatura555.Visible = false;
            addClickEventToSUbjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que permite mover el formulario al hacer click sobre el y arrastrarlo.\n
        ///             Event to allow move the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento del mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutUp_MouseDown(object sender, MouseEventArgs e) {
            clickMouse = true;
            startPoint = new Point(e.X, e.Y);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que permite moverl el formulario.\n
        ///             Event to allow move the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento del mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutUp_MouseMove(object sender, MouseEventArgs e) {
            if (clickMouse) {
                Point newLocation = PointToScreen(e.Location);
                Location = new Point(newLocation.X - startPoint.X, newLocation.Y - startPoint.Y);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de ratón, detecta cuando el botón del raton es levantado.\n
        ///             Mouse event, detect when the button of the mouse is leave. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento del mouse.\n
        ///                         Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void flowLayoutUp_MouseUp(object sender, MouseEventArgs e) {
            clickMouse = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la imagen del usuario, muestra el menú de opciones.\n
        ///             Click event about user image, show the menu of the options. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void userImageCircle_Click(object sender, EventArgs e) {
            showHideRightPanel();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de soporte.\n
        ///             Click event, show support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void supportLabel_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de soporte.\n
        ///             Click event, show support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void supportIcon_Click(object sender, EventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de soporte.\n
        ///             Click event, show support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutSupport_MouseClick(object sender, MouseEventArgs e) {
            Utilities.createSupportForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de Acerca de...\n
        ///             Click event, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void aboutLabel_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de Acerca de...\n
        ///             Click event, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void aboutIcon_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, muestra el formulario de Acerca de...\n
        ///             Click event, show about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutAbout_Click(object sender, EventArgs e) {
            Utilities.createAboutForm();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, minimiza el formulario.\n
        ///             Click event, minmize this form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void minimizeLabel_Click(object sender, EventArgs e) {
            rightDock.Width = 0;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, minimiza el formulario.\n
        ///             Click event, minmize this form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void minimizeIcon_Click(object sender, EventArgs e) {
            rightDock.Width = 0;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, minimiza el formulario.\n
        ///             Click event, minmize this form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutMinimize_Click(object sender, EventArgs e) {
            rightDock.Width = 0;
            WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, cierra el formulario y la aplicación.\n
        ///             Click event, close this form and close the App. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitLabel_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, cierra el formulario y la aplicación.\n
        ///             Click event, close this form and close the App. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitImage_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click, cierra el formulario y la aplicación.\n
        ///             Click event, close this form and close the App. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void layoutExit_Click(object sender, EventArgs e) {
            Utilities.saveWindowsFormPosition(this);
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el nombre del usuario, muestra las opciones del menú.\n
        ///             Click event aboutname of the user, show menu options. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void userNameLabel_Click(object sender, EventArgs e) {
            showHideRightPanel();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde el panel izquierdo.\n
        ///             Shows/hide the hide left panel. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void showHideLeftPanel() {
            if (leftPanel.Width == 54) {
                leftPanel.Width = 216;
            } else {
                leftPanel.Width = 54;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde el panel derecho.\n
        ///             Shows/hide the hide right panel. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void showHideRightPanel() {
            if (rightDock.Width == 177) {
                rightDock.Width = 0;
            } else {
                rightDock.Width = 177;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la foto del usuario, muestra el menú de opciones.\n
        ///             Click event about user image, show/hide menu bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void subjectPicture_Click(object sender, EventArgs e) {
            if (leftPanel.Width == 54) {
                getAllSubjects();
            } else {
                showHideLeftPanel();
                fillAllSubjectsIntoArray();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre las preguntas, muestra el menú de opciones.\n
        ///             Click event about questions, show/hide menu bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void createExamPicture_Click(object sender, EventArgs e) {
            if (leftPanel.Width == 54) {
                getAllSubjects();
            } else {
                showHideLeftPanel();
                fillAllSubjectsIntoArray();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre los modelos, muestra el menú de opciones.\n
        ///             Click event about models, show/hide menu bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void modelsPicture_Click(object sender, EventArgs e) {
            if (leftPanel.Width == 54) {
                getAllSubjects();
            } else {
                showHideLeftPanel();
                fillAllSubjectsIntoArray();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre las modificaciones, muestra el menú de opciones.\n
        ///             Click event about modify, show/hide menu bar. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void changesPicture_Click(object sender, EventArgs e) {
            if (leftPanel.Width == 54) {
                getAllSubjects();
            } else {
                showHideLeftPanel();
                fillAllSubjectsIntoArray();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Llena todas las asignaturas.\n
        ///             Fill all subjects. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="allSubjectsParam"> Todas las asignaturas.\n
        ///                                 all subjects parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillAllSubjects(string[] allSubjectsParam) {

            subjectPicture.Click += new EventHandler(subjectPicture_Click);
            createExamPicture.Click += new EventHandler(createExamPicture_Click);
            modelsPicture.Click += new EventHandler(modelsPicture_Click);
            changesPicture.Click += new EventHandler(changesPicture_Click);

            Label temLabel;
            showHideLeftPanel();
            for (int counter = 0; counter < allSubjectsParam.Length; counter++) {
                temLabel = (Label)allSubjectObjects[counter];
                temLabel.Text = allSubjectsParam[counter];
                temLabel.Visible = true;
            }


            for (int counter = 0; counter < allSubjectsParam.Length; counter++) {
                temLabel = (Label)allSubjectObjects[(counter + 5)];
                temLabel.Text = allSubjectsParam[counter];
                temLabel.Visible = true;
            }

            for (int counter = 0; counter < allSubjectsParam.Length; counter++) {
                temLabel = (Label)allSubjectObjects[(counter + 10)];
                temLabel.Text = allSubjectsParam[counter];
                temLabel.Visible = true;
            }

            for (int counterHideLabels = allSubjectsParam.Length; counterHideLabels < counterSubject; counterHideLabels++) {
                temLabel = (Label)allSubjectObjects[counterHideLabels];
                temLabel.Visible = false;
                temLabel = (Label)allSubjectObjects[counterHideLabels + 5];
                temLabel.Visible = false;
                temLabel = (Label)allSubjectObjects[counterHideLabels + 10];
                temLabel.Visible = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene todas las asignaturas.\n
        ///             Gets all subjects. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void getAllSubjects() {

            subjectPicture.Click -= new EventHandler(subjectPicture_Click);
            createExamPicture.Click -= new EventHandler(createExamPicture_Click);
            modelsPicture.Click -= new EventHandler(modelsPicture_Click);
            changesPicture.Click -= new EventHandler(changesPicture_Click);

            string jsonString = Utilities.generateSingleDataRequest("getAllSubjects", emailUser);

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Obtiene los parámetros de creación necesarios cuando se crea el identificador del control.\n
        /// Gets the necessary create parameters when creating the handle of the control.
        /// </summary>
        ///
        /// <value>
        /// <see cref="T:System.Windows.Forms.CreateParams" /> que contiene los parámetros de creación
        /// necesarios cuando se crea el identificador del control.\n
        /// <see cref = "T: System.Windows.Forms.CreateParams" /> containing the creation parameters
        /// required when creating the handle of the control.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override CreateParams CreateParams {
            get {
                const int WS_MAXIMIZEBOX = 0x00010000;
                var cp = base.CreateParams;
                cp.Style &= ~WS_MAXIMIZEBOX;
                return cp;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el label de cambios.\n
        ///             Click event about changes label. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object that active the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void labelChanges_Click(object sender, EventArgs e) {
            labelChanges.Click -= new EventHandler(labelChanges_Click);
            Utilities.openForm(new AskTypeDataChanges(dataPanel, rightDock, this, emailUser), dataPanel, rightDock);
        }

    }
}

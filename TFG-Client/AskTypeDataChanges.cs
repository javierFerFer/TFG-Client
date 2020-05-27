////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AskTypeDataChanges.cs </file>
///
/// <copyright file="AskTypeDataChanges.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AskTypeDataChanges.\n
///             Implements the ask type data changes class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
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
    /// <summary>   Clase que permite al usuario con credenciales elegir que tipo de datos desea ver.\n
    ///             Class that allow to the user select type of data to show if the user has permissions. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AskTypeDataChanges : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;

        private string emailUser;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="dataPanelParam">       Panel donde se muestran los datos del programa.\n
        ///                                     The data panel parameter that show all data of the program. </param>
        /// <param name="rightPanelParam">      Panel de la derecha del programa.\n
        ///                                     The right panel parameter. </param>
        /// <param name="beforeFormParam">      Panel anterior mostrado.\n
        ///                                     The before form parameter that was used to show data. </param>
        /// <param name="emailUserParam">       Email del profesor para comprobar sus credenciales.\n
        ///                                     Email of the teacher to check permissions.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AskTypeDataChanges(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, string emailUserParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            emailUser = emailUserParam;
            showHideElements(false);
            ConnectionWithServer.LoginForm.AskTypeDataChangesObject1 = this;
            typeOfDataPanel.Focus();

            // Comprobación de permisos por parte del usuario
            string jsonString = Utilities.generateSingleDataRequest("checkPermissions", emailUser);

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra al prrofesor un error si no tiene los credenciales necesarios para acceder a este apartado del programa.\n
        ///             Show error if the teacher doesn't have the permissions to access.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void createErrorCredentials() {
            labelWaitVerification.Text = "Usted no tiene los credenciales necesarios \n" +
                                         "para acceder a esta sección";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>  Muestra y esconde elementos visuales del formulario.\n
        ///            Show and hide elements of the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="option">   True = muestra elementos, false = esconde elementos.
        ///                         True = show elements of form, false = hide elements of form.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showHideElements(bool option) {
            labelAskTypeOfOperation.Visible = option;
            checkBoxTest.Visible = option;
            checkBoxNormal.Visible = option;
            buttonBack.Visible = option;
            nextButton.Visible = option;


            labelWaitVerification.Visible = !option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, carga el formulario anterior a este cuando es pulsado.\n
        ///             Click event about back button, load  beforeForm when user press this button.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(new EmptyDataForm(), dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón siguiente, cargar el formulario correspondiente según que checkBox esté marcado.\n
        ///             Click event about next buttton, load the specific form based on whitch checkBox is checked. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            // true = add selected, false = modify
            typeOfDataPanel.Focus();

            if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                if (checkBoxNormal.Checked) {
                    // Listado de preguntas de tipo normal con su correspondiente modificación pendiente
                    Utilities.openForm(new ListAllNormalQuestionsModifications(dataPanel, rightPanel, this), dataPanel, rightPanel);

                } else {
                    // Listado de preguntas de tipo test con su correspondiente modificación pendiente
                    Utilities.openForm(new ListAllTestQuestionsModifications(dataPanel, rightPanel, this), dataPanel, rightPanel);
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio sobre checkBox para modificaciones.\n
        ///             Change event about checkBox for to modifications. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxModify_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxTest.Checked) {
                checkBoxNormal.Checked = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio sobre checkBox para agregaciones.\n
        ///             Change event about checkBox for to add. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 21/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNormal.Checked) {
                checkBoxTest.Checked = false;
            }
        }
    }
}

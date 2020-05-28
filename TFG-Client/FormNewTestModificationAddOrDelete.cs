////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNewTestModificationAddOrDelete.cs </file>
///
/// <copyright file="FormNewTestModificationAddOrDelete.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNewTestModificationAddOrDelete.\n
///             Implements the form new test modification add or delete class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Formulario que permite denegar/aceptar peticiones de modificación/borrado de las preguntas de tipo test.\n
    ///             Form to accept/deny request of modify/delete type test questions. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNewTestModificationAddOrDelete : Form {

        private string id;

        public FormNewTestModificationAddOrDelete(string idParam) {
            InitializeComponent();
            id = idParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            pictureBoxSpaceBlack.Width -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar, al pulsado se cierra esta ventana.\n
        ///             Click event about close button, when this button is pressed, this form is closed </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void closeButton_Click(object sender, EventArgs e) {
            Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón enviar, cuando es pulsado se realiza una petición de actualización sobre la pregunta indicada.\n
        ///             Click event about send button, when this button is pressed, the program does a request to update the specific question with the data of the modification. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm("Los cambios que va a realizar son irreversibles ");
            if (userOption) {
                // Envio de actualización de la pregunta y borrado de esta modificación
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("updateTestModification", id);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.closeAllPopUps();
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón borrar, cuando es pulsado se realiza una petición de borrado sobre todas las modificaciones de la pregunta y la pregunta en sí.\n
        ///             Click event about delete button, when this button is pressed, the program does a request to delete all modifications of the question and the question itself. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonDelete_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm("Los cambios que va a realizar son irreversibles ");
            if (userOption) {
                // Envio de borrado de la pregunta, de todas las modificaciones de la misma y comprobación de modelos, en caso de existir modelo sin preguntas, borrar modelo
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("deleteTestQuestion", id);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.closeAllPopUps();
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
            Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón denegar, cuando es pulsado se realiza una petición de borrado sobre la modificación de la pregunta indicada.\n
        ///             Click event about deny button, when this button is pressed, the program does a request to delete the specific modification of the question. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonDeny_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm("Los cambios que va a realizar son irreversibles ");
            if (userOption) {
                // Envio de borrado de la modificación en concreto
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("deleteTestModification", id);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.closeAllPopUps();
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
            Dispose();
        }
    }
}

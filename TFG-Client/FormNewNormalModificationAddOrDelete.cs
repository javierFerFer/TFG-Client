////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNewNormalModificationAddOrDelete.cs </file>
///
/// <copyright file="FormNewNormalModificationAddOrDelete.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNewNormalModificationAddOrDelete.\n
///             Implements the form new normal modification add or delete class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Formulario que permite validar/denegar peticiones de modificación/borrado.\n
    ///             Form to validate/deny request of modify/delete questions </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNewNormalModificationAddOrDelete : Form {

        private string idModification;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
        ///
        /// <param name="idParam">  ID de la modificación.\n
        ///                         ID of modification. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModificationAddOrDelete(string idParam) {
            InitializeComponent();
            idModification = idParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar, al pulsado se cierra esta ventana.\n
        ///             Click event about close button, when this button is pressed, this form is closed </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
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
        /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm("Los cambios que va a realizar son irreversibles ");
            if (userOption) {
                // Envio de petición de modificación de la pregunta
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("updateNormalModification", idModification);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón denegar, cuando es pulsado se realiza una petición de borrado sobre la modificación de la pregunta indicada.\n
        ///             Click event about deny button, when this button is pressed, the program does a request to delete the specific modification of the question. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonDontAccept_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm("Los cambios que va a realizar son irreversibles ");
            if (userOption) {
                // Envio de petición de borrado de la susodicha modificación de la pregunta
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("deleteNormalModification", idModification);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón borrar, cuando es pulsado se realiza una petición de borrado sobre todas las modificaciones de la pregunta y la pregunta en sí.\n
        ///             Click event about delete button, when this button is pressed, the program does a request to delete all modifications of the question and the question itself. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 23/05/2020. </remarks>
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
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("deleteNormalQuestion", idModification);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
                Utilities.createWarningForm("Espere, por favor", "Se está procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }
    }
}

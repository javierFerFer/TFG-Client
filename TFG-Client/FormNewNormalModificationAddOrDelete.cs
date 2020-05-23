//============================================================================
// Name        : ModelWindowsMessage.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : This class is a model of windows that have:
//               - Tittle
//               - Message
//               - Image
//               - Close button
//============================================================================

/**
 * Todos los using de la clase
 * 
 * All using here
*/
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
    public partial class FormNewNormalModificationAddOrDelete : Form {

        private string idModification;

        public FormNewNormalModificationAddOrDelete(string idParam) {
            InitializeComponent();
            idModification = idParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        /// <summary>
        /// Evento de cierre del boton 'cerrar' de la ventana
        /// 
        /// Evento of close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e) {
            Dispose();
        }


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
                Utilities.createWarningForm("Espere, por favor", "Se esta procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }

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
                Utilities.createWarningForm("Espere, por favor", "Se esta procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }

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
                Utilities.createWarningForm("Espere, por favor", "Se esta procesando su solicitud,\n espere...");
                ConnectionWithServer.LoginForm.AskTypeDataChangesObject1.nextButton.PerformClick();
            }
        }
    }
}

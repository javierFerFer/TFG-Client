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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    partial class FormNewNormalModification : Form {

        string id;

        public FormNewNormalModification(string idParam) {
            InitializeComponent();
            id = idParam;
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
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBoxNewQuest.Text.Length > 90) {
                if (textBoxNewQuest.Text.Length == 91) {
                    textBoxNewQuest.Text = textBoxNewQuest.Text.Substring(0, textBoxNewQuest.Text.Length - 1);
                    textBoxNewQuest.Select(textBoxNewQuest.Text.Length, 0);
                    Utilities.customErrorInfoModificationNormal("Se ha alcanzado el límite máximo de caracteres en la pregunta");
                } else {
                    Utilities.customErrorInfoModificationNormal("El texto introducido supera el limite máximo de caracteres");
                    textBoxNewQuest.Text = "";
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                buttonSend.PerformClick();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            if (textBoxNewQuest.Text.Trim().Length != 0 && textBoxNewQuest.Text.Trim().Length >= 5) {
                // Enviar petición de guardado de la modificación
                string jsonMessageAddNewNormalModification = Utilities.generateJsonObjectArrayString("addNewNormalModification", new string[] { id, textBoxNewQuest.Text });
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
            } else {
                Utilities.customErrorInfoModificationNormal("Valor para la modificación inválido, recuerde que la longitud máxima es 90 \n" +
                                                            "y que la mínima es de 5 caracteres");
            }
        }
    }
}

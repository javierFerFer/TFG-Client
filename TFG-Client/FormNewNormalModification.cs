﻿////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNewNormalModification.cs </file>
///
/// <copyright file="FormNewNormalModification.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNewNormalModification.\n
///             Implements the form new normal modification class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Formulario que permite establecer los datos para la modificación de una pregunta de tipo normal.\n
    ///             Form to change normal question. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNewNormalModification : Form {

        private string id;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="idParam">  ID de la pregunta a modificar.\n
        ///                         The identifier parameter of the question to modify. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModification(string idParam) {
            InitializeComponent();
            id = idParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cancelar, cuando es pulsado, se avisa al usuario de posible perdida de datos y si acepta, se cierra este formulario.\n
        ///             Click event about cancel button, when this button is pressed, this program show an warning message, if the user continue anyway, this form will be closed</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void closeButton_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Dispose();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre  la caja de texto para la modificación, comprueba que el valor de la misma es válido.\n
        ///             Change text event about modification text box, check if the value of modification is valid or not.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox1_TextChanged(object sender, EventArgs e) {
            try {
                if (textBoxNewQuest.Text.Length > 230) {
                    if (textBoxNewQuest.Text.Length == 231) {
                        textBoxNewQuest.Text = textBoxNewQuest.Text.Substring(0, textBoxNewQuest.Text.Length - 1);
                        textBoxNewQuest.Select(textBoxNewQuest.Text.Length, 0);
                        Utilities.customErrorInfoModificationNormal("Se ha alcanzado el límite máximo de caracteres en la pregunta");
                    } else {
                        Utilities.customErrorInfoModificationNormal("El texto introducido supera el límite máximo de caracteres");
                        textBoxNewQuest.Text = "";
                    }
                }
            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón enviar, cuando se activa, se envia una petición al servidor para modificar/borrar la pregunta seleccionada.\n
        ///             Click event about send button, when this button is pressed, the program send to request to modify/delete this question. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                // Enviar petición de guardado de la modificación
                string jsonMessageAddNewNormalModification = Utilities.generateJsonObjectArrayString("addNewNormalModification", new string[] { id, "null" });
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
            } else {
                if (textBoxNewQuest.Text.Trim().Length != 0 && textBoxNewQuest.Text.Trim().Length >= 5 && textBoxNewQuest.Text.Trim() != "Borrar") {
                    // Enviar petición de guardado de la modificación
                    string jsonMessageAddNewNormalModification = Utilities.generateJsonObjectArrayString("addNewNormalModification", new string[] { id, textBoxNewQuest.Text });
                    byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                    ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                    // Envio de datos mediante flush
                    ConnectionWithServer.ServerStream.Flush();
                    Dispose();
                } else {
                    if (textBoxNewQuest.Text.Trim() == "Borrar") {
                        Utilities.customErrorInfoModificationNormal("Valor no permitido como modificación");
                    } else {
                        Utilities.customErrorInfoModificationNormal("Valor para la modificación inválido, recuerde que la longitud máxima es 90 \n" +
                                                                   "y que la mínima es de 5 caracteres");
                    }

                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de checkBox, comprueba si el checkBox para borrar la pregunta está marcado o no.\n
        ///             CheckBox event, check if this checkBox for to delete the question is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                textBoxNewQuest.Visible = false;
                labelInfoNewModification.Visible = false;
            } else {
                textBoxNewQuest.Visible = true;
                labelInfoNewModification.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de tecla presionada, comprueba si el usuario ha pulsado la tecla ENTER, en dicho caso, omite la pulsación.\n
        ///             Key press event, if the key = ENTER, avoid this press. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Evento de la tecla pulsada.\n
        ///                         Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNewQuest_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }
    }
}

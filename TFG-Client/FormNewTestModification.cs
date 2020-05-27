////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNewTestModification.cs </file>
///
/// <copyright file="FormNewTestModification.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNewTestModification.\n
///             Implements the form new test modification class. </summary>
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
    /// <summary>   Permite la modificación/borrado de preguntas tipo test.\n
    ///             Allow to modify/delete type test questions</summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNewTestModification : Form {

        private string id;
        private string question;
        private string answer_A;
        private string answer_B;
        private string answer_C;
        private string answer_D;
        private string answer_correct;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="idParam">              ID de la pregunta.\n
        ///                                     The identifier parameter. </param>
        /// <param name="questionParam">        Pregunta a modificar/borrar\n
        ///                                     Question to modify/delete. </param>
        /// <param name="answer_A_param">       Respuesta A de la pregunta.\n
        ///                                     Answer A of the question. </param>
        /// <param name="answer_B_param">       Respuesta B de la pregunta.\n
        ///                                     Answer B of the question. </param>
        /// <param name="answer_C_param">       Respuesta C de la pregunta.\n
        ///                                     Answer C of the question. </param>
        /// <param name="answer_D_param">       Respuesta D de la pregunta.\n
        ///                                     Answer D of the question. </param>
        /// <param name="answer_correct_param"> Respuesta correccta de la pregunta.\n
        ///                                     Correct answer of the question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewTestModification(string idParam, string questionParam, string answer_A_param, string answer_B_param, string answer_C_param, string answer_D_param, string answer_correct_param) {
            InitializeComponent();
            id = idParam;
            question = questionParam;
            answer_A = answer_A_param;
            answer_B = answer_B_param;
            answer_C = answer_C_param;
            answer_D = answer_D_param;
            answer_correct = answer_correct_param;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            pictureBoxSpaceBlack.Width -= 9;
            comboBoxCorrectAnswer.SelectedIndex = comboBoxCorrectAnswer.FindStringExact("A");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar del formulario, cuando este es pulsado, se advierte al usuario de la posible perdida de datos,
        ///             si continua, este formulario es cerrado.\n
        ///             Click event about close button, if this button is pressed, this event create and show warning form. If the user continue anyway, this form will be close. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
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
        /// <summary>   Evento de click sobre el botón enviar. Cuando es pulsado, se realiza una petición de modificación/borrado sobre la pregunta.\n
        ///             Click event about send button, when user press this button, this event does a request to update/delete this question.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                // Petición de borrado a esta pregunta
                string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("addNewTestModification", new string[] { id, "null", "null", "null", "null", "null", "null" });
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
                Dispose();
            } else {
                if (textBoxNewAnserA.Text.Trim().Length < 5 || textBoxNewAnserA.Text.Trim().Length == 0 || textBoxNewAnserA.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la respuesta 'A' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserB.Text.Trim().Length < 5 || textBoxNewAnserB.Text.Trim().Length == 0 || textBoxNewAnserB.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la respuesta 'B' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserC.Text.Trim().Length < 5 || textBoxNewAnserC.Text.Trim().Length == 0 || textBoxNewAnserC.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la respuesta 'C' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserD.Text.Trim().Length < 5 || textBoxNewAnserD.Text.Trim().Length == 0 || textBoxNewAnserD.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la respuesta 'D' debe ser entre 5 y 45 carateres");
                } else {
                    // Petición de envio de modificación de datos
                    if (textBoxNewQuest.Text.Trim().Length != 0 && textBoxNewQuest.Text.Trim().Length >= 5) {
                        string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("addNewTestModification", new string[] { id, textBoxNewQuest.Text, textBoxNewAnserA.Text, textBoxNewAnserB.Text, textBoxNewAnserC.Text, textBoxNewAnserD.Text, comboBoxCorrectAnswer.SelectedItem.ToString() });
                        byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                        ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                        // Envio de datos mediante flush
                        ConnectionWithServer.ServerStream.Flush();
                        Dispose();
                    } else {
                        Utilities.customErrorInfoModificationNormal("la longitud de la pregunta debe ser entre 5 y 45 carateres");
                    }
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de checkBox, comprueba si el mismo está marcado o no.\n
        ///             CheckBox change event, check if itselft is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxDelete_CheckedChanged_1(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                showHideElements(false);
            } else {
                showHideElements(true);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde elementos de la interfaz.\n
        ///             Show/hide elements of the interface. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="option">   True = muestra elementos, false = esconde elementos.\n
        ///                         True = show elements, false = hide elements. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void showHideElements(bool option) {
            labelInfoModifications.Visible = option;
            labelNewQuest.Visible = option;
            textBoxNewQuest.Visible = option;
            labelNewAnserA.Visible = option;
            textBoxNewAnserA.Visible = option;
            labelNewAnserB.Visible = option;
            textBoxNewAnserB.Visible = option;
            labelNewAnserC.Visible = option;
            textBoxNewAnserC.Visible = option;
            labelNewAnserD.Visible = option;
            textBoxNewAnserD.Visible = option;
            labelNewAnserCorrect.Visible = option;
            comboBoxCorrectAnswer.Visible = option;
        }
    }
}

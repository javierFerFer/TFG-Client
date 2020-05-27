////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNewNormalModificationForModel.cs </file>
///
/// <copyright file="FormNewNormalModificationForModel.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNewNormalModificationForModel.\n
///             Implements the form new normal modification for model class. </summary>
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
    /// <summary>   Permite la modificación/borrado de preguntas de tipo normal al usar un modelo específico para generar un examen.\n
    ///             Allow to modify/delete question when the user will be to use a model to generate a normal exam. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNewNormalModificationForModel : Form {

        private string id;
        private string question;
        private DataGridViewRow dataGridViewRow;
        private DataGridView dataGridView;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="idParam">              ID de la pregunta a modificar/borrar.\n
        ///                                     ID of the question to modify/delete </param>
        /// <param name="questionParam">        Pregunta a modificar/borrar.\n
        ///                                     Question to modify/delete. </param>
        /// <param name="dataGridViewRowParam"> fila con los datos de la pregunta a modificar.\n
        ///                                     Row with all data of question to modify/delete </param>
        /// <param name="dataGridViewParam">    Lista con las preguntas del modelo a usar.\n
        ///                                     List with all data of questions of the model. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNewNormalModificationForModel(string idParam, string questionParam, DataGridViewRow dataGridViewRowParam, DataGridView dataGridViewParam) {
            InitializeComponent();
            id = idParam;
            question = questionParam;
            dataGridViewRow = dataGridViewRowParam;
            dataGridView = dataGridViewParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            labelQuestionInfo.Text = question;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar del formulario, cuando este es pulsado, se advierte al usuario de la posible perdida de datos,
        ///             si continua, este formulario es cerrado.\n
        ///             Click event about close button, if this button is pressed, this event create and show warning form. If the user continue anyway, this form will be close. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
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
        /// <summary>   Evento de modificación del texto sobre la caja de texto que contiene la modificación de la pregunta, verifica si el contenido de la misma es válido o no.\n
        ///             Event to chage text about modification text box, check if this modification is valid or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
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
                        Utilities.customErrorInfoModificationNormal("El texto introducido supera el limite máximo de caracteres");
                        textBoxNewQuest.Text = "";
                    }
                }
            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón modificar. Cuando es pulsado, se actualiza el objeto DataGridView.\n
        ///             Click event about modify button, when user press this button, this event update the content of the DataGridView object </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                if (dataGridView.Rows.Count == 1) {
                    Utilities.customErrorInfoModificationNormal("El modelo debe tener al menos 1 pregunta asociada,\n no se pueden borrar más preguntas");

                } else {
                    // Enviar petición de guardado de la modificación
                    dataGridView.Rows.Remove(dataGridViewRow);
                    Dispose();
                }

            } else {
                if (textBoxNewQuest.Text.Trim().Length != 0 && textBoxNewQuest.Text.Trim().Length >= 5) {
                    // Enviar petición de guardado de la modificación
                    dataGridViewRow.Cells[1].Value = textBoxNewQuest.Text;
                    Dispose();
                } else {
                    Utilities.customErrorInfoModificationNormal("Valor para la modificación inválido, recuerde que la longitud máxima es 90 \n" +
                                                                "y que la mínima es de 5 caracteres");
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de checkBox, comprueba si el mismo está marcado o no.\n
        ///             CheckBox change event, check if itselft is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
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
        /// <summary>   Evento de presión de tecla. Comprueba si la tecla presionada es ENTER, en dicho caso, la omite.\n
        ///             KeyDown press event, check if the key is ENTER, in this case, avoid. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de presión de tecla.\n
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

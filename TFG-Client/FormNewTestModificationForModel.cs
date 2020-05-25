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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class FormNewTestModificationForModel : Form {

        private string id;
        private string question;
        private string answer_A;
        private string answer_B;
        private string answer_C;
        private string answer_D;
        private string answer_correct;
        private DataGridViewRow dataGridViewRowObject;
        private DataGridView datagridViewObject;



        public FormNewTestModificationForModel(string idParam, string questionParam, string answer_A_param, string answer_B_param, string answer_C_param, string answer_D_param, string answer_correct_param, DataGridViewRow tempRowParam, DataGridView allQuestionsParam) {
            InitializeComponent();
            id = idParam;
            question = questionParam;
            labelQuestion.Text += question;
            answer_A = answer_A_param;
            labelAnswerA.Text += answer_A;
            answer_B = answer_B_param;
            labelAnswerB.Text += answer_B;
            answer_C = answer_C_param;
            labelAnswerC.Text += answer_C;
            answer_D = answer_D_param;
            labelAnswerD.Text += answer_D;
            answer_correct = answer_correct_param;
            labelAnswerCorrect.Text += answer_correct;
            datagridViewObject = allQuestionsParam;
            dataGridViewRowObject = tempRowParam;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            pictureBoxSpaceBlack.Width -= 9;
            comboBoxCorrectAnswer.SelectedIndex = comboBoxCorrectAnswer.FindStringExact("A");
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


        private void buttonSend_Click(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                // Borrado

                if (datagridViewObject.Rows.Count == 1) {
                    Utilities.customErrorInfoModificationNormal("El modelo debe tener al menos 1 pregunta asociada,\n no se pueden borrar más preguntas");

                } else {
                    // Enviar petición de guardado de la modificación
                    datagridViewObject.Rows.Remove(dataGridViewRowObject);
                    Dispose();
                }

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
                        // Modificación
                        dataGridViewRowObject.Cells[1].Value = textBoxNewQuest.Text;
                        dataGridViewRowObject.Cells[2].Value = textBoxNewAnserA.Text;
                        dataGridViewRowObject.Cells[3].Value = textBoxNewAnserB.Text;
                        dataGridViewRowObject.Cells[4].Value = textBoxNewAnserC.Text;
                        dataGridViewRowObject.Cells[5].Value = textBoxNewAnserD.Text;
                        dataGridViewRowObject.Cells[6].Value = comboBoxCorrectAnswer.SelectedItem.ToString();
                        Dispose();      
                    } else {
                        Utilities.customErrorInfoModificationNormal("la longitud de la pregunta debe ser entre 5 y 45 carateres");
                    }
                }
            }

        }

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                textBoxNewQuest.Visible = false;
            } else {
                textBoxNewQuest.Visible = true;
            }
        }

        private void checkBoxDelete_CheckedChanged_1(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                showHideElements(false);
            } else {
                showHideElements(true);
            }
        }

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

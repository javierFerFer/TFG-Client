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
    public partial class FormNewTestModification : Form {

        private string id;
        private string question;
        private string answer_A;
        private string answer_B;
        private string answer_C;
        private string answer_D;
        private string answer_correct;



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
                // Petición de borrado a esta pregunta
            } else {
                if (textBoxNewAnserA.Text.Trim().Length < 5 || textBoxNewAnserA.Text.Trim().Length == 0 || textBoxNewAnserA.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la pregunta 'A' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserB.Text.Trim().Length < 5 || textBoxNewAnserB.Text.Trim().Length == 0 || textBoxNewAnserB.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la pregunta 'B' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserC.Text.Trim().Length < 5 || textBoxNewAnserC.Text.Trim().Length == 0 || textBoxNewAnserC.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la pregunta 'C' debe ser entre 5 y 45 carateres");
                } else if (textBoxNewAnserD.Text.Trim().Length < 5 || textBoxNewAnserD.Text.Trim().Length == 0 || textBoxNewAnserD.Text.Trim().Length > 45) {
                    Utilities.customErrorInfoModificationNormal("la longitud de la pregunta 'D' debe ser entre 5 y 45 carateres");
                } else {
                    // Petición de envio de modificación de datos
                    // AQUIII
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

        private void textBoxNewQuest_TextChanged(object sender, EventArgs e) {
            MessageBox.Show(textBoxNewQuest.Text.Length.ToString());
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

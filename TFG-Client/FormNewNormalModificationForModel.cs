﻿//============================================================================
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
    public partial class FormNewNormalModificationForModel : Form {

        private string id;
        private string question;
        private DataGridViewRow dataGridViewRow;
        private DataGridView dataGridView;

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
            } catch (Exception) {}
        }


        private void buttonSend_Click(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                if (dataGridView.Rows.Count <= 5) {
                    Utilities.customErrorInfoModificationNormal("El modelo tiene 5 o menos preguntas asociadas,\n no se pueden borrar más preguntas");

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

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDelete.Checked) {
                textBoxNewQuest.Visible = false;
                labelInfoNewModification.Visible = false;
            } else {
                textBoxNewQuest.Visible = true;
                labelInfoNewModification.Visible = true;
            }
        }

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

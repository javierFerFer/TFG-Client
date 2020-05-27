////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormTestModifications.cs </file>
///
/// <copyright file="FormTestModifications.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormTestModification.\n
///             Implements the form test modifications class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Lista todas las preguntas de tipo test que contienen modificaciones.\n
    ///             Show all test question that have one or more modifications. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormTestModifications : Form {
        private string[] allQuestions;
        private Panel dataPanel;
        private Panel rightPanel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="allQuestionsParam">    Todas las preguntas.\n
        ///                                     all questions parameter. </param>
        /// <param name="dataPanelParam">       Panel donde se muestran los datos.\n
        ///                                     Panel where this program show all data. </param>
        /// <param name="rightPanelParam">      Panel de la derecha.\n
        ///                                     Right panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormTestModifications(string[] allQuestionsParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            allQuestions = allQuestionsParam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar del formulario, cuando este es pulsado, este formulario es cerrado.\n
        ///             Click event about close button, if this button is pressed, this form will be close. </summary>
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
        /// <summary>   Rellena la lista de preguntas de tipo test.\n
        ///             Tests fill questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal void fillQuestionsTest() {

            for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter += 8) {
                bool checkIfDeleteMod = false;
                object[] row;
                if (allQuestions[questionCounter + 2].Equals("null")) {
                    checkIfDeleteMod = true;
                }
                if (allQuestions[questionCounter + 3].Equals("null")) {
                    checkIfDeleteMod = true;
                }
                if (allQuestions[questionCounter + 4].Equals("null")) {
                    checkIfDeleteMod = true;
                }
                if (allQuestions[questionCounter + 5].Equals("null")) {
                    checkIfDeleteMod = true;
                }
                if (allQuestions[questionCounter + 6].Equals("null")) {
                    checkIfDeleteMod = true;
                }
                if (allQuestions[questionCounter + 7].Equals("null")) {
                    checkIfDeleteMod = true;
                }

                if (!checkIfDeleteMod) {
                    row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 2], allQuestions[questionCounter + 3], allQuestions[questionCounter + 4], allQuestions[questionCounter + 5], allQuestions[questionCounter + 6], allQuestions[questionCounter + 7], "NO" };
                } else {
                    row = new object[] { allQuestions[questionCounter], " ", " ", " ", " ", " ", " ", "SI" };
                }

                dataGridViewTestData.Rows.Add(row);

                if (checkIfDeleteMod) {
                    int index = dataGridViewTestData.Rows.Count - 1;
                    dataGridViewTestData.Rows[index].Cells[0].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[1].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[2].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[3].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[4].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[5].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[6].Style.BackColor = Color.Red;
                    dataGridViewTestData.Rows[index].Cells[7].Style.BackColor = Color.Red;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cell mouse enter, cuando se activa, muestra los datos referentes a la pregunta seleccionada en la fila.\n
        /// Event of cell mouse enter, when the user active this event, this event show all data of the selected question in selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewTestData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!tempRow.Cells[7].Value.ToString().Equals("SI")) {
                    cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                    + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();
                }

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada, cuando se activa este evento, se crea un formulario con las modificaciones/peticiones de borrado
        /// de la pregunta.\n
        /// Double click event about selected cell, when this event is activated, this event create a form to show all modify/delete request of this question.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 24/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private async void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

            string[] dataOfMod = new string[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString() };

            string idReference = tempRow.Cells[0].Value.ToString();

            if (tempRow.Cells[7].Value.ToString().Equals("SI")) {
                // Petición de borrado
                await Task.Run(() => { Utilities.createFormNewTestModificationAddOrDelete("Datos de la modificación", idReference, ConnectionWithServer.LoginForm.ListAllTestQuestionsModificationsObject.allDataSelectedQuestion, dataOfMod, true); });
            } else {
                // Petición de modificación
                await Task.Run(() => { Utilities.createFormNewTestModificationAddOrDelete("Datos de la modificación", idReference, ConnectionWithServer.LoginForm.ListAllTestQuestionsModificationsObject.allDataSelectedQuestion, dataOfMod, false); });
            }
        }
    }
}

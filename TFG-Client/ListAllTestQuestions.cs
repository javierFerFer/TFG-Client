////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\ListAllTestQuestions.cs </file>
///
/// <copyright file="ListAllTestQuestions.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase ListAllTestQuestions.\n
///             Implements the list all test questions class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Lista todas las preguntas de tipo test asociadas a un tema.\n
    ///             List all test questions of the specific theme </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ListAllTestQuestions : Form {
        string nameOfSubject;
        Panel dataPanel;
        Panel rightPanel;
        Form beforeForm;
        string[] allDataOnView;
        private const string searchBanner = "Nombre de la pregunta a buscar...";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="nameOfSubjectParam">   Nombre del tema seleccionado.\n
        ///                                     Name of the subject parameter. </param>
        /// <param name="dataPanelParam">       Panel donde el programa muestra los datos.\n
        ///                                     Panel where this program show all data. </param>
        /// <param name="rightPanelParam">      Panel derecho del programa.\n
        ///                                     Right panel. </param>
        /// <param name="beforeFormParam">      Panel anterior.\n
        ///                                     The before form parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListAllTestQuestions(string nameOfSubjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            nameOfSubject = nameOfSubjectParam;
            ConnectionWithServer.LoginForm.ListAllTestQuestions = this;
            errorNoQuestionsFound.Text = "Esperando datos del servidor...";
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            errorNoQuestionsFound.Visible = true;
            textBoxFindQuestion.Visible = false;
            searchButton.Visible = false;
            resetButton.Visible = false;
            buttonBack.Visible = false;
            beforeForm = beforeFormParam;
            pictureBoxSearchQuestion.Visible = false;
            dataGridViewTestData.Visible = false;
            getAllTestQuestions();
            panelAllData.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Esconde/muestra elementos de la interfaz.\n
        ///             Hide/show elements of the interface. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="option">   True = muestra elementos, false = esconde elementos.\n
        ///                         True = show elements, false = hide elements. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void hide_show_dataGridView(bool option) {
            Thread.Sleep(2000);
            pictureBoxSearchQuestion.Visible = option;
            dataGridViewTestData.Visible = option;
            textBoxFindQuestion.Visible = option;
            searchButton.Visible = option;
            resetButton.Visible = option;
            if (option) {
                errorNoQuestionsFound.Visible = false;
                buttonBack.Visible = true;
            } else {
                errorNoQuestionsFound.Text = "No se han encontrado preguntas de tipo test asociadas a la asignatura";
                errorNoQuestionsFound.Visible = true;
                buttonBack.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Avisa al usuario de que la petición de modificación/borrado se procesó correctamente.\n
        ///             Alert to the user that request to modify/delete was sent success</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void openSuccessAddModificationNormalQuest() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de modificación al sistema"), dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene todas las preguntas de tipo test.\n
        ///             Get all tests questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void getAllTestQuestions() {
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestQuestionsSpecificNameOfSUbject", nameOfSubject);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el objeto dataGridView con las preguntas recibidas.\n
        ///             Fill data grid view. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="allDataParam"> Todas las preguntas.\n
        ///                             All questions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillDataGridView(string[] allDataParam) {
            allDataOnView = allDataParam;
            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], allDataParam[questionCounter + 2], allDataParam[questionCounter + 3], allDataParam[questionCounter + 4], allDataParam[questionCounter + 5], allDataParam[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Rellena el objeto dataGridView con las preguntas recibidas.\n 
        /// Fill data grid view.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="allDataParamObjects">  Todas las preguntas.\n
        ///                                     All questions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString() };
                dataGridViewTestData.Rows.Add(row);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Rellena el objeto dataGridView con las preguntas.\n
        /// Fill data grid view.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter++) {
                object[] row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], allDataOnView[questionCounter + 2], allDataOnView[questionCounter + 3], allDataOnView[questionCounter + 4], allDataOnView[questionCounter + 5], allDataOnView[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de foco sobre el buscador de preguntas.\n
        ///             Get focus event about searcher of the questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_Enter(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == searchBanner) {
                textBoxFindQuestion.Text = "";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de perdida de foco sobre el buscador de preguntas.\n
        ///             Lost focus event about searcher of the questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_Leave(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == "") {
                textBoxFindQuestion.Text = searchBanner;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón buscar, cuando es pulsado, se busca en el DataGridView las preguntas que coincidan con el texto de la caja del buscador.\n
        ///             Click event about search button, when this button is pressed, search in DataGridView the question that equal to the text on search box. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void searchButton_Click(object sender, EventArgs e) {
            ArrayList removedRows = new ArrayList();

            resetButton.PerformClick();
            if (textBoxFindQuestion.Text != searchBanner) {
                foreach (DataGridViewRow row in dataGridViewTestData.Rows) {
                    if (row.Cells[1].Value.ToString().ToLower().Contains(textBoxFindQuestion.Text.ToLower())) {
                        DataGridViewRow tempRow = row;
                        removedRows.Add(tempRow);
                    }
                }

                dataGridViewTestData.Rows.Clear();

                fillDataGridView(removedRows);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de key press, cuando se activa, comprueba si la tecla pulsada es ENTER, en dicho caso, omite la pulsación.\n
        ///             Key press event, when this event is activated, check if the key is ENTER, in this case, avoid. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de key press.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                searchButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón reset, restea las preguntas del DataGridView.\n
        ///             Click event about reset button, reset DataGridView with all questions.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void resetButton_Click(object sender, EventArgs e) {
            dataGridViewTestData.Rows.Clear();
            fillDataGridView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, cuando es pulsado, carga el formulario beforeForm.\n
        ///             Click event about back button, when this button is pressed, load this form: beforeForm. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            panelAllData.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre el buscador de preguntas, cuando se activa, simula una pulsación sobre el botón buscar.\n
        ///             Text change event about searcher box text, when this event is activated, simulate press search button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada, cuando se activa este evento, se crea un formulario para la modificación/borrado.\n
        /// Double click event about selected cell, when this event is activated, this event create a form to modify/delete this question.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Petición de modificación

            DataGridViewSelectedRowCollection selectedRow = dataGridViewTestData.SelectedRows;
            DataGridViewRow rowSelectedByUser = selectedRow[0];
            Utilities.createFormNewTestModification("Petición de modificación", rowSelectedByUser.Cells[0].Value.ToString(), rowSelectedByUser.Cells[1].Value.ToString(), rowSelectedByUser.Cells[2].Value.ToString(), rowSelectedByUser.Cells[3].Value.ToString(), rowSelectedByUser.Cells[4].Value.ToString(), rowSelectedByUser.Cells[5].Value.ToString(), rowSelectedByUser.Cells[6].Value.ToString());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cell mouse enter, cuando se activa, muestra los datos referentes a la pregunta seleccionada en la fila.\n
        /// Event of cell mouse enter, when the user active this event, this event show all data of the selected question in selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
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
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
                // another cell in the same row (see my note below).
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString()
                   + "\r\n" + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString()
                   + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString()
                  + "\r\n" + "\r\n" + "- Opción correcta: \r\n" + tempRow.Cells[6].Value.ToString();
            } catch (Exception) { }
        }
    }
}

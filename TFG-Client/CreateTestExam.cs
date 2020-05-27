////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\CreateTestExam.cs </file>
///
/// <copyright file="CreateTestExam.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase CreateTestExam.\n
///             Implements the create test exam class. </summary>
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
    /// <summary>   Permite crear examenes de tipo test.\n
    ///             Allow to create test exams. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class CreateTestExam : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string themeSelected;
        private string typeOfExam;
        private ArrayList allQuestionData = new ArrayList();

        // True muestra preguntas que no estén en modelos, false muestra preguntas que están en modelos
        private bool saveAsModel;

        string[] allDataOnView;
        private const string searchBanner = "Nombre de la pregunta a buscar...";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">      Tipo de examen.\n
        ///                                     Type of the exam parameter. </param>
        /// <param name="themeSelectedParam">   Tema seleccionado para hacer el examen.\n
        ///                                     The theme selected parameter. </param>
        /// <param name="dataPanelParam">       Panel donde el programa muestra los datos.\n
        ///                                     The data panel parameter that the program show all data. </param>
        /// <param name="rightPanelParam">      Panel derecho del programa.\n
        ///                                     The right panel parameter. </param>
        /// <param name="beforeFormParam">      Panel anterior.\n
        ///                                     The before form parameter. </param>
        /// <param name="saveAsModelParam">     True si se va a guardar el modelo de examen, false en caso contrario.\n
        ///                                     True if the program will save the model of the exam, false in the opposite case.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CreateTestExam(string typeOfExamParam, string themeSelectedParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, bool saveAsModelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            themeSelected = themeSelectedParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            ConnectionWithServer.setCreateTestExam(this);
            showHideElements(false);
            showHideBackButton(false);
            showHideLabelWait(true);
            showHideErrorMessage(false);
            saveAsModel = saveAsModelParam;
            getAllTestQuestionsSpecificTheme();
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene todas las preguntas de tipo test de un tema en específico.\n
        ///             Gets all test questions specific theme. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void getAllTestQuestionsSpecificTheme() {
            string jsonMessageGetThemes = "";
            jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestQuestionsSpecificTheme", themeSelected);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, carga el beforeForm cuando es pulsado.\n
        ///             Click event about back button, load beforeForm when this button is pressed.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (buttonSend.Visible) {
                bool userOption = Utilities.createWarningForm();
                if (userOption) {
                    Utilities.openForm(beforeForm, dataPanel, rightPanel);
                }
            } else {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Esconde o muestra elementos de la interfaz.\n
        ///             Show/hide elements of the panel. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="option">   True = muestra elementos, false = esconde elementos.\n
        ///                         True = show elements, false = hide elements. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showHideElements(bool option) {
            textBoxFindQuestion.Visible = option;
            pictureBoxSearchQuestion.Visible = option;
            searchButton.Visible = option;
            resetButton.Visible = option;
            dataGridViewTestData.Visible = option;
            labelInfoMyQuestions.Visible = option;
            dataGridViewMyQuestions.Visible = option;
            buttonBack.Visible = option;
            buttonSend.Visible = option;
            labelListAllQuestions.Visible = option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde el label labelWaitQuestions.\n
        ///             Show/hide labelWaitQuestions element. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="option">
        /// True = muestra elemento, false = esconde elemento.\n
        ///  True = show element, false = hide element.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showHideLabelWait(bool option) {
            labelWaitQuestions.Visible = option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde el label errorNoQuestionsFound.\n
        ///             Show/hide errorNoQuestionsFound element. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="option">
        /// True = muestra elemento, false = esconde elemento.\n
        ///  True = show element, false = hide element.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showHideErrorMessage(bool option) {
            errorNoQuestionsFound.Visible = option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra/esconde el botón buttonBack.\n
        ///             Show/hide buttonBack element. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="option">
        /// True = muestra elemento, false = esconde elemento.\n
        ///  True = show element, false = hide element.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showHideBackButton(bool option) {
            buttonBack.Visible = option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón buscar, busca la pregunta dentro del DataGridView que coincida con lo escrito en el buscador.\n
        ///             Click event about search button, search the question that equal to text in the searcher into the DataGridView </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
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
        /// <summary>   Rellena el DataGridView con las preguntas.\n
        ///             Fill data grid view. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="allDataParamObjects">  Todas las preguntas.\n
        ///                                     all questions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString() };
                dataGridViewTestData.Rows.Add(row);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón siguiente, comprueba que el usuario haya elegido al menos una pregunta y envia una petición para generar el examen.\n
        ///             Click event about send button, check if the user select 1 or more questions and send request to generate the exam. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (dataGridViewMyQuestions.Rows.Count < 1) {
                // Error, al menos el examen debe poseer 5 preguntas
                Utilities.customErrorInfo("Debe seleccionar al menos 1 pregunta para poder continuar");
            } else if (dataGridViewMyQuestions.Rows.Count > 100) {
                // Error, el examen no puede de tipo normal no puede tener más de 30 preguntas
                Utilities.customErrorInfo("No puede seleccionar más de 100 preguntas para un examen");
            } else {
                // Petición de creación de examen
                allQuestionData = new ArrayList();

                for (int counter = 0; counter < dataGridViewMyQuestions.Rows.Count; counter++) {
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[0].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[1].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[2].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[3].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[4].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[5].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[6].Value.ToString());
                }

                if (saveAsModel) {
                    Utilities.openForm(new AllDataTestModel(typeOfExam, themeSelected, allQuestionData, dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    // Aquí versión sin salvar el modelo del examen
                    Utilities.openForm(new EmptyDataForm("Generando examen..."), dataPanel, rightPanel);
                    generateFilesExam();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que se lanza cuando el servidor contesta que se ha generado correctamente el examen.\n
        ///             Normal exam generate success event. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void testExamGenerateSuccess() {
            Thread.Sleep(6000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendTestExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de generación de examen de tipo test.\n
        ///             Generates the test exam file request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void generateFilesExam() {

            allQuestionData.Add(themeSelected);
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createTestExamFiles", tempArray);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de obtención del foco en el buscador de preguntas.\n
        ///             Get focus event on searcher text box. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
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
        /// <summary>   Evento de pérdida de foco en el buscador de preguntas</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_Leave(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == "") {
                textBoxFindQuestion.Text = searchBanner;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de modificación de texto sobre el buscador.\n
        ///             Modify text event about searcher text box. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón reset, muestra todas las preguntas en el DataGridView independientemente del texto en el buscador.\n
        ///             Click event about reset button, show all questions in DataGridView. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
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
        /// <summary>   Rellena el DataGridView con las preguntas.\n 
        ///             Fill data grid view. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="allDataParam"> Todas las preguntas.\n
        ///                             all data parameter. </param>
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
        /// <summary>   Rellena el DataGridView con las preguntas.\n 
        ///             Fill data grid view. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter++) {
                object[] row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], allDataOnView[questionCounter + 2], allDataOnView[questionCounter + 3], allDataOnView[questionCounter + 4], allDataOnView[questionCounter + 5], allDataOnView[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cellMouseEnter, se activa cuando el ratón pasa sobre una celda del DataGridView y muestra los datos de la fila seleccionada.\n
        /// CellMouseEnter event, when user pass the mouse over the cell in dataGridView, this event show all data of selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Data grid view cell event information </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewTestData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                    + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cellMouseEnter, se activa cuando el ratón pasa sobre una celda del DataGridView y muestra los datos de la fila seleccionada.\n
        /// CellMouseEnter event, when user pass the mouse over the cell in dataGridView, this event show all data of selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Data grid view cell event information </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewMyQuestions_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                   + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada en el DataGridView, cuando esta se activa, pasa todos los datos de la fila seleccionada al DataGridView con
        /// las preguntas que van a componer el examen.\n
        ///  Double-click event on the selected cell in DataGridView, when activated, passes all the data of the selected row to the DataGridView with
        /// the questions that will make up the exam.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {

                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                tempView.Rows.Remove(tempRow);


                for (int counter = 0; counter < allDataOnView.Length; counter++) {
                    if (allDataOnView[counter] == tempRow.Cells[0].Value.ToString()) {
                        int numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[0].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[1].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[2].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[3].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[4].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[5].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                        numIndex = Array.IndexOf(allDataOnView, tempRow.Cells[6].Value.ToString());
                        allDataOnView = allDataOnView.Where((val, idx) => idx != numIndex).ToArray();
                    }
                }

                dataGridViewMyQuestions.Rows.Add(tempRow);

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada en el DataGridView, cuando esta se activa, pasa todos los datos de la fila seleccionada al DataGridView con
        /// las preguntas disponibles para el examen.\n
        ///  Double-click event on the selected cell in DataGridView, when activated, passes all the data of the selected row to the DataGridView with
        /// the all posible questions for the exam.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 12/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewMyQuestions_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                tempView.Rows.Remove(tempRow);


                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[0].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[1].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[2].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[3].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[4].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[5].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[6].Value.ToString();

                dataGridViewTestData.Rows.Add(tempRow);


            } catch (Exception) { }
        }
    }
}

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

        private void getAllTestQuestionsSpecificTheme() {
            string jsonMessageGetThemes = "";
                jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestQuestionsSpecificTheme", themeSelected);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

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

        public void showHideLabelWait(bool option) {
            labelWaitQuestions.Visible = option;
        }

        public void showHideErrorMessage(bool option) {
            errorNoQuestionsFound.Visible = option;
        }

        public void showHideBackButton(bool option) {
            buttonBack.Visible = option;
        }

        private void searchButton_Click(object sender, EventArgs e) {
            ArrayList removedRows = new ArrayList();

            resetButton.PerformClick();
            if (textBoxFindQuestion.Text != searchBanner) {
                foreach (DataGridViewRow row in dataGridViewTestData.Rows) {
                    //MessageBox.Show(row.Cells[1].Value.ToString().ToLower());
                    if (row.Cells[1].Value.ToString().ToLower().Contains(textBoxFindQuestion.Text.ToLower())) {
                        DataGridViewRow tempRow = row;
                        removedRows.Add(tempRow);
                    }
                }

                dataGridViewTestData.Rows.Clear();

                fillDataGridView(removedRows);
            }
        }

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString() };
                dataGridViewTestData.Rows.Add(row);
            }
        }

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

        public void testExamGenerateSuccess() {
            Thread.Sleep(6000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendTestExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void generateFilesExam() {

            allQuestionData.Add(themeSelected);
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createTestExamFiles", tempArray);
            MessageBox.Show(jsonMessageGetThemes);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        private void textBoxFindQuestion_Enter(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == searchBanner) {
                textBoxFindQuestion.Text = "";
            }
        }

        private void textBoxFindQuestion_Leave(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == "") {
                textBoxFindQuestion.Text = searchBanner;
            }
        }

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            dataGridViewTestData.Rows.Clear();
            fillDataGridView();
        }

        public void fillDataGridView(string[] allDataParam) {
            allDataOnView = allDataParam;

            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], allDataParam[questionCounter + 2], allDataParam[questionCounter + 3], allDataParam[questionCounter + 4], allDataParam[questionCounter + 5], allDataParam[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter+= 6;
            }
        }

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter++) {
                object[] row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], allDataOnView[questionCounter + 2], allDataOnView[questionCounter + 3], allDataOnView[questionCounter + 4], allDataOnView[questionCounter + 5], allDataOnView[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
        }

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

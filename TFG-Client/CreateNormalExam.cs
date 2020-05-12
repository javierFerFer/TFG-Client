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
    public partial class CreateNormalExam : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string themeSelected;
        private string typeOfExam;
        private ArrayList allQuestionData = new ArrayList();

        // True muestra preguntas que no estén en modelos, false muestra preguntas que están en modelos
        private bool saveAsModel;

        private ArrayList positionsArrayData = new ArrayList();
        string[] allDataOnView;
        private const string searchBanner = "Nombre de la pregunta a buscar...";

        public CreateNormalExam(string typeOfExamParam, string themeSelectedParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, bool saveAsModelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            themeSelected = themeSelectedParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            ConnectionWithServer.setCreateNormalExam(this);
            showHideElements(false);
            showHideBackButton(false);
            showHideLabelWait(true);
            showHideErrorMessage(false);
            saveAsModel = saveAsModelParam;
            getAllNormalQuestionsSpecificTheme();
        }

        private void getAllNormalQuestionsSpecificTheme() {
            string jsonMessageGetThemes = "";
                jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllNormalQuestionsSpecificTheme", themeSelected);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        private void buttonBack_Click(object sender, EventArgs e) {
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
            dataGridViewAllNormalData.Visible = option;
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

        private void nextButton_Click(object sender, EventArgs e) {

        }

        private void searchButton_Click(object sender, EventArgs e) {
            ArrayList removedRows = new ArrayList();

            resetButton.PerformClick();
            if (textBoxFindQuestion.Text != searchBanner) {
                foreach (DataGridViewRow row in dataGridViewAllNormalData.Rows) {
                    //MessageBox.Show(row.Cells[1].Value.ToString().ToLower());
                    if (row.Cells[1].Value.ToString().ToLower().Contains(textBoxFindQuestion.Text.ToLower())) {
                        DataGridViewRow tempRow = row;
                        removedRows.Add(tempRow);
                    }
                }

                dataGridViewAllNormalData.Rows.Clear();

                fillDataGridView(removedRows);
            }
        }

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString() };
                dataGridViewAllNormalData.Rows.Add(row);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            if (dataGridViewMyQuestions.Rows.Count < 5) {
                // Error, al menos el examen debe poseer 5 preguntas
                Utilities.customErrorInfo("Debe seleccionar al menos 5 preguntas para poder continuar");
            } else if (dataGridViewMyQuestions.Rows.Count > 30) {
                // Error, el examen no puede de tipo normal no puede tener más de 30 preguntas
                Utilities.customErrorInfo("No puede seleccionar más de 30 preguntas para un examen");
            } else {
                // Petición de creación de examen
                allQuestionData = new ArrayList();

                for (int counter = 0; counter < dataGridViewMyQuestions.Rows.Count; counter++) {
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[0].Value.ToString());
                    allQuestionData.Add(dataGridViewMyQuestions.Rows[counter].Cells[1].Value.ToString());
                }

                if (saveAsModel) {
                    Utilities.openForm(new AllDataNormalModel(typeOfExam, themeSelected, allQuestionData, dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    // Aquí versión sin salvar el modelo del examen
                    Utilities.openForm(new EmptyDataForm("Generando examen..."), dataPanel, rightPanel);
                    generateFilesExam();
                }
            }
        }

        public void normalExamGenerateSuccess() {
            Thread.Sleep(3000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendNormalExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void generateFilesExam() {

            allQuestionData.Add(themeSelected);
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createNormalExamFiles", tempArray);
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

        private void textBoxFindQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                searchButton.PerformClick();
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
            dataGridViewAllNormalData.Rows.Clear();
            fillDataGridView();
        }

        public void fillDataGridView(string[] allDataParam) {
            allDataOnView = allDataParam;
            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1] };
                dataGridViewAllNormalData.Rows.Add(row);
                questionCounter++;
            }
        }

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter++) {
                object[] row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1] };
                dataGridViewAllNormalData.Rows.Add(row);
                questionCounter++;
            }
        }


        private void dataGridViewAllNormalData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString();

            } catch (Exception) { }
        }

        private void dataGridViewMyQuestions_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString();

            } catch (Exception) { }
        }

        private void dataGridViewAllNormalData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                tempView.Rows.Remove(tempRow);
                for (int counter = 0; counter < allDataOnView.Length; counter++) {
                    if (allDataOnView[counter] == tempRow.Cells[0].Value.ToString()) {
                        allDataOnView = allDataOnView.Where(val => val != tempRow.Cells[0].Value.ToString()).ToArray();
                        allDataOnView = allDataOnView.Where(val => val != tempRow.Cells[1].Value.ToString()).ToArray();
                        positionsArrayData.Add(counter);
                        positionsArrayData.Add(counter+1);
                    }
                }
                dataGridViewMyQuestions.Rows.Add(tempRow);

            } catch (Exception) { }
        }

        private void dataGridViewMyQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                tempView.Rows.Remove(tempRow);


                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[0].Value.ToString();
                Array.Resize(ref allDataOnView, allDataOnView.Length + 1);
                allDataOnView[allDataOnView.GetUpperBound(0)] = tempRow.Cells[1].Value.ToString();

                dataGridViewAllNormalData.Rows.Add(tempRow);


            } catch (Exception) { }
        }
    }
}

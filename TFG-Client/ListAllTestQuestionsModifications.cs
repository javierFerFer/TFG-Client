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
    public partial class ListAllTestQuestionsModifications : Form {
        Panel dataPanel;
        Panel rightPanel;
        Form beforeForm;
        string[] allDataOnView;
        public string[] allDataSelectedQuestion;
        string selectedQuestion;
        string tempDeleteStatus = "Borrar";
        private const string searchBanner = "Nombre de la pregunta a buscar...";

        public ListAllTestQuestionsModifications(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            ConnectionWithServer.LoginForm.ListAllTestQuestionsModificationsObject = this;
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

        public void hide_show_dataGridView(bool option) {
            errorNoQuestionsFound.Text = "Esperando respuesta del servidor, espere...";
            Thread.Sleep(3000);
            pictureBoxSearchQuestion.Visible = option;
            dataGridViewTestData.Visible = option;
            textBoxFindQuestion.Visible = option;
            searchButton.Visible = option;
            resetButton.Visible = option;
            if (option) {
                errorNoQuestionsFound.Visible = false;
                buttonBack.Visible = true;
            } else {
                errorNoQuestionsFound.Text = "No se han encontrado modificaciones pendientes";
                errorNoQuestionsFound.Visible = true;
                buttonBack.Visible = true;
            }
        }

        public async void openPopUpWithModifications(string [] allDataOfModifications) {
            await Task.Run(() => { Utilities.createPopUpWithAllQuestionsTest(allDataOfModifications, dataPanel, rightPanel); });
        }

        public void openSuccessAddModificationNormalQuest() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la modificación al sistema"), dataPanel, rightPanel);
        }

        private void getAllTestQuestions() {
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestQuestionsForMod", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void fillDataGridView(string[] allDataParam) {
            allDataOnView = allDataParam;

            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], allDataParam[questionCounter + 2], allDataParam[questionCounter + 3], allDataParam[questionCounter + 4], allDataParam[questionCounter + 5], allDataParam[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
        }

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString() };
                dataGridViewTestData.Rows.Add(row);
            }
        }

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter++) {
                object[] row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], allDataOnView[questionCounter + 2], allDataOnView[questionCounter + 3], allDataOnView[questionCounter + 4], allDataOnView[questionCounter + 5], allDataOnView[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
                questionCounter += 6;
            }
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

        private void textBoxFindQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                searchButton.PerformClick();
            }
        }


        private void resetButton_Click(object sender, EventArgs e) {
            dataGridViewTestData.Rows.Clear();
            fillDataGridView();
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            panelAllData.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        private void dataGridViewTestData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                    + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();

            } catch (Exception) { }
        }

        private void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Listado de todas las modificaciones de la pregunta en un pop-up
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];
            selectedQuestion = tempRow.Cells[1].Value.ToString();

            allDataSelectedQuestion = new string[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString() , tempRow.Cells[2].Value.ToString() , tempRow.Cells[3].Value.ToString() , tempRow.Cells[4].Value.ToString() , tempRow.Cells[5].Value.ToString() , tempRow.Cells[6].Value.ToString() };

            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestModifications", tempRow.Cells[0].Value.ToString());
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }
    }
}

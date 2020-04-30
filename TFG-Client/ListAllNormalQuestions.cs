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
    public partial class ListAllNormalQuestions : Form {
        string typeOfData;
        string nameOfSubject;
        Panel dataPanel;
        Panel rightPanel;
        string[] allDataOnView;

        public ListAllNormalQuestions(string typeOfDataParam, string nameOfSubjectParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            typeOfData = typeOfDataParam;
            nameOfSubject = nameOfSubjectParam;
            ConnectionWithServer.LoginForm.ListAllNormalQuestions = this;
            errorNoQuestionsFound.Text = "Esperando datos del servidor...";
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            errorNoQuestionsFound.Visible = true;
            textBoxFindQuestion.Visible = false;
            searchButton.Visible = false;
            resetButton.Visible = false;
            pictureBoxSearchQuestion.Visible = false;
            dataGridViewAllNormalData.Visible = false;
            getAllNormalQuestions();
        }

        public void hide_show_dataGridView(bool option) {
            Thread.Sleep(2000);
            pictureBoxSearchQuestion.Visible = option;
            dataGridViewAllNormalData.Visible = option;
            textBoxFindQuestion.Visible = option;
            searchButton.Visible = option;
            resetButton.Visible = option;
            if (option) {
                errorNoQuestionsFound.Visible = false;
            } else {
                errorNoQuestionsFound.Text = "No se han encontrado preguntas normales asociadas a la asignatura";
                errorNoQuestionsFound.Visible = true;
            }
        }

        public void openSuccessAddModificationNormalQuest() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de modificación al sistema"), dataPanel, rightPanel);
        }

        private void getAllNormalQuestions() {
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllNormalQuestionsSpecificNameOfSUbject", nameOfSubject);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void fillDataGridView(string [] allDataParam) {
            allDataOnView = allDataParam;
            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1] };
                dataGridViewAllNormalData.Rows.Add(row);
                questionCounter++;
            }
        }

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString() };
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

        private void textBoxFindQuestion_Enter(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == "Nombre de la pregunta a buscar...") {
                textBoxFindQuestion.Text = "";
            }
        }

        private void textBoxFindQuestion_Leave(object sender, EventArgs e) {
            if (textBoxFindQuestion.Text == "") {
                textBoxFindQuestion.Text = "Nombre de la pregunta a buscar...";
            }
        }

        private void dataGridViewAllNormalData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewSelectedRowCollection selectedRow = dataGridViewAllNormalData.SelectedRows;
                DataGridViewRow bar = selectedRow[0];
                Utilities.createFormNewNormalModification("Petición de modificación", bar.Cells[0].Value.ToString(), bar.Cells[1].Value.ToString());
            
        }

        private void searchButton_Click(object sender, EventArgs e) {
            ArrayList removedRows = new ArrayList();

            foreach (DataGridViewRow row in dataGridViewAllNormalData.Rows) {
                MessageBox.Show(row.Cells[1].Value.ToString().ToLower());
                if (row.Cells[1].Value.ToString().ToLower().Equals(textBoxFindQuestion.Text.ToLower())) {
                    DataGridViewRow tempRow = row;
                    removedRows.Add(tempRow);
                }
            }

            dataGridViewAllNormalData.Rows.Clear();

            fillDataGridView(removedRows);

        }

        private void textBoxFindQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                searchButton.PerformClick();
            }
        }


        private void resetButton_Click(object sender, EventArgs e) {
            dataGridViewAllNormalData.Rows.Clear();
            fillDataGridView();
        }
    }
}

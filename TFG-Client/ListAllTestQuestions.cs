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
    public partial class ListAllTestQuestions : Form {
        string nameOfSubject;
        Panel dataPanel;
        Panel rightPanel;
        Form beforeForm;
        string[] allDataOnView;
        private const string searchBanner = "Nombre de la pregunta a buscar...";

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
        }

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

        public void openSuccessAddModificationNormalQuest() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de modificación al sistema"), dataPanel, rightPanel);
        }

        private void getAllTestQuestions() {
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllTestQuestionsSpecificNameOfSUbject", nameOfSubject);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void fillDataGridView(string [] allDataParam) {
            allDataOnView = allDataParam;
            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter++) {
                object[] row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], allDataParam[questionCounter + 2], allDataParam[questionCounter + 3],  allDataParam[questionCounter + 4], allDataParam[questionCounter + 5] , allDataParam[questionCounter + 6] };
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

        private void dataGridViewAllNormalData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewSelectedRowCollection selectedRow = dataGridViewTestData.SelectedRows;
                DataGridViewRow rowSelectedByUser = selectedRow[0];
                Utilities.createFormNewNormalModification("Petición de modificación", rowSelectedByUser.Cells[0].Value.ToString(), rowSelectedByUser.Cells[1].Value.ToString());
            
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
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        private void dataGridViewAllNormalData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            DataGridViewRow tempRow = sender as DataGridViewRow;
            MessageBox.Show(tempRow.Cells[0].Value.ToString());
        }

        private void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Petición de modificación
            
            DataGridViewSelectedRowCollection selectedRow = dataGridViewTestData.SelectedRows;
            DataGridViewRow rowSelectedByUser = selectedRow[0];
            Utilities.createFormNewTestModification("Petición de modificación", rowSelectedByUser.Cells[0].Value.ToString(), rowSelectedByUser.Cells[1].Value.ToString(), rowSelectedByUser.Cells[2].Value.ToString(), rowSelectedByUser.Cells[3].Value.ToString(), rowSelectedByUser.Cells[4].Value.ToString(), rowSelectedByUser.Cells[5].Value.ToString(), rowSelectedByUser.Cells[6].Value.ToString());
        }

        private void dataGridViewTestData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
                // another cell in the same row (see my note below).
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString()
                   + "\r\n" + "\r\n"+ "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString()
                   + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString()
                  + "\r\n" + "\r\n" + "- Opción correcta: \r\n" + tempRow.Cells[6].Value.ToString();
            } catch (Exception) {}
        }
    }
}

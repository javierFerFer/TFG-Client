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
    public partial class ListAllNormalQuestionsModifications : Form {
        Panel dataPanel;
        Panel rightPanel;
        Form beforeForm;
        string[] allDataOnView;
        string tempDeleteStatus = "Borrar";
        private const string searchBanner = "Nombre de la pregunta a buscar...";

        public ListAllNormalQuestionsModifications(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            ConnectionWithServer.LoginForm.ListAllNormalQuestionsModificationsObject = this;
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
            dataGridViewAllNormalData.Visible = false;
            getAllNormalQuestions();
            panelAllData.Focus();
        }

        public void hide_show_dataGridView(bool option) {
            errorNoQuestionsFound.Text = "Esperando respuesta del servidor, espere...";
            Thread.Sleep(3000);
            pictureBoxSearchQuestion.Visible = option;
            dataGridViewAllNormalData.Visible = option;
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

        public void openSuccessAddModificationNormalQuest() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la modificación al sistema"), dataPanel, rightPanel);
        }

        private void getAllNormalQuestions() {
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getAllNormalQuestionsForMod", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void fillDataGridView(string [] allDataParam) {
            allDataOnView = allDataParam;
            for (int questionCounter = 0; questionCounter < allDataParam.Length; questionCounter+=3) {
                object[] row;
                if (!allDataParam[questionCounter + 2].Equals("null")) {
                    row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], allDataParam[questionCounter + 2] };
                } else {
                    row = new object[] { allDataParam[questionCounter], allDataParam[questionCounter + 1], tempDeleteStatus };
                }
                dataGridViewAllNormalData.Rows.Add(row);
                
                if (allDataParam[questionCounter + 2].Equals("null")) {
                    int index = dataGridViewAllNormalData.Rows.Count - 1;
                    dataGridViewAllNormalData.Rows[index].Cells[2].Style.BackColor = Color.Red;
                }
            }
        }

        public void fillDataGridView(ArrayList allDataParamObjects) {
            for (int questionCounter = 0; questionCounter < allDataParamObjects.Count; questionCounter++) {
                DataGridViewRow tempRow = (DataGridViewRow)allDataParamObjects[questionCounter];
                object[] row;

                if (!tempRow.Cells[2].Value.ToString().Equals("null")) {
                    row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString() };
                } else {
                    row = new object[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempDeleteStatus };
                }
                
                dataGridViewAllNormalData.Rows.Add(row);

                if (tempRow.Cells[2].Value.ToString().Equals("Borrar")) {
                    int index = dataGridViewAllNormalData.Rows.Count - 1;
                    dataGridViewAllNormalData.Rows[index].Cells[2].Style.BackColor = Color.Red;
                }
            }
        }

        private void fillDataGridView() {
            for (int questionCounter = 0; questionCounter < allDataOnView.Length; questionCounter+=3) {
                object[] row;
                if (!allDataOnView[questionCounter + 2].Equals("null")) {
                    row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], allDataOnView[questionCounter + 2] };
                } else {
                    row = new object[] { allDataOnView[questionCounter], allDataOnView[questionCounter + 1], tempDeleteStatus };
                }
                dataGridViewAllNormalData.Rows.Add(row);

                if (allDataOnView[questionCounter + 2].Equals("null")) {
                    int index = dataGridViewAllNormalData.Rows.Count - 1;
                    dataGridViewAllNormalData.Rows[index].Cells[2].Style.BackColor = Color.Red;
                }
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
            DataGridViewSelectedRowCollection selectedRow = dataGridViewAllNormalData.SelectedRows;
                DataGridViewRow rowSelectedByUser = selectedRow[0];
                Utilities.createFormNewNormalModificationAddOrDelete("Petición de modificación", rowSelectedByUser.Cells[0].Value.ToString(), rowSelectedByUser.Cells[1].Value.ToString(), rowSelectedByUser.Cells[2].Value.ToString());
        }

        private void searchButton_Click(object sender, EventArgs e) {
            ArrayList removedRows = new ArrayList();

            resetButton.PerformClick();
            if (textBoxFindQuestion.Text != searchBanner) {
                foreach (DataGridViewRow row in dataGridViewAllNormalData.Rows) {
                    if (row.Cells[1].Value.ToString().ToLower().Contains(textBoxFindQuestion.Text.ToLower())) {
                        DataGridViewRow tempRow = row;
                        removedRows.Add(tempRow);
                    }
                }

                dataGridViewAllNormalData.Rows.Clear();

                fillDataGridView(removedRows);
            }
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

        private void buttonBack_Click(object sender, EventArgs e) {
            panelAllData.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void textBoxFindQuestion_TextChanged(object sender, EventArgs e) {
            searchButton.PerformClick();
        }

        private void dataGridViewAllNormalData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!tempRow.Cells[2].Value.ToString().Equals("null")) {
                    cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Modificación completa: \r\n" + tempRow.Cells[2].Value.ToString();
                } else {
                    cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Modificación completa: \r\n" + tempDeleteStatus;
                }

            } catch (Exception) {}
        }
    }
}

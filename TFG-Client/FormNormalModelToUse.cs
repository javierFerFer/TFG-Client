//============================================================================
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
    public partial class FormNormalModelToUse : Form {
        private string[] allQuestions;
        private Panel dataPanel;
        private Panel rightPanel;
        private string subject;

        public FormNormalModelToUse(string[] allQuestionsParam, Panel dataPanelParam, Panel rightPanelParam , string subjecParam) {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            allQuestions = allQuestionsParam;
            subject = subjecParam;
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

        public void normalExamGenerateSuccess() {
            Thread.Sleep(3000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendNormalExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void testExamGenerateSuccess() {
            Thread.Sleep(3000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendTestExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            // Enviar datos aqui
            ArrayList allDataOfModel = new ArrayList();

            if (!dataGridViewTestData.Visible) {
                
                foreach (DataGridViewRow row in dataGridViewAllNormalData.Rows) {
                    allDataOfModel.Add(row.Cells[0].Value.ToString());
                    allDataOfModel.Add(row.Cells[1].Value.ToString());
                }

                allDataOfModel.Add(subject);
                string[] tempArray = (string[])allDataOfModel.ToArray(typeof(string));

                string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("SelectedNormalModelcreateNormalExamFiles", tempArray);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();

            } else {

                foreach (DataGridViewRow row in dataGridViewTestData.Rows) {
                    allDataOfModel.Add(row.Cells[0].Value.ToString());
                    allDataOfModel.Add(row.Cells[1].Value.ToString());
                    allDataOfModel.Add(row.Cells[2].Value.ToString());
                    allDataOfModel.Add(row.Cells[3].Value.ToString());
                    allDataOfModel.Add(row.Cells[4].Value.ToString());
                    allDataOfModel.Add(row.Cells[5].Value.ToString());
                    allDataOfModel.Add(row.Cells[6].Value.ToString());
                }

                allDataOfModel.Add(subject);
                string[] tempArray = (string[])allDataOfModel.ToArray(typeof(string));

                string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("SelectedTestModelcreateTestExamFiles", tempArray);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }

            Dispose();
        }

        internal void fillQuestions() {
                for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter++) {
                    object[] row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 1] };
                    dataGridViewAllNormalData.Rows.Add(row);
                    questionCounter++;
                }
        }

        internal void fillQuestionsTest() {
            for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter+=7) {
                object[] row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 1], allQuestions[questionCounter + 2], allQuestions[questionCounter + 3], allQuestions[questionCounter + 4], allQuestions[questionCounter + 5], allQuestions[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
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

        private void dataGridViewAllNormalData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];


            Utilities.createNewNormalModificationForModel(tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow, tempView);
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
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];


            Utilities.createNewTestModificationForModel(tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString(), tempRow, tempView);
        }
    }
}

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
    public partial class FormTestModifications : Form {
        private string[] allQuestions;
        private Panel dataPanel;
        private Panel rightPanel;

        public FormTestModifications(string[] allQuestionsParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            allQuestions = allQuestionsParam;
        }

        /// <summary>
        /// Evento de cierre del boton 'cerrar' de la ventana
        /// 
        /// Evento of close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e) {
            Dispose();
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

        internal void fillQuestionsTest() {
            
            for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter+=8) {
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
                    row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 2], allQuestions[questionCounter + 3], allQuestions[questionCounter + 4], allQuestions[questionCounter + 5], allQuestions[questionCounter + 6], allQuestions[questionCounter + 7] , "NO"};
                } else {
                    row = new object[] { allQuestions[questionCounter], " ", " ", " ", " ", " ", " ", "SI"};
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

        private void dataGridViewTestData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!tempRow.Cells[7].Value.ToString().Equals("SI")) {
                    cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                    + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();
                }

            } catch (Exception) { }
        }

        private async void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

            string[] dataOfMod = new string[] { tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString() , tempRow.Cells[2].Value.ToString() , tempRow.Cells[3].Value.ToString() , tempRow.Cells[4].Value.ToString() , tempRow.Cells[5].Value.ToString() , tempRow.Cells[6].Value.ToString() };

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

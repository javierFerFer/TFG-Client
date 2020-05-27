////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\FormNormalModelToUse.cs </file>
///
/// <copyright file="FormNormalModelToUse.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase FormNormalModelToUse.\n
///             Implements the form normal model to use class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Formulario que muestra las preguntas asociadas al modelo que se va a usar para generar el examen.\n
    ///             Form that show all questions of the model that will be to use to create an exam. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FormNormalModelToUse : Form {
        private string[] allQuestions;
        private Panel dataPanel;
        private Panel rightPanel;
        private string subject;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="allQuestionsParam">    Listado de preguntas del modelo.\n
        ///                                     List of the questions of the model. </param>
        /// <param name="dataPanelParam">       Panel donde se el programa muestra los datos.\n
        ///                                     Panel when this program show all data. </param>
        /// <param name="rightPanelParam">      Panel derecho del programa.\n
        ///                                     Right panel of the program. </param>
        /// <param name="subjecParam">          Tema seleccionado.\n
        ///                                     Selected theme. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormNormalModelToUse(string[] allQuestionsParam, Panel dataPanelParam, Panel rightPanelParam, string subjecParam) {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            allQuestions = allQuestionsParam;
            subject = subjecParam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar del formulario, cuando este es pulsado, se advierte al usuario de la posible perdida de datos,
        ///             si continua, este formulario es cerrado.\n
        ///             Click event about close button, if this button is pressed, this event create and show warning form. If the user continue anyway, this form will be close. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void closeButton_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Dispose();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que se activa cuando el servidor envía un mensaje indicando que el examen normal se generó correctamente.\n
        ///             Event that show a message when the server send this message --> normal exam generate success. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void normalExamGenerateSuccess() {
            Thread.Sleep(3000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendNormalExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento que se activa cuando el servidor envía un mensaje indicando que el examen de tipo test se generó correctamente.\n
        ///             Event that show a message when the server send this message --> test exam generate success. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void testExamGenerateSuccess() {
            Thread.Sleep(3000);
            Utilities.openForm(new EmptyDataForm("Examen generado correctamente, debería recibir un correo en breve con el mismo.\n Revise su bandeja de entrada"), dataPanel, rightPanel);
            string jsonMessageGetThemes = Utilities.generateSingleDataRequest("sendTestExam", ConnectionWithServer.EmailUser);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón enviar, cuando es pulsado, se envia una petición al servidor indicandole los datos del modelo a usar.\n
        ///             Click event about send button, when the user press this button, the program send a request to use selected model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena la lista con las preguntas obtenidas del servidor de tipo normal.\n
        ///             Fill normal questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal void fillQuestions() {
            for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter++) {
                object[] row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 1] };
                dataGridViewAllNormalData.Rows.Add(row);
                questionCounter++;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena la lista con las preguntas obtenidas del servidor de tipo test.\n
        ///             Fill test questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal void fillQuestionsTest() {
            for (int questionCounter = 0; questionCounter < allQuestions.Length; questionCounter += 7) {
                object[] row = new object[] { allQuestions[questionCounter], allQuestions[questionCounter + 1], allQuestions[questionCounter + 2], allQuestions[questionCounter + 3], allQuestions[questionCounter + 4], allQuestions[questionCounter + 5], allQuestions[questionCounter + 6] };
                dataGridViewTestData.Rows.Add(row);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cell mouse enter, cuando se activa, muestra los datos referentes a la pregunta seleccionada en la fila.\n
        /// Event of cell mouse enter, when the user active this event, this event show all data of the selected question in selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewAllNormalData_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView tempView = (DataGridView)sender;
                tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                DataGridViewRow tempRow = tempView.Rows[e.RowIndex];

                DataGridViewCell cell = tempView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta completa: \r\n" + tempRow.Cells[1].Value.ToString();

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada, cuando se activa este evento, se crea un formulario para la modificación/borrado
        /// de la pregunta asociada al modelo cuando se vaya a crear el examen.\n
        /// Double click event about selected cell, when this event is activated, this event create a form to modify/delete this question of the model when the server will be generate a exam.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewAllNormalData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];


            Utilities.createNewNormalModificationForModel(tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow, tempView);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cell mouse enter, cuando se activa, muestra los datos referentes a la pregunta seleccionada en la fila.\n
        /// Event of cell mouse enter, when the user active this event, this event show all data of the selected question in selected row.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
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
                cell.ToolTipText = "- ID: \r\n" + tempRow.Cells[0].Value.ToString() + "\r\n" + "\r\n" + "- Pregunta: \r\n" + tempRow.Cells[1].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta A: \r\n" + tempRow.Cells[2].Value.ToString()
                    + "\r\n" + "\r\n" + "- Respuesta B: \r\n" + tempRow.Cells[3].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta C: \r\n" + tempRow.Cells[4].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta D: \r\n" + tempRow.Cells[5].Value.ToString() + "\r\n" + "\r\n" + "- Respuesta correcta: \r\n" + tempRow.Cells[6].Value.ToString();

            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de doble click sobre la celda seleccionada, cuando se activa este evento, se crea un formulario para la modificación/borrado
        /// de la pregunta asociada al modelo cuando se vaya a crear el examen.\n
        /// Double click event about selected cell, when this event is activated, this event create a form to modify/delete this question of the model when the server will be generate a exam.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 2¡17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información sobre el evento de DataGridViewCell.\n
        ///                         Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridViewTestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView tempView = (DataGridView)sender;
            tempView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            DataGridViewRow tempRow = tempView.Rows[e.RowIndex];


            Utilities.createNewTestModificationForModel(tempRow.Cells[0].Value.ToString(), tempRow.Cells[1].Value.ToString(), tempRow.Cells[2].Value.ToString(), tempRow.Cells[3].Value.ToString(), tempRow.Cells[4].Value.ToString(), tempRow.Cells[5].Value.ToString(), tempRow.Cells[6].Value.ToString(), tempRow, tempView);
        }
    }
}

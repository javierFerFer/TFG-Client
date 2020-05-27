////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AllDataNormalModel.cs </file>
///
/// <copyright file="AllDataNormalModel.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AllDataNormalModel.\n
///             Implements all data normal model class. </summary>
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
    /// <summary>   Permite la inserción de un nuevo modelo al sistema.\n
    ///             Allow to add new model. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AllDataNormalModel : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string idModel;
        private ArrayList allQuestionData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">      Tipo de examen.\n
        ///                                     Type of exam. </param>
        /// <param name="subjectSelectedParam"> Tema seleccionado.\n
        ///                                     Selected theme. </param>
        /// <param name="allQuestionDataParam"> Listado de preguntas asociadas al modelo.\n
        ///                                     List of all questions of the model. </param>
        /// <param name="dataPanelParam">       Panel donde el programa muestra los datos.\n
        ///                                     Panel where program show all data. </param>
        /// <param name="rightPanelParam">      Panel de la izquierda.\n
        ///                                     Right panel. </param>
        /// <param name="beforeFormParam">      Panel anterior.\n
        ///                                     before panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AllDataNormalModel(string typeOfExamParam, string subjectSelectedParam, ArrayList allQuestionDataParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectSelectedParam;
            typeOfModel.Text += typeOfExamParam;
            beforeForm = beforeFormParam;
            allQuestionData = allQuestionDataParam;
            ConnectionWithServer.setAllDataNormalModel(this);
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver. carga el beforeForm cuando es pulsado.\n
        ///             Click event about back button. Load beforeForm.  </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón enviar. Realiza una petición al sistema para agregar el modelo.\n
        ///             Click event on send button. This event does a request to add new model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if ((textBoxNameOfModel.Text.Length != 0 && textBoxDescription.Text.Length != 0) && (textBoxNameOfModel.Text.Length >= 5 && textBoxDescription.Text.Length >= 5)) {
                // Comprobación de que el nombre del modelo no exista ya antes de crearlo
                // Buscar nombre de la pregunta antes de enviar
                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("findNameNormalModel", textBoxNameOfModel.Text);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {
                if (textBoxNameOfModel.Text.Length == 0 || textBoxNameOfModel.Text.Length < 5) {
                    Utilities.customErrorInfo("La longitud del nombre del modelo debe tener al menos 5 caracteres");
                } else if (textBoxDescription.Text.Length == 0 || textBoxDescription.Text.Length < 5) {
                    Utilities.customErrorInfo("La longitud de la descripción del modelo debe tener al menos 5 caracteres");
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de generación de examen al servidor.\n
        ///             Generates an exam request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="idModelParam"> ID del modelo al que pertenecen las preguntas.\n
        ///                             ID of the model that have the questions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void generateExamRequest(string idModelParam) {
            idModel = idModelParam;
            Utilities.openForm(new EmptyDataForm("Se ha guardado correctamente el modelo en el servidor.\n Generando examen..."), dataPanel, rightPanel);

            // Copia del array

            string[] allData = new string[allQuestionData.Count + 1];
            allData[0] = idModel;
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            tempArray.CopyTo(allData, 1);

            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("updateAllNormalQuestionsNewNormalModel", allData);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre el texto de la descripción del modelo, verifica que el texto sea valido o no.\n
        ///             Event of text change about text of description of the model, check if this text is valid or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            try {
                if (textBoxDescription.Text.Length > 120) {
                    if (textBoxDescription.Text.Length == 121) {
                        textBoxDescription.Text = textBoxDescription.Text.Substring(0, textBoxDescription.Text.Length - 1);
                        textBoxDescription.Select(textBoxDescription.Text.Length, 0);
                        Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en la descripción");
                    } else {
                        Utilities.customErrorInfo("El texto introducido supera el limite máximo de caracteres");
                        textBoxDescription.Text = "";
                    }
                }
            } catch (Exception) { }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre el nombre del modelo, verifica si el nombre es válido o no.\n
        ///             Event of change text about name of model, check if this name is valid or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_TextChanged(object sender, EventArgs e) {
            try {
                if (textBoxNameOfModel.Text.Trim().Length != 0) {
                    string textToReplace = textBoxNameOfModel.Text.Substring(0, 1).ToUpper();
                    textToReplace += textBoxNameOfModel.Text.Substring(1, textBoxNameOfModel.Text.Length - 1);
                    textBoxNameOfModel.Text = textToReplace;
                    textBoxNameOfModel.Select(textBoxNameOfModel.Text.Length, 0);
                }
                if (textBoxNameOfModel.Text.Trim().Length > 40) {
                    textBoxNameOfModel.Text = textBoxNameOfModel.Text.Substring(0, textBoxNameOfModel.Text.Length - 1);
                    textBoxNameOfModel.Select(textBoxNameOfModel.Text.Length, 0);
                    Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en el título del modelo");
                }
            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de key press sobre el texto del nombre del modelo, comprueba si el usuario ha pulsado la tecla ENTER.\n
        ///             Key press event about text of the name of the model, check if user press ENTER key. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento de tecla pulsada.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de tecla pulsada sobre el texto con el nombre del modelo, comprueba si la tecla pulsada es ENTER, en dicho caso la omite.\n
        ///             Key press event about text of the name of the model, check if user press ENTER key, in this case, avoid. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de tecla pulsada sobre el texto con la descripción del modelo, comprueba si la tecla pulsada es ENTER, en dicho caso la omite.\n
        ///             Key press event about text of the description of the model, check if user press ENTER key, in this case, avoid. </summary>
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfModel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera un mensaje de error si no se puede generar el examen.\n
        ///             Generates an error message. when the system cannot genetare a exam </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void generateErrorMessage() {
            Utilities.openForm(new EmptyDataForm("Se produjo un error al intentar generar el examen, contacte con el administrador"), dataPanel, rightPanel);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de creación del modelo.\n
        ///             Creates normal model request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void createNormalModelRequest() {
            // Petición de creación del modelo
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createNormalModel", new string[] { textBoxNameOfModel.Text, textBoxDescription.Text, subject, ConnectionWithServer.EmailUser });
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de creación del examen.\n
        ///             Generates the files exam. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 06/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void generateFilesExam() {
            // Petición de creación del fichero examen
            allQuestionData.Add(subject);
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createNormalExamFiles", tempArray);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }
    }
}

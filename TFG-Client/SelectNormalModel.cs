////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\SelectNormalModel.cs </file>
///
/// <copyright file="SelectNormalModel.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase SelectNormalModel.\n
///             Implements the select normal model class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
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
    /// <summary>   Muestra todos los modelos obtenidos del sistema.\n
    ///             Get all models of the server. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class SelectNormalModel : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string typeOfExam;
        private string idModelCreated;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">  Tipo de examen.\n
        ///                                 Type of the exam parameter. </param>
        /// <param name="subjectParam">     Tema seleccionado.\n
        ///                                 The subject parameter. </param>
        /// <param name="dataPanelParam">   Panel donde el programa muestra los datos.\n
        ///                                 Panel where program show all data. </param>
        /// <param name="rightPanelParam">  Panel derecho.\n
        ///                                 Right panel. </param>
        /// <param name="beforeFormParam">  Panel anterior.\n
        ///                                 Before panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SelectNormalModel(string typeOfExamParam, string subjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            ConnectionWithServer.setNewSelectNormalModel(this);
            showHideElements(false);

            if (typeOfExam == "normal") {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllNormalModels", subject);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllTestModels", subject);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }


            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Esconde/muestra elementos de la interfaz.\n
        ///             Hide/show elements of the interface. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="option">   True = muestra elementos, false = esconde elementos.\n
        ///                         True = show elements, false = hide elements. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void showHideElements(bool option) {
            labelWaitData.Visible = !option;
            buttonBack.Visible = option;
            flowLayoutPanelAllModels.Visible = option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea y muestra los modelos en la interfaz del usuario.\n
        ///             Create and show models of exams. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="allDataModelsParam">   all data models parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void createAndShowModels(string[] allDataModelsParam) {
            buttonBack.Visible = true;
            labelWaitData.Visible = false;
            if (typeOfExam == "normal") {
                for (int counterOfModels = 0; counterOfModels < allDataModelsParam.Length; counterOfModels += 4) {
                    ModelOfModels newModel = new ModelOfModels(allDataModelsParam[counterOfModels], allDataModelsParam[counterOfModels + 1], allDataModelsParam[counterOfModels + 2], allDataModelsParam[counterOfModels + 3], true);
                    newModel.Tag = counterOfModels;
                    newModel.TopLevel = false;
                    flowLayoutPanelAllModels.Controls.Add(newModel);
                    newModel.Show();
                }
            } else {
                for (int counterOfModels = 0; counterOfModels < allDataModelsParam.Length; counterOfModels += 4) {
                    ModelOfModels newModel = new ModelOfModels(allDataModelsParam[counterOfModels], allDataModelsParam[counterOfModels + 1], allDataModelsParam[counterOfModels + 2], allDataModelsParam[counterOfModels + 3], false);
                    newModel.Tag = counterOfModels;
                    newModel.TopLevel = false;
                    flowLayoutPanelAllModels.Controls.Add(newModel);
                    newModel.Show();
                }
            }

            flowLayoutPanelAllModels.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mensaje de error en caso de no encontrar ningún modelo.\n
        ///             Error message when the program cannot find any model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void showNothingMessage() {
            labelWaitData.Text = "No se ha encontrado ningún modelo perteneciente a este tema";
            buttonBack.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea un mensaje Pop-up con todas las preguntas asociadas a este tema.\n
        ///             Create Pop-up message with all questions of the model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="allDataParam"> Todas las preguntas del modelo.\n
        ///                             All questions of the model. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async void createPopUpMessage(string[] allDataParam) {
            if (typeOfExam == "normal") {
                await Task.Run(() => { Utilities.createPopUpWithAllQuestions(allDataParam, dataPanel, rightPanel, subject, true); });
            } else {
                await Task.Run(() => { Utilities.createPopUpWithAllQuestions(allDataParam, dataPanel, rightPanel, subject, false); });
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, cuando es pulsado, carga el formulario beforeForm.\n
        ///             Click event about back button, when this button is pressed, load this form: beforeForm. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 02/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }
    }
}

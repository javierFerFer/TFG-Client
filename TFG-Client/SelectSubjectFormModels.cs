////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\SelectSubjectFormModels.cs </file>
///
/// <copyright file="SelectSubjectFormModels.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase SelectSubjectFormModels </summary>
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
    /// <summary>   Selección de tema para la generación de examen.\n
    ///             Select theme for to generate exams. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class SelectSubjectFormModels : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string typeOfExam;
        private string idModelCreated;
        private const string bannerComboBox = "Seleccione un tema";
        private const string nothingToShow = "Ningún tema encontrado";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">  Tipo de examen.\n
        ///                                 Type of the exam. </param>
        /// <param name="subjectParam">     Tema seleccionado.\n
        ///                                 Theme selected. </param>
        /// <param name="dataPanelParam">   Panel dondel el programa muestra todos los datos.\n
        ///                                 Panel where program show all data. </param>
        /// <param name="rightPanelParam">  Panel de la derecha.\n
        ///                                 Right panel. </param>
        /// <param name="beforeFormParam">  formulario anterior.\n
        ///                                 The before form. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SelectSubjectFormModels(string typeOfExamParam, string subjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectParam;
            subjectSelected.Text += subjectParam;
            labelRequestTypeOfExam.Text += typeOfExamParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            comboBoxOfThemes.Items.Add(bannerComboBox);
            ConnectionWithServer.setNewSelectSubjectFormModels(this);
            showHideElements(false);

            string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllModelsThemesFromSignature", subject);
            byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

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
            labelRequestTypeOfExam.Visible = option;
            subjectSelected.Visible = option;
            comboBoxOfThemes.Visible = option;
            buttonBack.Visible = option;
            sendButton.Visible = option;
            labelThemes.Visible = option;

            labelWaitData.Visible = !option;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, cuando es pulsado, carga el formulario beforeForm.\n
        ///             Click event about back button, when this button is pressed, load this form: beforeForm. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón siguiente, crea un formulario para la selección de modelo normal o test.\n
        ///             Click event about next button, create form to select normal/test models </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            // Open form formulario para crear examen tipo normal;
            typeOfDataPanel.Focus();
            if (comboBoxOfThemes.SelectedItem.ToString().Equals(bannerComboBox) || comboBoxOfThemes.SelectedItem.ToString().Equals(nothingToShow)) {
                Utilities.customErrorInfo("No se ha seleccionado tema");
            } else {
                if (typeOfExam.Equals("normal")) {
                    Utilities.openForm(new SelectNormalModel(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    Utilities.openForm(new SelectNormalModel(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), dataPanel, rightPanel, this), dataPanel, rightPanel);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el listado de temas.\n
        ///             Fill all themes. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 13/05/2020. </remarks>
        ///
        /// <param name="allThemesNames">   Listado de temas.\n
        ///                                 List of names of all themes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillAllThemes(string[] allThemesNames) {

            // Limpieza del combobox para evitar errores
            comboBoxOfThemes.Items.Clear();
            comboBoxOfThemes.Items.Add(bannerComboBox);
            int indexComboBox;

            if (allThemesNames.Length != 0) {
                for (int themesCounter = 0; themesCounter < allThemesNames.Length; themesCounter++) {
                    comboBoxOfThemes.Items.Add(allThemesNames[themesCounter]);
                }
                indexComboBox = comboBoxOfThemes.FindString(bannerComboBox);
                comboBoxOfThemes.SelectedIndex = indexComboBox;
                showHideElements(true);
            } else {
                comboBoxOfThemes.Items.RemoveAt(0);
                comboBoxOfThemes.Items.Add(nothingToShow);
                indexComboBox = comboBoxOfThemes.FindString(nothingToShow);
                comboBoxOfThemes.SelectedIndex = indexComboBox;
                showHideElements(true);
                sendButton.Visible = false;
                comboBoxOfThemes.Enabled = false;
            }
        }
    }
}

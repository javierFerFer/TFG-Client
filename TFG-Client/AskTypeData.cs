////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AskTypeData.cs </file>
///
/// <copyright file="AskTypeData.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AskTypeData.\n
///             Implements the ask type data class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase AskTypeOfData, pregunta sobre el tipo de dato que quiere ver el usuario.\n
    ///             AskTypeOfData class, ask about type of data that user want to see.</summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AskTypeData : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        // true = add selected, false = modify selected
        private bool selectedOption;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="dataPanelParam">       Panel donde se muestran los datos del programa.\n
        ///                                     The data panel parameter that show all data of the program. </param>
        /// <param name="rightPanelParam">      Panel de la derecha del programa.\n
        ///                                     The right panel parameter. </param>
        /// <param name="beforeFormParam">      Panel anterior mostrado.\n
        ///                                     The before form parameter that was used to show data. </param>
        /// <param name="addOrModifyOption">    True para agregar, false para modificar.\n
        ///                                     True to add, false to modify.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AskTypeData(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, bool addOrModifyOption) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            selectedOption = addOrModifyOption;
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, cargar el formulario anterior cuando el usuario lo presiona.\n
        ///             Click event about back button, load before Panel when user click this button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
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
        /// <summary>   Evento de click sobre el botón siguiente, según selectedOption, cargará el formulario correspondiente.\n
        ///             Click event about next button, if selectedOption = true, load AddNewQuestion, in the opposite case, load ListAllNormal/TestQuestions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n S
        ///                         ource of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            // true = add selected, false = modify
            typeOfDataPanel.Focus();
            AskOperation tempForm = (AskOperation)beforeForm;
            if (selectedOption) {
                if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                    if (checkBoxNormal.Checked) {
                        // Crear un menu para guardar una pregunta en base a la asignatura seleccionada
                        Utilities.openForm(new AddNewQuestion("normal", tempForm.subjectSelected.Text, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    } else {
                        Utilities.openForm(new AddNewQuestionTypeTest("test", tempForm.subjectSelected.Text, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    }
                } else {
                    Utilities.customErrorInfo("No ha seleccionado ninguna opción");
                }
            } else {
                if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                    if (checkBoxNormal.Checked) {
                        // Muestra panel con toda la lista de preguntas de tipo normal de la asignatura seleccionada
                        Utilities.openForm(new ListAllNormalQuestions(tempForm.Subject, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    } else {
                        // Muestra panel con toda la lista de preguntas de tipo test de la asignatura seleccionada
                        Utilities.openForm(new ListAllTestQuestions(tempForm.Subject, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    }
                    //Utilities.openForm(new AskTypeOfData(dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    Utilities.customErrorInfo("No ha seleccionado ninguna opción");
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de checkBox, se activa cuando el mismo es modificado.\n
        ///             CheckBox change event. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxModify_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxTest.Checked) {
                checkBoxNormal.Checked = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de checkBox, se activa cuando el mismo es modificado.\n
        ///             CheckBox change event. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNormal.Checked) {
                checkBoxTest.Checked = false;
            }
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AskTypeDataNewExam.cs </file>
///
/// <copyright file="AskTypeDataNewExam.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AsktypeDataNewExam.\n
///             Implements the ask type data new exam class. </summary>
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
    /// <summary>   Pregunta el tipo de examen que el usuario desea crear.\n
    ///             Ask type of exam to create. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AskTypeDataNewExam : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subjectSelected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
        ///
        /// <param name="dataPanelParam">       Panel donde el programa muestra los datos.\n
        ///                                     The data panel parameter that the program show all data. </param>
        /// <param name="rightPanelParam">      Panel derecho del programa.\n
        ///                                     The right panel parameter. </param>
        /// <param name="beforeFormParam">      Panel anterior.\n
        ///                                     The before form parameter. </param>
        /// <param name="subjectSelectedParam"> Tema seleccionado para ver los modelos.\n
        ///                                     The subject selected to show models parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AskTypeDataNewExam(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, string subjectSelectedParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            subjectSelected = subjectSelectedParam;
            labelSelectedSubject.Text += subjectSelected;
            typeOfDataPanel.Focus();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, carga el beforeForm cuando es pulsado.\n
        ///             Click event about back button, load beforeForm when this button is pressed.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
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
        /// <summary>   Evento de click sobre el botón siguiente, carga el formulario SelectSubjectForm cuando es pulsado.\n
        ///             Click event about next button, load SelectSubjectForm when this button is pressed. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                if (checkBoxTest.Checked) {
                    // Mostrar formulario para selección de asignatura
                    typeOfDataPanel.Focus();
                    Utilities.openForm(new SelectSubjectForm("test", subjectSelected, dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    // Formulario para selección de asignatura
                    typeOfDataPanel.Focus();
                    Utilities.openForm(new SelectSubjectForm("normal", subjectSelected, dataPanel, rightPanel, this), dataPanel, rightPanel);
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio sobre checkBox para ver de tipo test.\n
        ///             Change event about checkBox for to show test. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
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
        /// <summary>   Evento de cambio sobre checkBox para ver de tipo normal.\n
        ///             Change event about checkBox for to show normal. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 05/05/2020. </remarks>
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

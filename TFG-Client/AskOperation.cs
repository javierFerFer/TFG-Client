////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AskOperation.cs </file>
///
/// <copyright file="AskOperation.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AskOperation.\n
///             Implements the ask operation class. </summary>
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
    /// <summary>   Pregunta al usuario si desea modificar o agregar preguntas al tema seleccionado.\n
    ///             Ask if the user want to modify or to add new questions to the selected theme. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AskOperation : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private string subject;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="subjectSelectedParam"> Tema seleccionado.\n
        ///                                     The subject selected parameter. </param>
        /// <param name="dataPanelParam">       panel donde se muestran los datos.\n
        ///                                     The data panel parameter when program show all data. </param>
        /// <param name="rightPanelParam">      Panel de la derecha derecha del programa.\n
        ///                                     The right panel parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AskOperation(string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subjectSelected.Text += subjectSelectedParam;
            Subject = subjectSelectedParam;
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver, si es pulsado, abre un nuevo formulario vacio.\n
        ///             Click event about back button, if the user click on this button, the program create new empty form. </summary>
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
            Utilities.openForm(new EmptyDataForm(), dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón siguiente, si es pulsado, abre un nuevo formulario preguntado que tipo de pregunta desea ver.\n
        ///             Click event about next button, if this button is presssed, open new AskTypeData form.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (checkBoxAdd.Checked || checkBoxModify.Checked) {
                if (checkBoxAdd.Checked) {
                    Utilities.openForm(new AskTypeData(dataPanel, rightPanel, this, true), dataPanel, rightPanel);
                } else {
                    Utilities.openForm(new AskTypeData(dataPanel, rightPanel, this, false), dataPanel, rightPanel);
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de modificación sobre el checkBox de modificación, comprueba si el mismo está marcado o no.\n
        ///             Modify event about checkBox modification, check if this checkBox is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxModify_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxModify.Checked) {
                checkBoxAdd.Checked = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de modificación sobre el checkBox de agregación, comprueba si el mismo está marcado o no.\n
        ///             Modify event about checkBox add, check if this checkBox is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxAdd.Checked) {
                checkBoxModify.Checked = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del tema.\n
        ///             Gets or sets the subject. </summary>
        ///
        /// <value> La asignatura.\n
        ///         The subject. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Subject { get => subject; set => subject = value; }
    }
}

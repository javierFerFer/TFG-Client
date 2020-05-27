////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\ModelWindowsMessageWithBroderWarning.cs </file>
///
/// <copyright file="ModelWindowsMessageWithBroderWarning.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase ModelWindowsMessageWithBorderWarning.\n
///             Implements the model windows message with broder warning class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Modelo con texto y borde usado para advertencias.\n
    ///             Model with only text and border that is used to create warning messages. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ModelWindowsMessageWithBroderWarning : Form {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessageWithBroderWarning() {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto con timer para cierre.\n
        ///             Default constructor with timer to close this form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
        ///
        /// <param name="time"> Tiempo del timer.\n
        ///                     The time of the timer. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessageWithBroderWarning(int time) {
            InitializeComponent();
            timerToClose.Interval = time;
            timerToClose.Tick += new EventHandler(timerToClose_Tick);
            timerToClose.Start();
            buttonContinue.Visible = false;
            closeButton.Visible = false;
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón de cierre del formulario.\n
        ///             Click event about close button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void closeButton_Click(object sender, EventArgs e) {
            Utilities.warningAnser = false;
            Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón continuar.\n
        ///             Click event about continue button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonContinue_Click(object sender, EventArgs e) {
            Utilities.warningAnser = true;
            Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de tick sobre el timer.\n
        ///             Timer event. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 01/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerToClose_Tick(object sender, EventArgs e) {
            this.Close();
        }
    }
}

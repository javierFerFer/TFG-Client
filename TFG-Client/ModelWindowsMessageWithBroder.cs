////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\ModelWindowsMessageWithBroder.cs </file>
///
/// <copyright file="ModelWindowsMessageWithBroder.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase ModelWindowsMessageWithBorder.\n
///             Implements the model windows message with broder class. </summary>
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
    /// <summary>   Modelo de mensaje con texto y borde.\n
    ///             Model of message with only text and border. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ModelWindowsMessageWithBroder : Form {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelWindowsMessageWithBroder() {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón cerrar formulario.\n
        ///             Click event about close button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void closeButton_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}

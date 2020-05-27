////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\EmptyDataForm.cs </file>
///
/// <copyright file="EmptyDataForm.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase EmptyDataForm.\n
///             Implements the empty data Windows Form. </summary>
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
    /// <summary>   Formulario vacío que se carga trás ejecutar alguna accion completa en el sistema.\n
    ///             Empty form that is load when user does any action. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class EmptyDataForm : Form {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EmptyDataForm() {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto con mensaje.\n 
        ///             Default constructor with message. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="messageParam"> Mensaje a mostrar.\n
        ///                             The message parameter to show. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EmptyDataForm(string messageParam) {
            InitializeComponent();
            emptyMessage.Text = messageParam;
        }
    }
}

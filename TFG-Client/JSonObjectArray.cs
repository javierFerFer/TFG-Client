////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\JSonObjectArray.cs </file>
///
/// <copyright file="JSonObjectArray.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase JSonObjectArray.\n
///             Implements the son object array class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Modelo de objeto para enviar/recibir datos del servidor.\n
    ///             Model to send/receive data from the server. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class JSonObjectArray {

        private string[] b_Content;
        private string a_Title;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public JSonObjectArray() {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del título del objeto.\n
        ///             Gets or sets the title. </summary>
        ///
        /// <value> El título del modelo.\n
        ///         A title of the model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string A_Title { get => a_Title; set => a_Title = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del listado de elementos del objeto.\n
        ///             Gets or sets the content of the objet. </summary>
        ///
        /// <value> El contenido del objeto.\n
        ///         The content of the object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string[] B_Content { get => b_Content; set => b_Content = value; }
    }
}

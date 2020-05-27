////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\JSonSingleData.cs </file>
///
/// <copyright file="JSonSingleData.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase JSonSingleData.\n
///             Implements the son single data class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Objeto JSonSingleData con un título y un solo mensaje.\n
    ///             JSonSingleData object with only one title and one message. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class JSonSingleData {

        private string b_Content;
        private string a_Title;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto.\n
        ///             Default constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public JSonSingleData() {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del título del objeto.\n
        ///             Get and set of the title of the object. </summary>
        ///
        /// <value> Título del objeto.\n
        ///         Title of the object </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string A_Title { get => a_Title; set => a_Title = value; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get y set del contenido del mensaje del objeto.\n
        ///             Get and set about the content of the message of the object. </summary>
        ///
        /// <value> Contenido del mensaje del objeto.\n
        ///         Content of the message of the object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string B_Content { get => b_Content; set => b_Content = value; }
    }
}

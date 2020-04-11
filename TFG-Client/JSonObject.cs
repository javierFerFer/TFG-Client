//============================================================================
// Name        : JSonObject.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : Model of JSon that is used to send and receive data
//               from the server
//============================================================================

///
/// Todos los using de la clase
/// 
/// All using of the class
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {
    /// <summary>
    /// Constructor de la clase.
    /// Establece un título para el JSon, así como un array de valores que va a contener el mismo.
    /// 
    /// Constructor of the class.
    /// Establishes title and content of the JSon
    /// </summary>
    public class JSonObject {

        private string[] content;
        private string title;
        /// <summary>
        /// Constructor vacío
        /// 
        /// Empty constructor
        /// </summary>
        public JSonObject() {
        }

        public string[] Content { get => content; set => content = value; }
        public string Title { get => title; set => title = value; }
    }
}

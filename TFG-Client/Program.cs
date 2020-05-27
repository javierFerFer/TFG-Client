////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\Program.cs </file>
///
/// <copyright file="Program.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase Program.\n
///             Implements the program class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase principal del programa </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Program {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Entrada principal del programa.\n
        ///             Main entry-point for this application. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 30/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormProgram());
        }
    }
}

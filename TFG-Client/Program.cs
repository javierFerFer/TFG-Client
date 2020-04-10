//============================================================================
// Name        : Program.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : Start of the program
//============================================================================

/**
 * Todos los using de la clase
 * 
 * All using here
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client{
    static class Program{
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// 
        /// Start of programgirada
        /// </summary>
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormProgram());
        }
    }
}

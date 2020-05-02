//============================================================================
// Name        : ModelWindowsMessage.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : This class is a model of windows that have:
//               - Tittle
//               - Message
//               - Image
//               - Close button
//============================================================================

/**
 * Todos los using de la clase
 * 
 * All using here
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class ModelWindowsMessageWithBroderWarning : Form {
        /// <summary>
        /// Constructor de la clase modelo de mensajes
        /// 
        /// Constructor of the model message class
        /// </summary>
        public ModelWindowsMessageWithBroderWarning() {
            InitializeComponent();
            panelUp.Height -= 9;
            panelDown.Height -= 9;
        }

        /// <summary>
        /// Evento de cierre del boton 'cerrar' de la ventana
        /// 
        /// Evento of close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e) {
            Utilities.warningAnser = false;
            Dispose();
        }

        private void buttonContinue_Click(object sender, EventArgs e) {
            Utilities.warningAnser = true;
            Dispose();
        }
    }
}

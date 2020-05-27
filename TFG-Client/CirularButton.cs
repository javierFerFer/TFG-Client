////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\CirularButton.cs </file>
///
/// <copyright file="CirularButton.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación del componente CircularButton.\n
///             Implements the cirular button class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Permite dibujar un botón circular.\n
    ///             Allow to draw circular button. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class CirularButton : Button {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Genera el evento.\n
        /// Generate the event.
        /// <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" />.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="pevent">
        /// Objeto <see cref="T:System.Windows.Forms.PaintEventArgs" /> que contiene los datos del evento.
        /// Object <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contain all data of event.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs pevent) {
            try {
                GraphicsPath gPath = new GraphicsPath();
                gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                Region = new System.Drawing.Region(gPath);
                base.OnPaint(pevent);
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 401, null);
            }
        }
    }
}

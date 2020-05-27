////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\MyOwnCircleComponent.cs </file>
///
/// <copyright file="MyOwnCircleComponent.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación del componente MyOwnCircleComponent.\n
///             Implements my own circle component class. </summary>
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
    /// <summary>   Componente circular propio.\n
    ///             Circular component </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MyOwnCircleComponent : PictureBox {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera el evento <see cref="E:System.Windows.Forms.Control.Paint" />.\n
        ///             Generate event <see cref="E:System.Windows.Forms.Control.Paint" />. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 19/04/2020. </remarks>
        ///
        /// <param name="pe">
        /// Objeto <see cref="T:System.Windows.Forms.PaintEventArgs" /> que contiene los datos del evento.
        /// Object <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contain all data of the event.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs pe) {
            try {
                GraphicsPath gPath = new GraphicsPath();
                gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                Region = new System.Drawing.Region(gPath);
                base.OnPaint(pe);
            } catch (Exception ex) {
                Utilities.createErrorMessage(ex.Message.ToString(), Utilities.showDevelopMessages, 406, null);
            }

        }
    }
}

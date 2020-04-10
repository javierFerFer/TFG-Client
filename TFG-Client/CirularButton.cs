//============================================================================
// Name        : CircularButton.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : This class allow to create circle buttons
//============================================================================

///
/// Todos los using de la clase
/// 
/// All using of the class
///
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    class CirularButton : Button {
        /// <summary>
        /// Constructor del componente que permite crear botones redondos
        /// 
        /// Constructor of the circle button component
        /// </summary>
        /// <param name="pevent">PaintEventArgs, evento que indica que se debe mostrar el componente en pantalla</param>
        /// <param name="pevent">PaintEventArgs, Event about 'paint' this component into screen</param>
        protected override void OnPaint(PaintEventArgs pevent) {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new System.Drawing.Region(gPath);
            base.OnPaint(pevent);
        }
    }
}

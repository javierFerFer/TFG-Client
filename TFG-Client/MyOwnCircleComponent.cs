//============================================================================
// Name        : MyOwnCircleComponent.cs
// Author      : Javier Fernández Fernández
// Version     : 0.1
// Copyright   : Your copyright notice
// Description : This class allow to create circle images
//============================================================================

/**
 * Todos los using de la clase
 * 
 * All using here
*/

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public class MyOwnCircleComponent : PictureBox {
        /// <summary>
        /// Constructor del componente que permite crear objetos redondos
        /// 
        /// Constructor of the circle component
        /// </summary>
        /// <param name="pe">PaintEventArgs, evento que indica que se debe mostrar el componente en pantalla</param>
        /// <param name="pe">PaintEventArgs, Event about 'paint' this component into screen</param>
        protected override void OnPaint(PaintEventArgs pe) {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new System.Drawing.Region(gPath);
            base.OnPaint(pe);
        }
    }
}

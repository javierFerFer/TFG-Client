using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    class MyOwnCircleComponent : PictureBox {
        protected override void OnPaint(PaintEventArgs pe) {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new System.Drawing.Region(gPath);
            base.OnPaint(pe);
        }
    }
}

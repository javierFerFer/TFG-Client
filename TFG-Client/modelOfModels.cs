using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class ModelOfModels : Form {

        private string id;
        private string nameOfModel;
        private string descriptionOfModel;
        private string autorOfModel;
        private Color borderColor = Color.FromArgb(247, 134, 5);
        public ModelOfModels(string idParam, string nameOfModelParam, string descriptionOfModelParam, string autorOfModelParam) {
            InitializeComponent();
            id = idParam;
            nameOfModel = nameOfModelParam;
            descriptionOfModel = descriptionOfModelParam;
            autorOfModel = autorOfModelParam;
            panelRight.Height -= 5;
            panelLeft.Height -= 5;
            setElementsOfModel();
        }

        private void setElementsOfModel() {
            labelAuthor.Text += autorOfModel;
            labelNameOfModel.Text = nameOfModel;
            labelDescriptionOfPanel.Text = descriptionOfModel;
        }

        public GraphicsPath GetRoundPath(RectangleF Rect, int radius) {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        private void typeOfDataPanel_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 50)) {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(borderColor, 1.75f)) {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }

        

        private void pictureBoxTextImage_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 50)) {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(borderColor, 1.75f)) {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }

        private void pictureBoxTextImage_Click(object sender, EventArgs e) {
            MessageBox.Show("soy el modelo numero " + id);
        }
    }
}

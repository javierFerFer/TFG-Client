////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\modelOfModels.cs </file>
///
/// <copyright file="modelOfModels.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase ModelOfModel.\n
///             Implements the model of models class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Modelo de diseño para los modelos de exámentes.\n
    ///             Model of the exams. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ModelOfModels : Form {

        private string id;
        private string nameOfModel;
        private string descriptionOfModel;
        private string autorOfModel;
        private Color borderColor = Color.FromArgb(247, 134, 5);

        // true = normal, false = test
        private bool mode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="idParam">                  ID del modelo del examen.\n
        ///                                         ID of model of the exam. </param>
        /// <param name="nameOfModelParam">         Nombre del modelo.\n
        ///                                         Name of the model. </param>
        /// <param name="descriptionOfModelParam">  Descripción del modelo.\n
        ///                                         Description of the model. </param>
        /// <param name="autorOfModelParam">        Email del autor del modelo.\n
        ///                                         Email of author of the model. </param>
        /// <param name="modeParam">                True = model normal, false = test model. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ModelOfModels(string idParam, string nameOfModelParam, string descriptionOfModelParam, string autorOfModelParam, bool modeParam) {
            InitializeComponent();
            id = idParam;
            nameOfModel = nameOfModelParam;
            descriptionOfModel = descriptionOfModelParam;
            autorOfModel = autorOfModelParam;
            mode = modeParam;
            panelRight.Height -= 5;
            panelLeft.Height -= 5;
            setElementsOfModel();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece los elementos del modelo.\n
        ///             Set elements of the model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void setElementsOfModel() {
            labelAuthor.Text += autorOfModel;
            labelNameOfModel.Text = nameOfModel;
            labelDescriptionOfPanel.Text = descriptionOfModel;
            setImage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establece la letra del creador del modelo </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void setImage() {
            if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "a") {
                imageLetterOfNameCreator.Image = Properties.Resources.A;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "b") {
                imageLetterOfNameCreator.Image = Properties.Resources.B;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "c") {
                imageLetterOfNameCreator.Image = Properties.Resources.C;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "d") {
                imageLetterOfNameCreator.Image = Properties.Resources.D;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "e") {
                imageLetterOfNameCreator.Image = Properties.Resources.E;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "f") {
                imageLetterOfNameCreator.Image = Properties.Resources.F;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "g") {
                imageLetterOfNameCreator.Image = Properties.Resources.G;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "h") {
                imageLetterOfNameCreator.Image = Properties.Resources.H;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "i") {
                imageLetterOfNameCreator.Image = Properties.Resources.I;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "j") {
                imageLetterOfNameCreator.Image = Properties.Resources.J;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "k") {
                imageLetterOfNameCreator.Image = Properties.Resources.K;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "l") {
                imageLetterOfNameCreator.Image = Properties.Resources.L;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "m") {
                imageLetterOfNameCreator.Image = Properties.Resources.M;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "n") {
                imageLetterOfNameCreator.Image = Properties.Resources.N;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "ñ") {
                imageLetterOfNameCreator.Image = Properties.Resources.Ñ;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "o") {
                imageLetterOfNameCreator.Image = Properties.Resources.O;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "p") {
                imageLetterOfNameCreator.Image = Properties.Resources.P;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "q") {
                imageLetterOfNameCreator.Image = Properties.Resources.Q;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "r") {
                imageLetterOfNameCreator.Image = Properties.Resources.R;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "s") {
                imageLetterOfNameCreator.Image = Properties.Resources.S;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "t") {
                imageLetterOfNameCreator.Image = Properties.Resources.T;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "u") {
                imageLetterOfNameCreator.Image = Properties.Resources.U;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "v") {
                imageLetterOfNameCreator.Image = Properties.Resources.V;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "w") {
                imageLetterOfNameCreator.Image = Properties.Resources.W;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "x") {
                imageLetterOfNameCreator.Image = Properties.Resources.X;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "y") {
                imageLetterOfNameCreator.Image = Properties.Resources.Y;
            } else if (autorOfModel.ToCharArray().ElementAt(0).ToString().ToLower() == "z") {
                imageLetterOfNameCreator.Image = Properties.Resources.Z;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera el redondeo de color del objeto.\n
        ///             Generate color round of the model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="Rect">     El rectángulo.\n
        ///                         The rectangle. </param>
        /// <param name="radius">   El radio.\n
        ///                         The radius. </param>
        ///
        /// <returns>   El diseño.\n
        ///             The round path. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de dibujado del modelo.\n
        ///             Event of draw the model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del dibujado del evento.\n
        ///                         Paint event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void typeOfDataPanel_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 50)) {
                Region = new Region(GraphPath);
                using (Pen pen = new Pen(borderColor, 1.75f)) {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de dibujado de la imagen.\n
        ///             Event of draw the image. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información del dibujado del evento.\n
        ///                         Paint event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre la imagen/modelo.\n
        ///             Click event about image/model. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 17/05/2020. </remarks>
        ///
        /// <param name="sender">   Código del evento.\n
        ///                         Source of the event. </param>
        /// <param name="e">        Información de evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBoxTextImage_Click(object sender, EventArgs e) {
            if (mode) {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllNormalQuestionsOfSpecificNormalModel", id);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllTestQuestionsOfSpecificTestModel", id);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }

        }


    }
}

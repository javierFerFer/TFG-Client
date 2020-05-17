namespace TFG_Client {
    partial class ModelOfModels {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelOfModels));
            this.typeOfDataPanel = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelDescriptionOfPanel = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelNameOfModel = new System.Windows.Forms.Label();
            this.imageLetterOfNameCreator = new TFG_Client.MyOwnCircleComponent();
            this.pictureBoxTextImage = new System.Windows.Forms.PictureBox();
            this.typeOfDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageLetterOfNameCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextImage)).BeginInit();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.imageLetterOfNameCreator);
            this.typeOfDataPanel.Controls.Add(this.panelRight);
            this.typeOfDataPanel.Controls.Add(this.panelLeft);
            this.typeOfDataPanel.Controls.Add(this.pictureBoxTextImage);
            this.typeOfDataPanel.Controls.Add(this.labelDescriptionOfPanel);
            this.typeOfDataPanel.Controls.Add(this.labelAuthor);
            this.typeOfDataPanel.Controls.Add(this.labelNameOfModel);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(315, 355);
            this.typeOfDataPanel.TabIndex = 2;
            this.typeOfDataPanel.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            this.typeOfDataPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.typeOfDataPanel_Paint);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.panelRight.Location = new System.Drawing.Point(168, 117);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(147, 10);
            this.panelRight.TabIndex = 18;
            this.panelRight.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.panelLeft.Location = new System.Drawing.Point(0, 117);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(143, 10);
            this.panelLeft.TabIndex = 17;
            this.panelLeft.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // labelDescriptionOfPanel
            // 
            this.labelDescriptionOfPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescriptionOfPanel.ForeColor = System.Drawing.Color.White;
            this.labelDescriptionOfPanel.Location = new System.Drawing.Point(11, 253);
            this.labelDescriptionOfPanel.Name = "labelDescriptionOfPanel";
            this.labelDescriptionOfPanel.Size = new System.Drawing.Size(292, 93);
            this.labelDescriptionOfPanel.TabIndex = 15;
            this.labelDescriptionOfPanel.Text = "Description of model";
            this.labelDescriptionOfPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDescriptionOfPanel.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.ForeColor = System.Drawing.Color.White;
            this.labelAuthor.Location = new System.Drawing.Point(7, 140);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(298, 78);
            this.labelAuthor.TabIndex = 14;
            this.labelAuthor.Text = "Correo del autor: ";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAuthor.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // labelNameOfModel
            // 
            this.labelNameOfModel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNameOfModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameOfModel.ForeColor = System.Drawing.Color.White;
            this.labelNameOfModel.Location = new System.Drawing.Point(7, 191);
            this.labelNameOfModel.Name = "labelNameOfModel";
            this.labelNameOfModel.Size = new System.Drawing.Size(295, 85);
            this.labelNameOfModel.TabIndex = 11;
            this.labelNameOfModel.Text = "Name of model";
            this.labelNameOfModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNameOfModel.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // imageLetterOfNameCreator
            // 
            this.imageLetterOfNameCreator.Image = global::TFG_Client.Properties.Resources.A;
            this.imageLetterOfNameCreator.Location = new System.Drawing.Point(133, 98);
            this.imageLetterOfNameCreator.Name = "imageLetterOfNameCreator";
            this.imageLetterOfNameCreator.Size = new System.Drawing.Size(53, 50);
            this.imageLetterOfNameCreator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageLetterOfNameCreator.TabIndex = 19;
            this.imageLetterOfNameCreator.TabStop = false;
            this.imageLetterOfNameCreator.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            // 
            // pictureBoxTextImage
            // 
            this.pictureBoxTextImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxTextImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTextImage.Image")));
            this.pictureBoxTextImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTextImage.Name = "pictureBoxTextImage";
            this.pictureBoxTextImage.Size = new System.Drawing.Size(315, 118);
            this.pictureBoxTextImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTextImage.TabIndex = 16;
            this.pictureBoxTextImage.TabStop = false;
            this.pictureBoxTextImage.Click += new System.EventHandler(this.pictureBoxTextImage_Click);
            this.pictureBoxTextImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTextImage_Paint);
            // 
            // ModelOfModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(315, 355);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "ModelOfModels";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageLetterOfNameCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Label labelNameOfModel;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelDescriptionOfPanel;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private MyOwnCircleComponent imageLetterOfNameCreator;
        private System.Windows.Forms.PictureBox pictureBoxTextImage;
    }
}
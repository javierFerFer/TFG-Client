namespace TFG_Client {
    partial class ModelWindowsMessage {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelWindowsMessage));
            this.ImageSchool = new System.Windows.Forms.PictureBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.flowLayoutTitle = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSchool)).BeginInit();
            this.flowLayoutTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageSchool
            // 
            this.ImageSchool.Image = ((System.Drawing.Image)(resources.GetObject("ImageSchool.Image")));
            this.ImageSchool.Location = new System.Drawing.Point(384, 51);
            this.ImageSchool.Name = "ImageSchool";
            this.ImageSchool.Size = new System.Drawing.Size(197, 116);
            this.ImageSchool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageSchool.TabIndex = 11;
            this.ImageSchool.TabStop = false;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(39, 79);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(74, 20);
            this.messageLabel.TabIndex = 10;
            this.messageLabel.Text = "message";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.DimGray;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(481, 196);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 29);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.Color.Black;
            this.panelDown.Location = new System.Drawing.Point(-7, 176);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(597, 10);
            this.panelDown.TabIndex = 8;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.Black;
            this.panelUp.Location = new System.Drawing.Point(-7, 36);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(597, 10);
            this.panelUp.TabIndex = 7;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(3, 4);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(132, 33);
            this.title.TabIndex = 6;
            this.title.Text = "titleLabel";
            // 
            // flowLayoutTitle
            // 
            this.flowLayoutTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutTitle.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutTitle.Controls.Add(this.title);
            this.flowLayoutTitle.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutTitle.Location = new System.Drawing.Point(-7, -1);
            this.flowLayoutTitle.Name = "flowLayoutTitle";
            this.flowLayoutTitle.Size = new System.Drawing.Size(597, 37);
            this.flowLayoutTitle.TabIndex = 13;
            // 
            // ModelWindowsMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 233);
            this.Controls.Add(this.flowLayoutTitle);
            this.Controls.Add(this.ImageSchool);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelWindowsMessage";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModelWindowsMessage";
            ((System.ComponentModel.ISupportInitialize)(this.ImageSchool)).EndInit();
            this.flowLayoutTitle.ResumeLayout(false);
            this.flowLayoutTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox ImageSchool;
        public System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelUp;
        public System.Windows.Forms.Label title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutTitle;
    }
}

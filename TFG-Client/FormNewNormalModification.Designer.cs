namespace TFG_Client {
    partial class FormNewNormalModification {
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
            this.infoNormalQuestionData = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.flowLayoutTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelQuestionInfo = new System.Windows.Forms.Label();
            this.textBoxNewQuest = new System.Windows.Forms.TextBox();
            this.labelInfoNewModification = new System.Windows.Forms.Label();
            this.flowLayoutPanelQuestionInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.flowLayoutTitle.SuspendLayout();
            this.flowLayoutPanelQuestionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoNormalQuestionData
            // 
            this.infoNormalQuestionData.AutoSize = true;
            this.infoNormalQuestionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoNormalQuestionData.Location = new System.Drawing.Point(18, 78);
            this.infoNormalQuestionData.Name = "infoNormalQuestionData";
            this.infoNormalQuestionData.Size = new System.Drawing.Size(398, 25);
            this.infoNormalQuestionData.TabIndex = 10;
            this.infoNormalQuestionData.Text = "Esta es la pregunta que desea modificar";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.DimGray;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(23, 433);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 29);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Cancelar";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.Color.Black;
            this.panelDown.Location = new System.Drawing.Point(-7, 401);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(908, 10);
            this.panelDown.TabIndex = 8;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.Black;
            this.panelUp.Location = new System.Drawing.Point(-7, 36);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(908, 10);
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
            this.flowLayoutTitle.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutTitle.Controls.Add(this.title);
            this.flowLayoutTitle.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutTitle.Location = new System.Drawing.Point(-7, -1);
            this.flowLayoutTitle.Name = "flowLayoutTitle";
            this.flowLayoutTitle.Size = new System.Drawing.Size(908, 37);
            this.flowLayoutTitle.TabIndex = 13;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.DimGray;
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.ForeColor = System.Drawing.Color.White;
            this.buttonSend.Location = new System.Drawing.Point(768, 433);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(80, 29);
            this.buttonSend.TabIndex = 14;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelQuestionInfo
            // 
            this.labelQuestionInfo.AutoSize = true;
            this.labelQuestionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionInfo.Location = new System.Drawing.Point(3, 0);
            this.labelQuestionInfo.Name = "labelQuestionInfo";
            this.labelQuestionInfo.Size = new System.Drawing.Size(0, 20);
            this.labelQuestionInfo.TabIndex = 15;
            // 
            // textBoxNewQuest
            // 
            this.textBoxNewQuest.Location = new System.Drawing.Point(23, 272);
            this.textBoxNewQuest.Multiline = true;
            this.textBoxNewQuest.Name = "textBoxNewQuest";
            this.textBoxNewQuest.Size = new System.Drawing.Size(629, 104);
            this.textBoxNewQuest.TabIndex = 16;
            this.textBoxNewQuest.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelInfoNewModification
            // 
            this.labelInfoNewModification.AutoSize = true;
            this.labelInfoNewModification.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoNewModification.Location = new System.Drawing.Point(18, 232);
            this.labelInfoNewModification.Name = "labelInfoNewModification";
            this.labelInfoNewModification.Size = new System.Drawing.Size(429, 25);
            this.labelInfoNewModification.TabIndex = 17;
            this.labelInfoNewModification.Text = "Escriba como desea que quede la pregunta";
            // 
            // flowLayoutPanelQuestionInfo
            // 
            this.flowLayoutPanelQuestionInfo.AutoScroll = true;
            this.flowLayoutPanelQuestionInfo.Controls.Add(this.labelQuestionInfo);
            this.flowLayoutPanelQuestionInfo.Location = new System.Drawing.Point(23, 116);
            this.flowLayoutPanelQuestionInfo.Name = "flowLayoutPanelQuestionInfo";
            this.flowLayoutPanelQuestionInfo.Size = new System.Drawing.Size(808, 100);
            this.flowLayoutPanelQuestionInfo.TabIndex = 18;
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(732, 311);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(99, 17);
            this.checkBoxDelete.TabIndex = 19;
            this.checkBoxDelete.Text = "Borrar pregunta";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.checkBoxDelete.CheckedChanged += new System.EventHandler(this.checkBoxDelete_CheckedChanged);
            // 
            // FormNewNormalModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 487);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.flowLayoutPanelQuestionInfo);
            this.Controls.Add(this.labelInfoNewModification);
            this.Controls.Add(this.textBoxNewQuest);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.flowLayoutTitle);
            this.Controls.Add(this.infoNormalQuestionData);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewNormalModification";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModelWindowsMessage";
            this.flowLayoutTitle.ResumeLayout(false);
            this.flowLayoutTitle.PerformLayout();
            this.flowLayoutPanelQuestionInfo.ResumeLayout(false);
            this.flowLayoutPanelQuestionInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label infoNormalQuestionData;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Panel panelDown;
        public System.Windows.Forms.Panel panelUp;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutTitle;
        private System.Windows.Forms.Button buttonSend;
        public System.Windows.Forms.Label labelQuestionInfo;
        private System.Windows.Forms.TextBox textBoxNewQuest;
        public System.Windows.Forms.Label labelInfoNewModification;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQuestionInfo;
        private System.Windows.Forms.CheckBox checkBoxDelete;
    }
}

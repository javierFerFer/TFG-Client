namespace TFG_Client {
    partial class FormNewTestModificationForModel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTestModificationForModel));
            this.closeButton = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.flowLayoutTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.infoNormalQuestionData = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelAnswerA = new System.Windows.Forms.Label();
            this.labelAnswerB = new System.Windows.Forms.Label();
            this.labelAnswerC = new System.Windows.Forms.Label();
            this.labelAnswerD = new System.Windows.Forms.Label();
            this.labelAnswerCorrect = new System.Windows.Forms.Label();
            this.pictureBoxSpaceBlack = new System.Windows.Forms.PictureBox();
            this.labelInfoModifications = new System.Windows.Forms.Label();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.textBoxNewQuest = new System.Windows.Forms.TextBox();
            this.labelNewQuest = new System.Windows.Forms.Label();
            this.labelNewAnserA = new System.Windows.Forms.Label();
            this.textBoxNewAnserA = new System.Windows.Forms.TextBox();
            this.labelNewAnserB = new System.Windows.Forms.Label();
            this.textBoxNewAnserB = new System.Windows.Forms.TextBox();
            this.labelNewAnserC = new System.Windows.Forms.Label();
            this.textBoxNewAnserC = new System.Windows.Forms.TextBox();
            this.labelNewAnserD = new System.Windows.Forms.Label();
            this.textBoxNewAnserD = new System.Windows.Forms.TextBox();
            this.labelNewAnserCorrect = new System.Windows.Forms.Label();
            this.comboBoxCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.flowLayoutTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.DimGray;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(12, 591);
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
            this.panelDown.Location = new System.Drawing.Point(-3, 561);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(1429, 10);
            this.panelDown.TabIndex = 8;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.Black;
            this.panelUp.Location = new System.Drawing.Point(-7, 36);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(1429, 10);
            this.panelUp.TabIndex = 7;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(3, 4);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(284, 33);
            this.title.TabIndex = 6;
            this.title.Text = "Pregunta a modificar";
            // 
            // flowLayoutTitle
            // 
            this.flowLayoutTitle.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutTitle.Controls.Add(this.title);
            this.flowLayoutTitle.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutTitle.Location = new System.Drawing.Point(-7, -1);
            this.flowLayoutTitle.Name = "flowLayoutTitle";
            this.flowLayoutTitle.Size = new System.Drawing.Size(1429, 37);
            this.flowLayoutTitle.TabIndex = 13;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.DimGray;
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.ForeColor = System.Drawing.Color.White;
            this.buttonSend.Location = new System.Drawing.Point(1327, 591);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(80, 29);
            this.buttonSend.TabIndex = 14;
            this.buttonSend.Text = "Modificar";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // infoNormalQuestionData
            // 
            this.infoNormalQuestionData.AutoSize = true;
            this.infoNormalQuestionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoNormalQuestionData.Location = new System.Drawing.Point(12, 72);
            this.infoNormalQuestionData.Name = "infoNormalQuestionData";
            this.infoNormalQuestionData.Size = new System.Drawing.Size(323, 25);
            this.infoNormalQuestionData.TabIndex = 15;
            this.infoNormalQuestionData.Text = "Datos de la pregunta a modificar";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(12, 141);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(111, 25);
            this.labelQuestion.TabIndex = 16;
            this.labelQuestion.Text = "Pregunta: ";
            // 
            // labelAnswerA
            // 
            this.labelAnswerA.AutoSize = true;
            this.labelAnswerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswerA.Location = new System.Drawing.Point(11, 215);
            this.labelAnswerA.Name = "labelAnswerA";
            this.labelAnswerA.Size = new System.Drawing.Size(147, 25);
            this.labelAnswerA.TabIndex = 17;
            this.labelAnswerA.Text = "Respuesta A: ";
            // 
            // labelAnswerB
            // 
            this.labelAnswerB.AutoSize = true;
            this.labelAnswerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswerB.Location = new System.Drawing.Point(12, 286);
            this.labelAnswerB.Name = "labelAnswerB";
            this.labelAnswerB.Size = new System.Drawing.Size(147, 25);
            this.labelAnswerB.TabIndex = 18;
            this.labelAnswerB.Text = "Respuesta B: ";
            // 
            // labelAnswerC
            // 
            this.labelAnswerC.AutoSize = true;
            this.labelAnswerC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswerC.Location = new System.Drawing.Point(12, 357);
            this.labelAnswerC.Name = "labelAnswerC";
            this.labelAnswerC.Size = new System.Drawing.Size(148, 25);
            this.labelAnswerC.TabIndex = 19;
            this.labelAnswerC.Text = "Respuesta C: ";
            // 
            // labelAnswerD
            // 
            this.labelAnswerD.AutoSize = true;
            this.labelAnswerD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswerD.Location = new System.Drawing.Point(12, 426);
            this.labelAnswerD.Name = "labelAnswerD";
            this.labelAnswerD.Size = new System.Drawing.Size(148, 25);
            this.labelAnswerD.TabIndex = 20;
            this.labelAnswerD.Text = "Respuesta D: ";
            // 
            // labelAnswerCorrect
            // 
            this.labelAnswerCorrect.AutoSize = true;
            this.labelAnswerCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswerCorrect.Location = new System.Drawing.Point(12, 491);
            this.labelAnswerCorrect.Name = "labelAnswerCorrect";
            this.labelAnswerCorrect.Size = new System.Drawing.Size(176, 25);
            this.labelAnswerCorrect.TabIndex = 21;
            this.labelAnswerCorrect.Text = "Opción correcta: ";
            // 
            // pictureBoxSpaceBlack
            // 
            this.pictureBoxSpaceBlack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSpaceBlack.Image")));
            this.pictureBoxSpaceBlack.Location = new System.Drawing.Point(691, 53);
            this.pictureBoxSpaceBlack.Name = "pictureBoxSpaceBlack";
            this.pictureBoxSpaceBlack.Size = new System.Drawing.Size(10, 489);
            this.pictureBoxSpaceBlack.TabIndex = 24;
            this.pictureBoxSpaceBlack.TabStop = false;
            // 
            // labelInfoModifications
            // 
            this.labelInfoModifications.AutoSize = true;
            this.labelInfoModifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoModifications.Location = new System.Drawing.Point(729, 72);
            this.labelInfoModifications.Name = "labelInfoModifications";
            this.labelInfoModifications.Size = new System.Drawing.Size(156, 25);
            this.labelInfoModifications.TabIndex = 25;
            this.labelInfoModifications.Text = "Modificaciones";
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(741, 499);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(99, 17);
            this.checkBoxDelete.TabIndex = 27;
            this.checkBoxDelete.Text = "Borrar pregunta";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.checkBoxDelete.CheckedChanged += new System.EventHandler(this.checkBoxDelete_CheckedChanged_1);
            // 
            // textBoxNewQuest
            // 
            this.textBoxNewQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewQuest.Location = new System.Drawing.Point(846, 140);
            this.textBoxNewQuest.Name = "textBoxNewQuest";
            this.textBoxNewQuest.Size = new System.Drawing.Size(415, 26);
            this.textBoxNewQuest.TabIndex = 26;
            // 
            // labelNewQuest
            // 
            this.labelNewQuest.AutoSize = true;
            this.labelNewQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewQuest.Location = new System.Drawing.Point(729, 141);
            this.labelNewQuest.Name = "labelNewQuest";
            this.labelNewQuest.Size = new System.Drawing.Size(111, 25);
            this.labelNewQuest.TabIndex = 28;
            this.labelNewQuest.Text = "Pregunta: ";
            // 
            // labelNewAnserA
            // 
            this.labelNewAnserA.AutoSize = true;
            this.labelNewAnserA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewAnserA.Location = new System.Drawing.Point(729, 215);
            this.labelNewAnserA.Name = "labelNewAnserA";
            this.labelNewAnserA.Size = new System.Drawing.Size(141, 25);
            this.labelNewAnserA.TabIndex = 30;
            this.labelNewAnserA.Text = "Respuesta A:";
            // 
            // textBoxNewAnserA
            // 
            this.textBoxNewAnserA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewAnserA.Location = new System.Drawing.Point(880, 214);
            this.textBoxNewAnserA.Name = "textBoxNewAnserA";
            this.textBoxNewAnserA.Size = new System.Drawing.Size(415, 26);
            this.textBoxNewAnserA.TabIndex = 29;
            // 
            // labelNewAnserB
            // 
            this.labelNewAnserB.AutoSize = true;
            this.labelNewAnserB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewAnserB.Location = new System.Drawing.Point(729, 286);
            this.labelNewAnserB.Name = "labelNewAnserB";
            this.labelNewAnserB.Size = new System.Drawing.Size(141, 25);
            this.labelNewAnserB.TabIndex = 32;
            this.labelNewAnserB.Text = "Respuesta B:";
            // 
            // textBoxNewAnserB
            // 
            this.textBoxNewAnserB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewAnserB.Location = new System.Drawing.Point(880, 285);
            this.textBoxNewAnserB.Name = "textBoxNewAnserB";
            this.textBoxNewAnserB.Size = new System.Drawing.Size(415, 26);
            this.textBoxNewAnserB.TabIndex = 31;
            // 
            // labelNewAnserC
            // 
            this.labelNewAnserC.AutoSize = true;
            this.labelNewAnserC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewAnserC.Location = new System.Drawing.Point(729, 357);
            this.labelNewAnserC.Name = "labelNewAnserC";
            this.labelNewAnserC.Size = new System.Drawing.Size(142, 25);
            this.labelNewAnserC.TabIndex = 34;
            this.labelNewAnserC.Text = "Respuesta C:";
            // 
            // textBoxNewAnserC
            // 
            this.textBoxNewAnserC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewAnserC.Location = new System.Drawing.Point(880, 356);
            this.textBoxNewAnserC.Name = "textBoxNewAnserC";
            this.textBoxNewAnserC.Size = new System.Drawing.Size(415, 26);
            this.textBoxNewAnserC.TabIndex = 33;
            // 
            // labelNewAnserD
            // 
            this.labelNewAnserD.AutoSize = true;
            this.labelNewAnserD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewAnserD.Location = new System.Drawing.Point(729, 426);
            this.labelNewAnserD.Name = "labelNewAnserD";
            this.labelNewAnserD.Size = new System.Drawing.Size(142, 25);
            this.labelNewAnserD.TabIndex = 36;
            this.labelNewAnserD.Text = "Respuesta D:";
            // 
            // textBoxNewAnserD
            // 
            this.textBoxNewAnserD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewAnserD.Location = new System.Drawing.Point(880, 425);
            this.textBoxNewAnserD.Name = "textBoxNewAnserD";
            this.textBoxNewAnserD.Size = new System.Drawing.Size(415, 26);
            this.textBoxNewAnserD.TabIndex = 35;
            // 
            // labelNewAnserCorrect
            // 
            this.labelNewAnserCorrect.AutoSize = true;
            this.labelNewAnserCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewAnserCorrect.Location = new System.Drawing.Point(1007, 492);
            this.labelNewAnserCorrect.Name = "labelNewAnserCorrect";
            this.labelNewAnserCorrect.Size = new System.Drawing.Size(205, 25);
            this.labelNewAnserCorrect.TabIndex = 38;
            this.labelNewAnserCorrect.Text = "Respuesta correcta:";
            // 
            // comboBoxCorrectAnswer
            // 
            this.comboBoxCorrectAnswer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCorrectAnswer.FormattingEnabled = true;
            this.comboBoxCorrectAnswer.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.comboBoxCorrectAnswer.Location = new System.Drawing.Point(1218, 495);
            this.comboBoxCorrectAnswer.Name = "comboBoxCorrectAnswer";
            this.comboBoxCorrectAnswer.Size = new System.Drawing.Size(77, 21);
            this.comboBoxCorrectAnswer.TabIndex = 39;
            // 
            // FormNewTestModificationForModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 633);
            this.Controls.Add(this.comboBoxCorrectAnswer);
            this.Controls.Add(this.labelNewAnserCorrect);
            this.Controls.Add(this.labelNewAnserD);
            this.Controls.Add(this.textBoxNewAnserD);
            this.Controls.Add(this.labelNewAnserC);
            this.Controls.Add(this.textBoxNewAnserC);
            this.Controls.Add(this.labelNewAnserB);
            this.Controls.Add(this.textBoxNewAnserB);
            this.Controls.Add(this.labelNewAnserA);
            this.Controls.Add(this.textBoxNewAnserA);
            this.Controls.Add(this.labelNewQuest);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.textBoxNewQuest);
            this.Controls.Add(this.labelInfoModifications);
            this.Controls.Add(this.pictureBoxSpaceBlack);
            this.Controls.Add(this.labelAnswerCorrect);
            this.Controls.Add(this.labelAnswerD);
            this.Controls.Add(this.labelAnswerC);
            this.Controls.Add(this.labelAnswerB);
            this.Controls.Add(this.labelAnswerA);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.infoNormalQuestionData);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.flowLayoutTitle);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1419, 633);
            this.MinimizeBox = false;
            this.Name = "FormNewTestModificationForModel";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModelWindowsMessage";
            this.flowLayoutTitle.ResumeLayout(false);
            this.flowLayoutTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceBlack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Panel panelDown;
        public System.Windows.Forms.Panel panelUp;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutTitle;
        private System.Windows.Forms.Button buttonSend;
        public System.Windows.Forms.Label infoNormalQuestionData;
        public System.Windows.Forms.Label labelQuestion;
        public System.Windows.Forms.Label labelAnswerA;
        public System.Windows.Forms.Label labelAnswerB;
        public System.Windows.Forms.Label labelAnswerC;
        public System.Windows.Forms.Label labelAnswerD;
        public System.Windows.Forms.Label labelAnswerCorrect;
        private System.Windows.Forms.PictureBox pictureBoxSpaceBlack;
        public System.Windows.Forms.Label labelInfoModifications;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.TextBox textBoxNewQuest;
        public System.Windows.Forms.Label labelNewQuest;
        public System.Windows.Forms.Label labelNewAnserA;
        private System.Windows.Forms.TextBox textBoxNewAnserA;
        public System.Windows.Forms.Label labelNewAnserB;
        private System.Windows.Forms.TextBox textBoxNewAnserB;
        public System.Windows.Forms.Label labelNewAnserC;
        private System.Windows.Forms.TextBox textBoxNewAnserC;
        public System.Windows.Forms.Label labelNewAnserD;
        private System.Windows.Forms.TextBox textBoxNewAnserD;
        public System.Windows.Forms.Label labelNewAnserCorrect;
        private System.Windows.Forms.ComboBox comboBoxCorrectAnswer;
    }
}

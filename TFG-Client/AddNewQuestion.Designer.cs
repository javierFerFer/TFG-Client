namespace TFG_Client {
    partial class AddNewQuestion {
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
            this.typeOfDataPanel = new System.Windows.Forms.Panel();
            this.labelInfoQuestion = new System.Windows.Forms.Label();
            this.textBoxNameOfTheme = new System.Windows.Forms.TextBox();
            this.checkBoxSelectedTheme = new System.Windows.Forms.CheckBox();
            this.checkBoxNewTheme = new System.Windows.Forms.CheckBox();
            this.labelAskNewTheme = new System.Windows.Forms.Label();
            this.comboBoxOfThemes = new System.Windows.Forms.ComboBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.subjectSelected = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.labelRequestTypeOfQuestion = new System.Windows.Forms.Label();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.labelInfoQuestion);
            this.typeOfDataPanel.Controls.Add(this.textBoxNameOfTheme);
            this.typeOfDataPanel.Controls.Add(this.checkBoxSelectedTheme);
            this.typeOfDataPanel.Controls.Add(this.checkBoxNewTheme);
            this.typeOfDataPanel.Controls.Add(this.labelAskNewTheme);
            this.typeOfDataPanel.Controls.Add(this.comboBoxOfThemes);
            this.typeOfDataPanel.Controls.Add(this.textBoxQuestion);
            this.typeOfDataPanel.Controls.Add(this.subjectSelected);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Controls.Add(this.sendButton);
            this.typeOfDataPanel.Controls.Add(this.labelRequestTypeOfQuestion);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // labelInfoQuestion
            // 
            this.labelInfoQuestion.AutoSize = true;
            this.labelInfoQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelInfoQuestion.Location = new System.Drawing.Point(174, 212);
            this.labelInfoQuestion.Name = "labelInfoQuestion";
            this.labelInfoQuestion.Size = new System.Drawing.Size(291, 18);
            this.labelInfoQuestion.TabIndex = 14;
            this.labelInfoQuestion.Text = "Escriba la pregunta que desea agregar aqui";
            // 
            // textBoxNameOfTheme
            // 
            this.textBoxNameOfTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBoxNameOfTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNameOfTheme.ForeColor = System.Drawing.Color.White;
            this.textBoxNameOfTheme.Location = new System.Drawing.Point(206, 411);
            this.textBoxNameOfTheme.Name = "textBoxNameOfTheme";
            this.textBoxNameOfTheme.Size = new System.Drawing.Size(340, 26);
            this.textBoxNameOfTheme.TabIndex = 13;
            this.textBoxNameOfTheme.TextChanged += new System.EventHandler(this.textBoxNameOfTheme_TextChanged);
            this.textBoxNameOfTheme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNameOfTheme_KeyPress);
            // 
            // checkBoxSelectedTheme
            // 
            this.checkBoxSelectedTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSelectedTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSelectedTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxSelectedTheme.Location = new System.Drawing.Point(737, 349);
            this.checkBoxSelectedTheme.Name = "checkBoxSelectedTheme";
            this.checkBoxSelectedTheme.Size = new System.Drawing.Size(198, 51);
            this.checkBoxSelectedTheme.TabIndex = 12;
            this.checkBoxSelectedTheme.Text = "Seleccionar tema";
            this.checkBoxSelectedTheme.UseVisualStyleBackColor = true;
            this.checkBoxSelectedTheme.CheckedChanged += new System.EventHandler(this.checkBoxSelectedTheme_CheckedChanged);
            // 
            // checkBoxNewTheme
            // 
            this.checkBoxNewTheme.Checked = true;
            this.checkBoxNewTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNewTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNewTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNewTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxNewTheme.Location = new System.Drawing.Point(585, 349);
            this.checkBoxNewTheme.Name = "checkBoxNewTheme";
            this.checkBoxNewTheme.Size = new System.Drawing.Size(165, 51);
            this.checkBoxNewTheme.TabIndex = 11;
            this.checkBoxNewTheme.Text = "Nuevo tema";
            this.checkBoxNewTheme.UseVisualStyleBackColor = true;
            this.checkBoxNewTheme.CheckedChanged += new System.EventHandler(this.checkBoxNewTheme_CheckedChanged);
            // 
            // labelAskNewTheme
            // 
            this.labelAskNewTheme.AutoSize = true;
            this.labelAskNewTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAskNewTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelAskNewTheme.Location = new System.Drawing.Point(201, 363);
            this.labelAskNewTheme.Name = "labelAskNewTheme";
            this.labelAskNewTheme.Size = new System.Drawing.Size(354, 18);
            this.labelAskNewTheme.TabIndex = 10;
            this.labelAskNewTheme.Text = "¿Desea agregarlo a un tema o crear un tema nuevo?";
            // 
            // comboBoxOfThemes
            // 
            this.comboBoxOfThemes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBoxOfThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOfThemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOfThemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOfThemes.ForeColor = System.Drawing.Color.White;
            this.comboBoxOfThemes.FormattingEnabled = true;
            this.comboBoxOfThemes.Location = new System.Drawing.Point(207, 410);
            this.comboBoxOfThemes.Name = "comboBoxOfThemes";
            this.comboBoxOfThemes.Size = new System.Drawing.Size(337, 28);
            this.comboBoxOfThemes.TabIndex = 9;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuestion.ForeColor = System.Drawing.Color.White;
            this.textBoxQuestion.Location = new System.Drawing.Point(175, 239);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(629, 104);
            this.textBoxQuestion.TabIndex = 8;
            this.textBoxQuestion.TextChanged += new System.EventHandler(this.textBoxQuestion_TextChanged_1);
            this.textBoxQuestion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQuestion_KeyDown);
            // 
            // subjectSelected
            // 
            this.subjectSelected.AutoSize = true;
            this.subjectSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.subjectSelected.Location = new System.Drawing.Point(172, 170);
            this.subjectSelected.Name = "subjectSelected";
            this.subjectSelected.Size = new System.Drawing.Size(138, 29);
            this.subjectSelected.TabIndex = 7;
            this.subjectSelected.Text = "Asignatura: ";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(80, 520);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(785, 520);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(108, 37);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Enviar";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // labelRequestTypeOfQuestion
            // 
            this.labelRequestTypeOfQuestion.AutoSize = true;
            this.labelRequestTypeOfQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequestTypeOfQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelRequestTypeOfQuestion.Location = new System.Drawing.Point(170, 117);
            this.labelRequestTypeOfQuestion.Name = "labelRequestTypeOfQuestion";
            this.labelRequestTypeOfQuestion.Size = new System.Drawing.Size(636, 39);
            this.labelRequestTypeOfQuestion.TabIndex = 2;
            this.labelRequestTypeOfQuestion.Text = "Petición de agregación de pregunta tipo: ";
            // 
            // AddNewQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewQuestion";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Label labelRequestTypeOfQuestion;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button sendButton;
        public System.Windows.Forms.Label subjectSelected;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.ComboBox comboBoxOfThemes;
        private System.Windows.Forms.Label labelAskNewTheme;
        private System.Windows.Forms.CheckBox checkBoxSelectedTheme;
        private System.Windows.Forms.CheckBox checkBoxNewTheme;
        private System.Windows.Forms.TextBox textBoxNameOfTheme;
        private System.Windows.Forms.Label labelInfoQuestion;
    }
}
namespace TFG_Client {
    partial class AllDataNormalModel {
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
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelInfoQuestion = new System.Windows.Forms.Label();
            this.textBoxNameOfModel = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.typeOfModel = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.labelRequestNewNormalModel = new System.Windows.Forms.Label();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.labelDescription);
            this.typeOfDataPanel.Controls.Add(this.labelInfoQuestion);
            this.typeOfDataPanel.Controls.Add(this.textBoxNameOfModel);
            this.typeOfDataPanel.Controls.Add(this.textBoxDescription);
            this.typeOfDataPanel.Controls.Add(this.typeOfModel);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Controls.Add(this.sendButton);
            this.typeOfDataPanel.Controls.Add(this.labelRequestNewNormalModel);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelDescription.Location = new System.Drawing.Point(174, 325);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(268, 18);
            this.labelDescription.TabIndex = 15;
            this.labelDescription.Text = "Escriba una descripción para el modelo";
            // 
            // labelInfoQuestion
            // 
            this.labelInfoQuestion.AutoSize = true;
            this.labelInfoQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelInfoQuestion.Location = new System.Drawing.Point(174, 226);
            this.labelInfoQuestion.Name = "labelInfoQuestion";
            this.labelInfoQuestion.Size = new System.Drawing.Size(210, 18);
            this.labelInfoQuestion.TabIndex = 14;
            this.labelInfoQuestion.Text = "Escriba el título para el modelo";
            // 
            // textBoxNameOfModel
            // 
            this.textBoxNameOfModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBoxNameOfModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNameOfModel.ForeColor = System.Drawing.Color.White;
            this.textBoxNameOfModel.Location = new System.Drawing.Point(177, 250);
            this.textBoxNameOfModel.Name = "textBoxNameOfModel";
            this.textBoxNameOfModel.Size = new System.Drawing.Size(380, 26);
            this.textBoxNameOfModel.TabIndex = 13;
            this.textBoxNameOfModel.TextChanged += new System.EventHandler(this.textBoxNameOfTheme_TextChanged);
            this.textBoxNameOfModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNameOfModel_KeyDown);
            this.textBoxNameOfModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNameOfTheme_KeyPress);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.White;
            this.textBoxDescription.Location = new System.Drawing.Point(177, 349);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(629, 104);
            this.textBoxDescription.TabIndex = 8;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxQuestion_TextChanged_1);
            this.textBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQuestion_KeyDown);
            // 
            // typeOfModel
            // 
            this.typeOfModel.AutoSize = true;
            this.typeOfModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeOfModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.typeOfModel.Location = new System.Drawing.Point(172, 170);
            this.typeOfModel.Name = "typeOfModel";
            this.typeOfModel.Size = new System.Drawing.Size(197, 29);
            this.typeOfModel.TabIndex = 7;
            this.typeOfModel.Text = "Tipo de modelo: ";
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
            // labelRequestNewNormalModel
            // 
            this.labelRequestNewNormalModel.AutoSize = true;
            this.labelRequestNewNormalModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequestNewNormalModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelRequestNewNormalModel.Location = new System.Drawing.Point(170, 117);
            this.labelRequestNewNormalModel.Name = "labelRequestNewNormalModel";
            this.labelRequestNewNormalModel.Size = new System.Drawing.Size(436, 39);
            this.labelRequestNewNormalModel.TabIndex = 2;
            this.labelRequestNewNormalModel.Text = "Datos del modelo a guardar";
            // 
            // AllDataNormalModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "AllDataNormalModel";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Label labelRequestNewNormalModel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button sendButton;
        public System.Windows.Forms.Label typeOfModel;
        private System.Windows.Forms.TextBox textBoxNameOfModel;
        private System.Windows.Forms.Label labelInfoQuestion;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
    }
}
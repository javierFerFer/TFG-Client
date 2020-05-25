namespace TFG_Client {
    partial class AskOperation {
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
            this.subjectSelected = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxModify = new System.Windows.Forms.CheckBox();
            this.labelAskTypeOfOperation = new System.Windows.Forms.Label();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.subjectSelected);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Controls.Add(this.nextButton);
            this.typeOfDataPanel.Controls.Add(this.checkBoxAdd);
            this.typeOfDataPanel.Controls.Add(this.checkBoxModify);
            this.typeOfDataPanel.Controls.Add(this.labelAskTypeOfOperation);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // subjectSelected
            // 
            this.subjectSelected.AutoSize = true;
            this.subjectSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.subjectSelected.Location = new System.Drawing.Point(170, 245);
            this.subjectSelected.Name = "subjectSelected";
            this.subjectSelected.Size = new System.Drawing.Size(198, 39);
            this.subjectSelected.TabIndex = 7;
            this.subjectSelected.Text = "Asignatura: ";
            this.subjectSelected.Click += new System.EventHandler(this.subjectSelected_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(177, 520);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(785, 520);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(108, 37);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Siguiente";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxAdd.Location = new System.Drawing.Point(590, 364);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(198, 51);
            this.checkBoxAdd.TabIndex = 4;
            this.checkBoxAdd.Text = "Agregar";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            this.checkBoxAdd.CheckedChanged += new System.EventHandler(this.checkBoxAdd_CheckedChanged);
            // 
            // checkBoxModify
            // 
            this.checkBoxModify.Checked = true;
            this.checkBoxModify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxModify.Location = new System.Drawing.Point(214, 364);
            this.checkBoxModify.Name = "checkBoxModify";
            this.checkBoxModify.Size = new System.Drawing.Size(165, 51);
            this.checkBoxModify.TabIndex = 3;
            this.checkBoxModify.Text = "Modificar";
            this.checkBoxModify.UseVisualStyleBackColor = true;
            this.checkBoxModify.CheckedChanged += new System.EventHandler(this.checkBoxModify_CheckedChanged);
            // 
            // labelAskTypeOfOperation
            // 
            this.labelAskTypeOfOperation.AutoSize = true;
            this.labelAskTypeOfOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAskTypeOfOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelAskTypeOfOperation.Location = new System.Drawing.Point(170, 171);
            this.labelAskTypeOfOperation.Name = "labelAskTypeOfOperation";
            this.labelAskTypeOfOperation.Size = new System.Drawing.Size(618, 39);
            this.labelAskTypeOfOperation.TabIndex = 2;
            this.labelAskTypeOfOperation.Text = "¿Quiere modificar o agregar preguntas?";
            this.labelAskTypeOfOperation.Click += new System.EventHandler(this.labelAskTypeOfOperation_Click);
            // 
            // AskOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "AskOperation";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Label labelAskTypeOfOperation;
        public System.Windows.Forms.CheckBox checkBoxModify;
        public System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button nextButton;
        public System.Windows.Forms.Label subjectSelected;
    }
}
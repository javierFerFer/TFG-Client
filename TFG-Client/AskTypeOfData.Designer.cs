namespace TFG_Client {
    partial class AskTypeOfData {
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
            this.emptyRightPanel = new System.Windows.Forms.Panel();
            this.typeOfDataPanel = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.checkBoxNormal = new System.Windows.Forms.CheckBox();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.labelAskTypeOfData = new System.Windows.Forms.Label();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // emptyRightPanel
            // 
            this.emptyRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.emptyRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.emptyRightPanel.Location = new System.Drawing.Point(912, 0);
            this.emptyRightPanel.Name = "emptyRightPanel";
            this.emptyRightPanel.Size = new System.Drawing.Size(340, 578);
            this.emptyRightPanel.TabIndex = 1;
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Controls.Add(this.nextButton);
            this.typeOfDataPanel.Controls.Add(this.checkBoxNormal);
            this.typeOfDataPanel.Controls.Add(this.checkBoxTest);
            this.typeOfDataPanel.Controls.Add(this.labelAskTypeOfData);
            this.typeOfDataPanel.Location = new System.Drawing.Point(-2, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(917, 578);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(79, 434);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Atrás";
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
            this.nextButton.Location = new System.Drawing.Point(788, 434);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(108, 37);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Siguiente";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // checkBoxNormal
            // 
            this.checkBoxNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxNormal.Location = new System.Drawing.Point(519, 278);
            this.checkBoxNormal.Name = "checkBoxNormal";
            this.checkBoxNormal.Size = new System.Drawing.Size(198, 51);
            this.checkBoxNormal.TabIndex = 4;
            this.checkBoxNormal.Text = "Normal";
            this.checkBoxNormal.UseVisualStyleBackColor = true;
            this.checkBoxNormal.CheckedChanged += new System.EventHandler(this.checkBoxNormal_CheckedChanged);
            // 
            // checkBoxTest
            // 
            this.checkBoxTest.Checked = true;
            this.checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxTest.Location = new System.Drawing.Point(213, 278);
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.Size = new System.Drawing.Size(165, 51);
            this.checkBoxTest.TabIndex = 3;
            this.checkBoxTest.Text = "Test";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            this.checkBoxTest.CheckedChanged += new System.EventHandler(this.checkBoxTest_CheckedChanged);
            // 
            // labelAskTypeOfData
            // 
            this.labelAskTypeOfData.AutoSize = true;
            this.labelAskTypeOfData.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAskTypeOfData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelAskTypeOfData.Location = new System.Drawing.Point(169, 130);
            this.labelAskTypeOfData.Name = "labelAskTypeOfData";
            this.labelAskTypeOfData.Size = new System.Drawing.Size(609, 39);
            this.labelAskTypeOfData.TabIndex = 2;
            this.labelAskTypeOfData.Text = "¿Quiere ver tipo tipo test o tipo normal?";
            // 
            // AskTypeOfData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 578);
            this.Controls.Add(this.typeOfDataPanel);
            this.Controls.Add(this.emptyRightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AskTypeOfData";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel emptyRightPanel;
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Label labelAskTypeOfData;
        private System.Windows.Forms.CheckBox checkBoxTest;
        private System.Windows.Forms.CheckBox checkBoxNormal;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button nextButton;
    }
}
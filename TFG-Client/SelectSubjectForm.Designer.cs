﻿namespace TFG_Client {
    partial class SelectSubjectForm {
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
            this.labelStudents = new System.Windows.Forms.Label();
            this.labelThemes = new System.Windows.Forms.Label();
            this.comboBoxNumberOfStudents = new System.Windows.Forms.ComboBox();
            this.labelWaitData = new System.Windows.Forms.Label();
            this.comboBoxOfThemes = new System.Windows.Forms.ComboBox();
            this.subjectSelected = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.labelRequestTypeOfExam = new System.Windows.Forms.Label();
            this.checkBoxSaveAsModel = new System.Windows.Forms.CheckBox();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.checkBoxSaveAsModel);
            this.typeOfDataPanel.Controls.Add(this.labelStudents);
            this.typeOfDataPanel.Controls.Add(this.labelThemes);
            this.typeOfDataPanel.Controls.Add(this.comboBoxNumberOfStudents);
            this.typeOfDataPanel.Controls.Add(this.labelWaitData);
            this.typeOfDataPanel.Controls.Add(this.comboBoxOfThemes);
            this.typeOfDataPanel.Controls.Add(this.subjectSelected);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Controls.Add(this.sendButton);
            this.typeOfDataPanel.Controls.Add(this.labelRequestTypeOfExam);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // labelStudents
            // 
            this.labelStudents.AutoSize = true;
            this.labelStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelStudents.Location = new System.Drawing.Point(576, 330);
            this.labelStudents.Name = "labelStudents";
            this.labelStudents.Size = new System.Drawing.Size(170, 29);
            this.labelStudents.TabIndex = 13;
            this.labelStudents.Text = "Nº de alumnos";
            // 
            // labelThemes
            // 
            this.labelThemes.AutoSize = true;
            this.labelThemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelThemes.Location = new System.Drawing.Point(115, 330);
            this.labelThemes.Name = "labelThemes";
            this.labelThemes.Size = new System.Drawing.Size(88, 29);
            this.labelThemes.TabIndex = 12;
            this.labelThemes.Text = "Temas";
            // 
            // comboBoxNumberOfStudents
            // 
            this.comboBoxNumberOfStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBoxNumberOfStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNumberOfStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNumberOfStudents.ForeColor = System.Drawing.Color.White;
            this.comboBoxNumberOfStudents.FormattingEnabled = true;
            this.comboBoxNumberOfStudents.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBoxNumberOfStudents.Location = new System.Drawing.Point(581, 384);
            this.comboBoxNumberOfStudents.Name = "comboBoxNumberOfStudents";
            this.comboBoxNumberOfStudents.Size = new System.Drawing.Size(78, 28);
            this.comboBoxNumberOfStudents.TabIndex = 11;
            // 
            // labelWaitData
            // 
            this.labelWaitData.AutoSize = true;
            this.labelWaitData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaitData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelWaitData.Location = new System.Drawing.Point(115, 276);
            this.labelWaitData.Name = "labelWaitData";
            this.labelWaitData.Size = new System.Drawing.Size(347, 29);
            this.labelWaitData.TabIndex = 10;
            this.labelWaitData.Text = "Esperando datos del servidor...";
            // 
            // comboBoxOfThemes
            // 
            this.comboBoxOfThemes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBoxOfThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOfThemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOfThemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOfThemes.ForeColor = System.Drawing.Color.White;
            this.comboBoxOfThemes.FormattingEnabled = true;
            this.comboBoxOfThemes.Location = new System.Drawing.Point(120, 384);
            this.comboBoxOfThemes.Name = "comboBoxOfThemes";
            this.comboBoxOfThemes.Size = new System.Drawing.Size(337, 28);
            this.comboBoxOfThemes.TabIndex = 9;
            // 
            // subjectSelected
            // 
            this.subjectSelected.AutoSize = true;
            this.subjectSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.subjectSelected.Location = new System.Drawing.Point(115, 216);
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
            // labelRequestTypeOfExam
            // 
            this.labelRequestTypeOfExam.AutoSize = true;
            this.labelRequestTypeOfExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequestTypeOfExam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelRequestTypeOfExam.Location = new System.Drawing.Point(113, 112);
            this.labelRequestTypeOfExam.Name = "labelRequestTypeOfExam";
            this.labelRequestTypeOfExam.Size = new System.Drawing.Size(393, 39);
            this.labelRequestTypeOfExam.TabIndex = 2;
            this.labelRequestTypeOfExam.Text = "Tipo de examen a crear: ";
            // 
            // checkBoxSaveAsModel
            // 
            this.checkBoxSaveAsModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSaveAsModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSaveAsModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.checkBoxSaveAsModel.Location = new System.Drawing.Point(581, 433);
            this.checkBoxSaveAsModel.Name = "checkBoxSaveAsModel";
            this.checkBoxSaveAsModel.Size = new System.Drawing.Size(312, 51);
            this.checkBoxSaveAsModel.TabIndex = 14;
            this.checkBoxSaveAsModel.Text = "¿Va a guardar el examen como modelo?";
            this.checkBoxSaveAsModel.UseVisualStyleBackColor = true;
            // 
            // SelectSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectSubjectForm";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox comboBoxOfThemes;
        public System.Windows.Forms.Label subjectSelected;
        private System.Windows.Forms.Label labelRequestTypeOfExam;
        private System.Windows.Forms.Label labelWaitData;
        private System.Windows.Forms.Label labelThemes;
        private System.Windows.Forms.ComboBox comboBoxNumberOfStudents;
        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.CheckBox checkBoxSaveAsModel;
    }
}
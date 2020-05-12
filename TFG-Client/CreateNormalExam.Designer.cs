namespace TFG_Client {
    partial class CreateNormalExam {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNormalExam));
            this.typeOfDataPanel = new System.Windows.Forms.Panel();
            this.labelWaitQuestions = new System.Windows.Forms.Label();
            this.labelListAllQuestions = new System.Windows.Forms.Label();
            this.labelInfoMyQuestions = new System.Windows.Forms.Label();
            this.dataGridViewMyQuestions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSend = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.errorNoQuestionsFound = new System.Windows.Forms.Label();
            this.dataGridViewAllNormalData = new System.Windows.Forms.DataGridView();
            this.IDNormalQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxFindQuestion = new System.Windows.Forms.TextBox();
            this.pictureBoxSearchQuestion = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.typeOfDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.labelWaitQuestions);
            this.typeOfDataPanel.Controls.Add(this.labelListAllQuestions);
            this.typeOfDataPanel.Controls.Add(this.labelInfoMyQuestions);
            this.typeOfDataPanel.Controls.Add(this.dataGridViewMyQuestions);
            this.typeOfDataPanel.Controls.Add(this.buttonSend);
            this.typeOfDataPanel.Controls.Add(this.resetButton);
            this.typeOfDataPanel.Controls.Add(this.searchButton);
            this.typeOfDataPanel.Controls.Add(this.errorNoQuestionsFound);
            this.typeOfDataPanel.Controls.Add(this.dataGridViewAllNormalData);
            this.typeOfDataPanel.Controls.Add(this.textBoxFindQuestion);
            this.typeOfDataPanel.Controls.Add(this.pictureBoxSearchQuestion);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // labelWaitQuestions
            // 
            this.labelWaitQuestions.AutoSize = true;
            this.labelWaitQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaitQuestions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelWaitQuestions.Location = new System.Drawing.Point(12, 329);
            this.labelWaitQuestions.Name = "labelWaitQuestions";
            this.labelWaitQuestions.Size = new System.Drawing.Size(347, 29);
            this.labelWaitQuestions.TabIndex = 19;
            this.labelWaitQuestions.Text = "Esperando datos del servidor...";
            // 
            // labelListAllQuestions
            // 
            this.labelListAllQuestions.AutoSize = true;
            this.labelListAllQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListAllQuestions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelListAllQuestions.Location = new System.Drawing.Point(12, 54);
            this.labelListAllQuestions.Name = "labelListAllQuestions";
            this.labelListAllQuestions.Size = new System.Drawing.Size(238, 29);
            this.labelListAllQuestions.TabIndex = 18;
            this.labelListAllQuestions.Text = "Listado de preguntas";
            // 
            // labelInfoMyQuestions
            // 
            this.labelInfoMyQuestions.AutoSize = true;
            this.labelInfoMyQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoMyQuestions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.labelInfoMyQuestions.Location = new System.Drawing.Point(12, 329);
            this.labelInfoMyQuestions.Name = "labelInfoMyQuestions";
            this.labelInfoMyQuestions.Size = new System.Drawing.Size(279, 29);
            this.labelInfoMyQuestions.TabIndex = 17;
            this.labelInfoMyQuestions.Text = "Preguntas de mi examen";
            // 
            // dataGridViewMyQuestions
            // 
            this.dataGridViewMyQuestions.AllowUserToAddRows = false;
            this.dataGridViewMyQuestions.AllowUserToDeleteRows = false;
            this.dataGridViewMyQuestions.AllowUserToResizeColumns = false;
            this.dataGridViewMyQuestions.AllowUserToResizeRows = false;
            this.dataGridViewMyQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMyQuestions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewMyQuestions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.dataGridViewMyQuestions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMyQuestions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewMyQuestions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMyQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewMyQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewMyQuestions.EnableHeadersVisualStyles = false;
            this.dataGridViewMyQuestions.GridColor = System.Drawing.Color.White;
            this.dataGridViewMyQuestions.Location = new System.Drawing.Point(13, 361);
            this.dataGridViewMyQuestions.MultiSelect = false;
            this.dataGridViewMyQuestions.Name = "dataGridViewMyQuestions";
            this.dataGridViewMyQuestions.ReadOnly = true;
            this.dataGridViewMyQuestions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewMyQuestions.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMyQuestions.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewMyQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMyQuestions.Size = new System.Drawing.Size(881, 227);
            this.dataGridViewMyQuestions.TabIndex = 16;
            this.dataGridViewMyQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyQuestions_CellDoubleClick);
            this.dataGridViewMyQuestions.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyQuestions_CellMouseEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Pregunta";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.ForeColor = System.Drawing.Color.White;
            this.buttonSend.Location = new System.Drawing.Point(804, 598);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(89, 37);
            this.buttonSend.TabIndex = 15;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(805, 14);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(89, 37);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(692, 14);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(89, 37);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Buscar";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // errorNoQuestionsFound
            // 
            this.errorNoQuestionsFound.AutoSize = true;
            this.errorNoQuestionsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorNoQuestionsFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.errorNoQuestionsFound.Location = new System.Drawing.Point(68, 329);
            this.errorNoQuestionsFound.Name = "errorNoQuestionsFound";
            this.errorNoQuestionsFound.Size = new System.Drawing.Size(607, 29);
            this.errorNoQuestionsFound.TabIndex = 12;
            this.errorNoQuestionsFound.Text = "No se han encontrado preguntas asociadas a este tema";
            // 
            // dataGridViewAllNormalData
            // 
            this.dataGridViewAllNormalData.AllowUserToAddRows = false;
            this.dataGridViewAllNormalData.AllowUserToDeleteRows = false;
            this.dataGridViewAllNormalData.AllowUserToResizeColumns = false;
            this.dataGridViewAllNormalData.AllowUserToResizeRows = false;
            this.dataGridViewAllNormalData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAllNormalData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAllNormalData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.dataGridViewAllNormalData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAllNormalData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewAllNormalData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAllNormalData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewAllNormalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllNormalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNormalQuestion,
            this.question});
            this.dataGridViewAllNormalData.EnableHeadersVisualStyles = false;
            this.dataGridViewAllNormalData.GridColor = System.Drawing.Color.White;
            this.dataGridViewAllNormalData.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewAllNormalData.MultiSelect = false;
            this.dataGridViewAllNormalData.Name = "dataGridViewAllNormalData";
            this.dataGridViewAllNormalData.ReadOnly = true;
            this.dataGridViewAllNormalData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAllNormalData.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAllNormalData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewAllNormalData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllNormalData.Size = new System.Drawing.Size(881, 242);
            this.dataGridViewAllNormalData.TabIndex = 11;
            this.dataGridViewAllNormalData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllNormalData_CellDoubleClick);
            this.dataGridViewAllNormalData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllNormalData_CellMouseEnter);
            // 
            // IDNormalQuestion
            // 
            this.IDNormalQuestion.HeaderText = "ID";
            this.IDNormalQuestion.Name = "IDNormalQuestion";
            this.IDNormalQuestion.ReadOnly = true;
            this.IDNormalQuestion.Width = 50;
            // 
            // question
            // 
            this.question.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.question.HeaderText = "Pregunta";
            this.question.Name = "question";
            this.question.ReadOnly = true;
            // 
            // textBoxFindQuestion
            // 
            this.textBoxFindQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.textBoxFindQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFindQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFindQuestion.ForeColor = System.Drawing.Color.White;
            this.textBoxFindQuestion.Location = new System.Drawing.Point(45, 23);
            this.textBoxFindQuestion.Name = "textBoxFindQuestion";
            this.textBoxFindQuestion.Size = new System.Drawing.Size(621, 20);
            this.textBoxFindQuestion.TabIndex = 10;
            this.textBoxFindQuestion.Text = "Nombre de la pregunta a buscar...";
            this.textBoxFindQuestion.TextChanged += new System.EventHandler(this.textBoxFindQuestion_TextChanged);
            this.textBoxFindQuestion.Enter += new System.EventHandler(this.textBoxFindQuestion_Enter);
            // 
            // pictureBoxSearchQuestion
            // 
            this.pictureBoxSearchQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearchQuestion.Image")));
            this.pictureBoxSearchQuestion.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxSearchQuestion.Name = "pictureBoxSearchQuestion";
            this.pictureBoxSearchQuestion.Size = new System.Drawing.Size(674, 39);
            this.pictureBoxSearchQuestion.TabIndex = 9;
            this.pictureBoxSearchQuestion.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(12, 598);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // CreateNormalExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "CreateNormalExam";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInfoMyQuestions;
        private System.Windows.Forms.DataGridView dataGridViewMyQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label errorNoQuestionsFound;
        private System.Windows.Forms.DataGridView dataGridViewAllNormalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        private System.Windows.Forms.TextBox textBoxFindQuestion;
        private System.Windows.Forms.PictureBox pictureBoxSearchQuestion;
        private System.Windows.Forms.Label labelListAllQuestions;
        private System.Windows.Forms.Label labelWaitQuestions;
    }
}
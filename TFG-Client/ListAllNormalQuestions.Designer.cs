namespace TFG_Client {
    partial class ListAllNormalQuestions {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListAllNormalQuestions));
            this.panelInternal = new System.Windows.Forms.Panel();
            this.panelAllData = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.errorNoQuestionsFound = new System.Windows.Forms.Label();
            this.dataGridViewAllNormalData = new System.Windows.Forms.DataGridView();
            this.IDNormalQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxFindQuestion = new System.Windows.Forms.TextBox();
            this.pictureBoxSearchQuestion = new System.Windows.Forms.PictureBox();
            this.panelInternal.SuspendLayout();
            this.panelAllData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInternal
            // 
            this.panelInternal.Controls.Add(this.panelAllData);
            this.panelInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInternal.Location = new System.Drawing.Point(0, 0);
            this.panelInternal.Name = "panelInternal";
            this.panelInternal.Size = new System.Drawing.Size(1252, 673);
            this.panelInternal.TabIndex = 0;
            // 
            // panelAllData
            // 
            this.panelAllData.Controls.Add(this.buttonBack);
            this.panelAllData.Controls.Add(this.resetButton);
            this.panelAllData.Controls.Add(this.searchButton);
            this.panelAllData.Controls.Add(this.errorNoQuestionsFound);
            this.panelAllData.Controls.Add(this.dataGridViewAllNormalData);
            this.panelAllData.Controls.Add(this.textBoxFindQuestion);
            this.panelAllData.Controls.Add(this.pictureBoxSearchQuestion);
            this.panelAllData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAllData.Location = new System.Drawing.Point(0, 0);
            this.panelAllData.Name = "panelAllData";
            this.panelAllData.Size = new System.Drawing.Size(1252, 673);
            this.panelAllData.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(804, 610);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(89, 37);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(805, 18);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(89, 37);
            this.resetButton.TabIndex = 7;
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
            this.searchButton.Location = new System.Drawing.Point(692, 18);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(89, 37);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Buscar";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // errorNoQuestionsFound
            // 
            this.errorNoQuestionsFound.AutoSize = true;
            this.errorNoQuestionsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorNoQuestionsFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.errorNoQuestionsFound.Location = new System.Drawing.Point(64, 291);
            this.errorNoQuestionsFound.Name = "errorNoQuestionsFound";
            this.errorNoQuestionsFound.Size = new System.Drawing.Size(664, 29);
            this.errorNoQuestionsFound.TabIndex = 3;
            this.errorNoQuestionsFound.Text = "No se han encontrado preguntas asociadas a esta asignatura";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAllNormalData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAllNormalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllNormalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNormalQuestion,
            this.question});
            this.dataGridViewAllNormalData.EnableHeadersVisualStyles = false;
            this.dataGridViewAllNormalData.GridColor = System.Drawing.Color.White;
            this.dataGridViewAllNormalData.Location = new System.Drawing.Point(12, 61);
            this.dataGridViewAllNormalData.MultiSelect = false;
            this.dataGridViewAllNormalData.Name = "dataGridViewAllNormalData";
            this.dataGridViewAllNormalData.ReadOnly = true;
            this.dataGridViewAllNormalData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAllNormalData.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAllNormalData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAllNormalData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllNormalData.Size = new System.Drawing.Size(881, 535);
            this.dataGridViewAllNormalData.TabIndex = 2;
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
            this.textBoxFindQuestion.Location = new System.Drawing.Point(45, 27);
            this.textBoxFindQuestion.Name = "textBoxFindQuestion";
            this.textBoxFindQuestion.Size = new System.Drawing.Size(621, 20);
            this.textBoxFindQuestion.TabIndex = 1;
            this.textBoxFindQuestion.Text = "Nombre de la pregunta a buscar...";
            this.textBoxFindQuestion.TextChanged += new System.EventHandler(this.textBoxFindQuestion_TextChanged);
            this.textBoxFindQuestion.Enter += new System.EventHandler(this.textBoxFindQuestion_Enter);
            this.textBoxFindQuestion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFindQuestion_KeyPress);
            this.textBoxFindQuestion.Leave += new System.EventHandler(this.textBoxFindQuestion_Leave);
            // 
            // pictureBoxSearchQuestion
            // 
            this.pictureBoxSearchQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearchQuestion.Image")));
            this.pictureBoxSearchQuestion.Location = new System.Drawing.Point(12, 16);
            this.pictureBoxSearchQuestion.Name = "pictureBoxSearchQuestion";
            this.pictureBoxSearchQuestion.Size = new System.Drawing.Size(674, 39);
            this.pictureBoxSearchQuestion.TabIndex = 0;
            this.pictureBoxSearchQuestion.TabStop = false;
            // 
            // ListAllNormalQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.panelInternal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "ListAllNormalQuestions";
            this.Text = "EmptyDataForm";
            this.panelInternal.ResumeLayout(false);
            this.panelAllData.ResumeLayout(false);
            this.panelAllData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelInternal;
        private System.Windows.Forms.Panel panelAllData;
        private System.Windows.Forms.DataGridView dataGridViewAllNormalData;
        private System.Windows.Forms.TextBox textBoxFindQuestion;
        private System.Windows.Forms.PictureBox pictureBoxSearchQuestion;
        private System.Windows.Forms.Label errorNoQuestionsFound;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
    }
}
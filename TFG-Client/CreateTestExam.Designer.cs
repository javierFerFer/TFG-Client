namespace TFG_Client {
    partial class CreateTestExam {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTestExam));
            this.typeOfDataPanel = new System.Windows.Forms.Panel();
            this.dataGridViewMyQuestions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTestData = new System.Windows.Forms.DataGridView();
            this.labelWaitQuestions = new System.Windows.Forms.Label();
            this.labelListAllQuestions = new System.Windows.Forms.Label();
            this.labelInfoMyQuestions = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.errorNoQuestionsFound = new System.Windows.Forms.Label();
            this.textBoxFindQuestion = new System.Windows.Forms.TextBox();
            this.pictureBoxSearchQuestion = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.IDNormalQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asnwer_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asnwer_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correct_answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOfDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.dataGridViewMyQuestions);
            this.typeOfDataPanel.Controls.Add(this.dataGridViewTestData);
            this.typeOfDataPanel.Controls.Add(this.labelWaitQuestions);
            this.typeOfDataPanel.Controls.Add(this.labelListAllQuestions);
            this.typeOfDataPanel.Controls.Add(this.labelInfoMyQuestions);
            this.typeOfDataPanel.Controls.Add(this.buttonSend);
            this.typeOfDataPanel.Controls.Add(this.resetButton);
            this.typeOfDataPanel.Controls.Add(this.searchButton);
            this.typeOfDataPanel.Controls.Add(this.errorNoQuestionsFound);
            this.typeOfDataPanel.Controls.Add(this.textBoxFindQuestion);
            this.typeOfDataPanel.Controls.Add(this.pictureBoxSearchQuestion);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMyQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMyQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridViewMyQuestions.EnableHeadersVisualStyles = false;
            this.dataGridViewMyQuestions.GridColor = System.Drawing.Color.White;
            this.dataGridViewMyQuestions.Location = new System.Drawing.Point(17, 361);
            this.dataGridViewMyQuestions.MultiSelect = false;
            this.dataGridViewMyQuestions.Name = "dataGridViewMyQuestions";
            this.dataGridViewMyQuestions.ReadOnly = true;
            this.dataGridViewMyQuestions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewMyQuestions.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMyQuestions.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMyQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMyQuestions.Size = new System.Drawing.Size(881, 240);
            this.dataGridViewMyQuestions.TabIndex = 21;
            this.dataGridViewMyQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyQuestions_CellDoubleClick_1);
            this.dataGridViewMyQuestions.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyQuestions_CellMouseEnter_1);
            // 
            // dataGridViewTestData
            // 
            this.dataGridViewTestData.AllowUserToAddRows = false;
            this.dataGridViewTestData.AllowUserToDeleteRows = false;
            this.dataGridViewTestData.AllowUserToResizeColumns = false;
            this.dataGridViewTestData.AllowUserToResizeRows = false;
            this.dataGridViewTestData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTestData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTestData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.dataGridViewTestData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTestData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewTestData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTestData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNormalQuestion,
            this.question,
            this.answer_A,
            this.asnwer_B,
            this.answer_C,
            this.asnwer_D,
            this.correct_answer});
            this.dataGridViewTestData.EnableHeadersVisualStyles = false;
            this.dataGridViewTestData.GridColor = System.Drawing.Color.White;
            this.dataGridViewTestData.Location = new System.Drawing.Point(17, 86);
            this.dataGridViewTestData.MultiSelect = false;
            this.dataGridViewTestData.Name = "dataGridViewTestData";
            this.dataGridViewTestData.ReadOnly = true;
            this.dataGridViewTestData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTestData.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTestData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTestData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTestData.Size = new System.Drawing.Size(881, 240);
            this.dataGridViewTestData.TabIndex = 20;
            this.dataGridViewTestData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTestData_CellDoubleClick);
            this.dataGridViewTestData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTestData_CellMouseEnter);
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
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.ForeColor = System.Drawing.Color.White;
            this.buttonSend.Location = new System.Drawing.Point(804, 610);
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
            this.textBoxFindQuestion.Leave += new System.EventHandler(this.textBoxFindQuestion_Leave);
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
            this.buttonBack.Location = new System.Drawing.Point(12, 610);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
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
            // answer_A
            // 
            this.answer_A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer_A.HeaderText = "Respuesta A";
            this.answer_A.Name = "answer_A";
            this.answer_A.ReadOnly = true;
            // 
            // asnwer_B
            // 
            this.asnwer_B.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.asnwer_B.HeaderText = "Respuesta B";
            this.asnwer_B.Name = "asnwer_B";
            this.asnwer_B.ReadOnly = true;
            // 
            // answer_C
            // 
            this.answer_C.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer_C.HeaderText = "Respuesta C";
            this.answer_C.Name = "answer_C";
            this.answer_C.ReadOnly = true;
            // 
            // asnwer_D
            // 
            this.asnwer_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.asnwer_D.HeaderText = "Respuesta D";
            this.asnwer_D.Name = "asnwer_D";
            this.asnwer_D.ReadOnly = true;
            // 
            // correct_answer
            // 
            this.correct_answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.correct_answer.HeaderText = "Correcta";
            this.correct_answer.Name = "correct_answer";
            this.correct_answer.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Pregunta";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Respuesta A";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Respuesta B";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Respuesta C";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "Respuesta D";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.HeaderText = "Correcta";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // CreateTestExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "CreateTestExam";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInfoMyQuestions;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label errorNoQuestionsFound;
        private System.Windows.Forms.TextBox textBoxFindQuestion;
        private System.Windows.Forms.PictureBox pictureBoxSearchQuestion;
        private System.Windows.Forms.Label labelListAllQuestions;
        private System.Windows.Forms.Label labelWaitQuestions;
        private System.Windows.Forms.DataGridView dataGridViewMyQuestions;
        private System.Windows.Forms.DataGridView dataGridViewTestData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn asnwer_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn asnwer_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn correct_answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}
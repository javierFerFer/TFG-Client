namespace TFG_Client {
    partial class FormNormalModelToUse {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.infoNormalModelQuestions = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.flowLayoutTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridViewAllNormalData = new System.Windows.Forms.DataGridView();
            this.IDNormalQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTestData = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asnwer_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asnwer_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correct_answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestData)).BeginInit();
            this.SuspendLayout();
            // 
            // infoNormalModelQuestions
            // 
            this.infoNormalModelQuestions.AutoSize = true;
            this.infoNormalModelQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoNormalModelQuestions.Location = new System.Drawing.Point(11, 60);
            this.infoNormalModelQuestions.Name = "infoNormalModelQuestions";
            this.infoNormalModelQuestions.Size = new System.Drawing.Size(369, 25);
            this.infoNormalModelQuestions.TabIndex = 10;
            this.infoNormalModelQuestions.Text = "Preguntas pertenecientes al modelo: ";
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
            this.title.Size = new System.Drawing.Size(286, 33);
            this.title.TabIndex = 6;
            this.title.Text = "Listado de preguntas";
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
            this.buttonSend.Location = new System.Drawing.Point(721, 433);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(127, 29);
            this.buttonSend.TabIndex = 14;
            this.buttonSend.Text = "Usar este modelo";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
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
            this.dataGridViewAllNormalData.Location = new System.Drawing.Point(7, 98);
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
            this.dataGridViewAllNormalData.Size = new System.Drawing.Size(881, 297);
            this.dataGridViewAllNormalData.TabIndex = 15;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.answer_A,
            this.asnwer_B,
            this.answer_C,
            this.asnwer_D,
            this.correct_answer});
            this.dataGridViewTestData.EnableHeadersVisualStyles = false;
            this.dataGridViewTestData.GridColor = System.Drawing.Color.White;
            this.dataGridViewTestData.Location = new System.Drawing.Point(7, 98);
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
            this.dataGridViewTestData.Size = new System.Drawing.Size(881, 297);
            this.dataGridViewTestData.TabIndex = 21;
            this.dataGridViewTestData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTestData_CellDoubleClick);
            this.dataGridViewTestData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTestData_CellMouseEnter);
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
            // FormNormalModelToUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 487);
            this.Controls.Add(this.dataGridViewTestData);
            this.Controls.Add(this.dataGridViewAllNormalData);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.flowLayoutTitle);
            this.Controls.Add(this.infoNormalModelQuestions);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 487);
            this.MinimizeBox = false;
            this.Name = "FormNormalModelToUse";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModelWindowsMessage";
            this.flowLayoutTitle.ResumeLayout(false);
            this.flowLayoutTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNormalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label infoNormalModelQuestions;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Panel panelDown;
        public System.Windows.Forms.Panel panelUp;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutTitle;
        private System.Windows.Forms.Button buttonSend;
        public System.Windows.Forms.DataGridView dataGridViewAllNormalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        public System.Windows.Forms.DataGridView dataGridViewTestData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn asnwer_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn asnwer_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn correct_answer;
    }
}

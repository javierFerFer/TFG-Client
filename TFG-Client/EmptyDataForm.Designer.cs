namespace TFG_Client {
    partial class EmptyDataForm {
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
            this.emptyMessage = new System.Windows.Forms.Label();
            this.emptyRightPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // emptyMessage
            // 
            this.emptyMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.emptyMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.emptyMessage.Location = new System.Drawing.Point(-3, 0);
            this.emptyMessage.Name = "emptyMessage";
            this.emptyMessage.Size = new System.Drawing.Size(986, 579);
            this.emptyMessage.TabIndex = 0;
            this.emptyMessage.Text = "Seleccione una opción del menú de la derecha";
            this.emptyMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emptyRightPanel
            // 
            this.emptyRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.emptyRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.emptyRightPanel.Location = new System.Drawing.Point(981, 0);
            this.emptyRightPanel.Name = "emptyRightPanel";
            this.emptyRightPanel.Size = new System.Drawing.Size(271, 578);
            this.emptyRightPanel.TabIndex = 1;
            // 
            // EmptyDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 578);
            this.Controls.Add(this.emptyRightPanel);
            this.Controls.Add(this.emptyMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmptyDataForm";
            this.Text = "EmptyDataForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label emptyMessage;
        private System.Windows.Forms.Panel emptyRightPanel;
    }
}
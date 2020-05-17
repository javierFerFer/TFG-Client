namespace TFG_Client {
    partial class SelectNormalModel {
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
            this.flowLayoutPanelAllModels = new System.Windows.Forms.FlowLayoutPanel();
            this.labelWaitData = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.typeOfDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfDataPanel
            // 
            this.typeOfDataPanel.Controls.Add(this.flowLayoutPanelAllModels);
            this.typeOfDataPanel.Controls.Add(this.labelWaitData);
            this.typeOfDataPanel.Controls.Add(this.buttonBack);
            this.typeOfDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeOfDataPanel.Location = new System.Drawing.Point(0, 0);
            this.typeOfDataPanel.Name = "typeOfDataPanel";
            this.typeOfDataPanel.Size = new System.Drawing.Size(1252, 673);
            this.typeOfDataPanel.TabIndex = 2;
            // 
            // flowLayoutPanelAllModels
            // 
            this.flowLayoutPanelAllModels.AutoScroll = true;
            this.flowLayoutPanelAllModels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.flowLayoutPanelAllModels.Location = new System.Drawing.Point(80, 25);
            this.flowLayoutPanelAllModels.Name = "flowLayoutPanelAllModels";
            this.flowLayoutPanelAllModels.Size = new System.Drawing.Size(764, 578);
            this.flowLayoutPanelAllModels.TabIndex = 11;
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
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(134)))), ((int)(((byte)(5)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(80, 609);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(108, 37);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // SelectNormalModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1252, 673);
            this.Controls.Add(this.typeOfDataPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1252, 673);
            this.Name = "SelectNormalModel";
            this.Text = "AskTypeOfData";
            this.typeOfDataPanel.ResumeLayout(false);
            this.typeOfDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel typeOfDataPanel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelWaitData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllModels;
    }
}
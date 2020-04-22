namespace TFG_Client {
    partial class UserControlPanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlPanel));
            this.flowLayoutUp = new System.Windows.Forms.FlowLayoutPanel();
            this.userImageCircle = new TFG_Client.MyOwnCircleComponent();
            this.userMailLabel = new System.Windows.Forms.Label();
            this.flowLayoutUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutUp
            // 
            this.flowLayoutUp.AutoSize = true;
            this.flowLayoutUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flowLayoutUp.Controls.Add(this.userImageCircle);
            this.flowLayoutUp.Controls.Add(this.userMailLabel);
            this.flowLayoutUp.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutUp.Location = new System.Drawing.Point(-3, -1);
            this.flowLayoutUp.Name = "flowLayoutUp";
            this.flowLayoutUp.Size = new System.Drawing.Size(1108, 53);
            this.flowLayoutUp.TabIndex = 0;
            this.flowLayoutUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseDown);
            this.flowLayoutUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseMove);
            this.flowLayoutUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseUp);
            // 
            // userImageCircle
            // 
            this.userImageCircle.Image = ((System.Drawing.Image)(resources.GetObject("userImageCircle.Image")));
            this.userImageCircle.Location = new System.Drawing.Point(1054, 3);
            this.userImageCircle.Name = "userImageCircle";
            this.userImageCircle.Size = new System.Drawing.Size(51, 46);
            this.userImageCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImageCircle.TabIndex = 1;
            this.userImageCircle.TabStop = false;
            // 
            // userMailLabel
            // 
            this.userMailLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userMailLabel.AutoSize = true;
            this.userMailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userMailLabel.ForeColor = System.Drawing.Color.White;
            this.userMailLabel.Location = new System.Drawing.Point(810, 7);
            this.userMailLabel.Name = "userMailLabel";
            this.userMailLabel.Size = new System.Drawing.Size(238, 37);
            this.userMailLabel.TabIndex = 2;
            this.userMailLabel.Text = "texto de prueba";
            // 
            // UserControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1106, 668);
            this.Controls.Add(this.flowLayoutUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserControlPanel";
            this.Text = "userControlPanel";
            this.flowLayoutUp.ResumeLayout(false);
            this.flowLayoutUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageCircle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutUp;
        private MyOwnCircleComponent userImageCircle;
        private System.Windows.Forms.Label userMailLabel;
    }
}
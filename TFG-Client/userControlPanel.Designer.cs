﻿namespace TFG_Client {
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
            this.iconUser = new TFG_Client.MyOwnCircleComponent();
            this.layoutOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutSupport = new System.Windows.Forms.FlowLayoutPanel();
            this.supportIcon = new System.Windows.Forms.PictureBox();
            this.supportLabel = new System.Windows.Forms.Label();
            this.layoutAbout = new System.Windows.Forms.FlowLayoutPanel();
            this.aboutIcon = new System.Windows.Forms.PictureBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.layoutMinimize = new System.Windows.Forms.FlowLayoutPanel();
            this.minimizeIcon = new System.Windows.Forms.PictureBox();
            this.minimizeLabel = new System.Windows.Forms.Label();
            this.layoutExit = new System.Windows.Forms.FlowLayoutPanel();
            this.exitImage = new System.Windows.Forms.PictureBox();
            this.exitLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconApp = new TFG_Client.MyOwnCircleComponent();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.flowLayoutUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).BeginInit();
            this.layoutOptions.SuspendLayout();
            this.layoutSupport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supportIcon)).BeginInit();
            this.layoutAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutIcon)).BeginInit();
            this.layoutMinimize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeIcon)).BeginInit();
            this.layoutExit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitImage)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApp)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutUp
            // 
            this.flowLayoutUp.AutoSize = true;
            this.flowLayoutUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flowLayoutUp.Controls.Add(this.iconApp);
            this.flowLayoutUp.Location = new System.Drawing.Point(0, -2);
            this.flowLayoutUp.Name = "flowLayoutUp";
            this.flowLayoutUp.Size = new System.Drawing.Size(751, 52);
            this.flowLayoutUp.TabIndex = 0;
            this.flowLayoutUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseDown);
            this.flowLayoutUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseMove);
            this.flowLayoutUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flowLayoutUp_MouseUp);
            // 
            // iconUser
            // 
            this.iconUser.Image = ((System.Drawing.Image)(resources.GetObject("iconUser.Image")));
            this.iconUser.Location = new System.Drawing.Point(307, 3);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(51, 46);
            this.iconUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconUser.TabIndex = 1;
            this.iconUser.TabStop = false;
            this.iconUser.Click += new System.EventHandler(this.userImageCircle_Click);
            // 
            // layoutOptions
            // 
            this.layoutOptions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layoutOptions.Controls.Add(this.layoutSupport);
            this.layoutOptions.Controls.Add(this.layoutAbout);
            this.layoutOptions.Controls.Add(this.layoutMinimize);
            this.layoutOptions.Controls.Add(this.layoutExit);
            this.layoutOptions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.layoutOptions.Location = new System.Drawing.Point(928, 50);
            this.layoutOptions.Name = "layoutOptions";
            this.layoutOptions.Size = new System.Drawing.Size(177, 198);
            this.layoutOptions.TabIndex = 13;
            // 
            // layoutSupport
            // 
            this.layoutSupport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layoutSupport.Controls.Add(this.supportIcon);
            this.layoutSupport.Controls.Add(this.supportLabel);
            this.layoutSupport.Location = new System.Drawing.Point(5, 3);
            this.layoutSupport.Name = "layoutSupport";
            this.layoutSupport.Size = new System.Drawing.Size(169, 45);
            this.layoutSupport.TabIndex = 13;
            this.layoutSupport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.layoutSupport_MouseClick);
            // 
            // supportIcon
            // 
            this.supportIcon.Image = ((System.Drawing.Image)(resources.GetObject("supportIcon.Image")));
            this.supportIcon.Location = new System.Drawing.Point(3, 3);
            this.supportIcon.Name = "supportIcon";
            this.supportIcon.Size = new System.Drawing.Size(40, 38);
            this.supportIcon.TabIndex = 0;
            this.supportIcon.TabStop = false;
            this.supportIcon.Click += new System.EventHandler(this.supportIcon_Click);
            // 
            // supportLabel
            // 
            this.supportLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.supportLabel.AutoSize = true;
            this.supportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supportLabel.Location = new System.Drawing.Point(49, 10);
            this.supportLabel.Name = "supportLabel";
            this.supportLabel.Size = new System.Drawing.Size(76, 24);
            this.supportLabel.TabIndex = 1;
            this.supportLabel.Text = "Soporte";
            this.supportLabel.Click += new System.EventHandler(this.supportLabel_Click);
            // 
            // layoutAbout
            // 
            this.layoutAbout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layoutAbout.Controls.Add(this.aboutIcon);
            this.layoutAbout.Controls.Add(this.aboutLabel);
            this.layoutAbout.Location = new System.Drawing.Point(5, 54);
            this.layoutAbout.Name = "layoutAbout";
            this.layoutAbout.Size = new System.Drawing.Size(169, 49);
            this.layoutAbout.TabIndex = 13;
            this.layoutAbout.Click += new System.EventHandler(this.layoutAbout_Click);
            // 
            // aboutIcon
            // 
            this.aboutIcon.Image = ((System.Drawing.Image)(resources.GetObject("aboutIcon.Image")));
            this.aboutIcon.Location = new System.Drawing.Point(3, 3);
            this.aboutIcon.Name = "aboutIcon";
            this.aboutIcon.Size = new System.Drawing.Size(40, 38);
            this.aboutIcon.TabIndex = 2;
            this.aboutIcon.TabStop = false;
            this.aboutIcon.Click += new System.EventHandler(this.aboutIcon_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(49, 10);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(112, 24);
            this.aboutLabel.TabIndex = 3;
            this.aboutLabel.Text = "Acerca de...";
            this.aboutLabel.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // layoutMinimize
            // 
            this.layoutMinimize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layoutMinimize.Controls.Add(this.minimizeIcon);
            this.layoutMinimize.Controls.Add(this.minimizeLabel);
            this.layoutMinimize.Location = new System.Drawing.Point(5, 109);
            this.layoutMinimize.Name = "layoutMinimize";
            this.layoutMinimize.Size = new System.Drawing.Size(169, 42);
            this.layoutMinimize.TabIndex = 14;
            this.layoutMinimize.Click += new System.EventHandler(this.layoutMinimize_Click);
            // 
            // minimizeIcon
            // 
            this.minimizeIcon.Image = ((System.Drawing.Image)(resources.GetObject("minimizeIcon.Image")));
            this.minimizeIcon.Location = new System.Drawing.Point(3, 3);
            this.minimizeIcon.Name = "minimizeIcon";
            this.minimizeIcon.Size = new System.Drawing.Size(40, 28);
            this.minimizeIcon.TabIndex = 4;
            this.minimizeIcon.TabStop = false;
            this.minimizeIcon.Click += new System.EventHandler(this.minimizeIcon_Click);
            // 
            // minimizeLabel
            // 
            this.minimizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minimizeLabel.AutoSize = true;
            this.minimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeLabel.Location = new System.Drawing.Point(49, 5);
            this.minimizeLabel.Name = "minimizeLabel";
            this.minimizeLabel.Size = new System.Drawing.Size(90, 24);
            this.minimizeLabel.TabIndex = 5;
            this.minimizeLabel.Text = "Minimizar";
            this.minimizeLabel.Click += new System.EventHandler(this.minimizeLabel_Click);
            // 
            // layoutExit
            // 
            this.layoutExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layoutExit.Controls.Add(this.exitImage);
            this.layoutExit.Controls.Add(this.exitLabel);
            this.layoutExit.Location = new System.Drawing.Point(5, 157);
            this.layoutExit.Name = "layoutExit";
            this.layoutExit.Size = new System.Drawing.Size(169, 34);
            this.layoutExit.TabIndex = 15;
            this.layoutExit.Click += new System.EventHandler(this.layoutExit_Click);
            // 
            // exitImage
            // 
            this.exitImage.Image = ((System.Drawing.Image)(resources.GetObject("exitImage.Image")));
            this.exitImage.Location = new System.Drawing.Point(3, 3);
            this.exitImage.Name = "exitImage";
            this.exitImage.Size = new System.Drawing.Size(40, 28);
            this.exitImage.TabIndex = 6;
            this.exitImage.TabStop = false;
            this.exitImage.Click += new System.EventHandler(this.exitImage_Click);
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.Location = new System.Drawing.Point(49, 5);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(46, 24);
            this.exitLabel.TabIndex = 7;
            this.exitLabel.Text = "Salir";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Controls.Add(this.iconUser);
            this.flowLayoutPanel1.Controls.Add(this.userNameLabel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(744, -2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 52);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // iconApp
            // 
            this.iconApp.Image = ((System.Drawing.Image)(resources.GetObject("iconApp.Image")));
            this.iconApp.Location = new System.Drawing.Point(3, 3);
            this.iconApp.Name = "iconApp";
            this.iconApp.Size = new System.Drawing.Size(51, 46);
            this.iconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconApp.TabIndex = 1;
            this.iconApp.TabStop = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.Color.White;
            this.userNameLabel.Location = new System.Drawing.Point(3, 7);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(298, 37);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "Nombre del usuario";
            this.userNameLabel.Click += new System.EventHandler(this.userNameLabel_Click);
            // 
            // UserControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1106, 668);
            this.Controls.Add(this.layoutOptions);
            this.Controls.Add(this.flowLayoutUp);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserControlPanel";
            this.Text = "userControlPanel";
            this.flowLayoutUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).EndInit();
            this.layoutOptions.ResumeLayout(false);
            this.layoutSupport.ResumeLayout(false);
            this.layoutSupport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supportIcon)).EndInit();
            this.layoutAbout.ResumeLayout(false);
            this.layoutAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutIcon)).EndInit();
            this.layoutMinimize.ResumeLayout(false);
            this.layoutMinimize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeIcon)).EndInit();
            this.layoutExit.ResumeLayout(false);
            this.layoutExit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitImage)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutUp;
        private MyOwnCircleComponent iconUser;
        private System.Windows.Forms.FlowLayoutPanel layoutOptions;
        private System.Windows.Forms.FlowLayoutPanel layoutSupport;
        private System.Windows.Forms.PictureBox supportIcon;
        private System.Windows.Forms.Label supportLabel;
        private System.Windows.Forms.FlowLayoutPanel layoutAbout;
        private System.Windows.Forms.PictureBox aboutIcon;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.FlowLayoutPanel layoutMinimize;
        private System.Windows.Forms.PictureBox minimizeIcon;
        private System.Windows.Forms.Label minimizeLabel;
        private System.Windows.Forms.FlowLayoutPanel layoutExit;
        private System.Windows.Forms.PictureBox exitImage;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MyOwnCircleComponent iconApp;
        private System.Windows.Forms.Label userNameLabel;
    }
}
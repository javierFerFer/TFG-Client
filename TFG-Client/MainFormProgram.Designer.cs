﻿namespace TFG_Client
{
    partial class MainFormProgram
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormProgram));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.myOwnCircleComponent1 = new TFG_Client.MyOwnCircleComponent();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myOwnCircleComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-17, -36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 640);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // myOwnCircleComponent1
            // 
            this.myOwnCircleComponent1.Image = ((System.Drawing.Image)(resources.GetObject("myOwnCircleComponent1.Image")));
            this.myOwnCircleComponent1.Location = new System.Drawing.Point(430, 51);
            this.myOwnCircleComponent1.Name = "myOwnCircleComponent1";
            this.myOwnCircleComponent1.Size = new System.Drawing.Size(122, 117);
            this.myOwnCircleComponent1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myOwnCircleComponent1.TabIndex = 1;
            this.myOwnCircleComponent1.TabStop = false;
            // 
            // MainFormProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(615, 484);
            this.Controls.Add(this.myOwnCircleComponent1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFormProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myOwnCircleComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MyOwnCircleComponent myOwnCircleComponent1;
    }
}


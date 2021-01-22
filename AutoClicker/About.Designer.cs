using AutoClicker.Controls;
using System.Drawing;

namespace AutoClicker
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabelGithubRepo = new System.Windows.Forms.LinkLabel();
            this.roundedLabelLicense = new AutoClicker.Controls.RoundedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblTitle.Location = new System.Drawing.Point(29, 51);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "AutoClicker";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.DarkGray;
            this.lblVersion.Location = new System.Drawing.Point(119, 116);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(85, 17);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: 0.1.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(297, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // linkLabelGithubRepo
            // 
            this.linkLabelGithubRepo.AutoSize = true;
            this.linkLabelGithubRepo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(159)))), ((int)(((byte)(247)))));
            this.linkLabelGithubRepo.Location = new System.Drawing.Point(116, 142);
            this.linkLabelGithubRepo.Name = "linkLabelGithubRepo";
            this.linkLabelGithubRepo.Size = new System.Drawing.Size(88, 15);
            this.linkLabelGithubRepo.TabIndex = 3;
            this.linkLabelGithubRepo.TabStop = true;
            this.linkLabelGithubRepo.Text = "View on Github";
            this.linkLabelGithubRepo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelGithubRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelGithubRepo_LinkClicked);
            // 
            // roundedLabelLicense
            // 
            this.roundedLabelLicense.BackColor = System.Drawing.Color.Transparent;
            this.roundedLabelLicense.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedLabelLicense.CornerRadius = 23;
            this.roundedLabelLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedLabelLicense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.roundedLabelLicense.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.roundedLabelLicense.Location = new System.Drawing.Point(43, 409);
            this.roundedLabelLicense.Name = "roundedLabelLicense";
            this.roundedLabelLicense.Size = new System.Drawing.Size(240, 32);
            this.roundedLabelLicense.TabIndex = 5;
            this.roundedLabelLicense.Text = "Open source license";
            this.roundedLabelLicense.Click += new System.EventHandler(this.RoundedLabelLicense_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(332, 450);
            this.Controls.Add(this.roundedLabelLicense);
            this.Controls.Add(this.linkLabelGithubRepo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabelGithubRepo;
        private RoundedLabel roundedLabelLicense;
    }
}
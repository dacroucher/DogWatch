namespace DogWatch
{
    partial class VideoForm
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
            this.preBox = new AForge.Controls.PictureBox();
            this.postBox = new AForge.Controls.PictureBox();
            this.backBox = new AForge.Controls.PictureBox();
            this.blobCount = new System.Windows.Forms.TextBox();
            this.rMax = new System.Windows.Forms.TextBox();
            this.rMin = new System.Windows.Forms.TextBox();
            this.gMax = new System.Windows.Forms.TextBox();
            this.gMin = new System.Windows.Forms.TextBox();
            this.bMax = new System.Windows.Forms.TextBox();
            this.bMin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colourBox = new AForge.Controls.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.preBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colourBox)).BeginInit();
            this.SuspendLayout();
            // 
            // preBox
            // 
            this.preBox.Image = null;
            this.preBox.Location = new System.Drawing.Point(13, 12);
            this.preBox.Name = "preBox";
            this.preBox.Size = new System.Drawing.Size(600, 333);
            this.preBox.TabIndex = 0;
            this.preBox.TabStop = false;
            // 
            // postBox
            // 
            this.postBox.Image = null;
            this.postBox.Location = new System.Drawing.Point(619, 12);
            this.postBox.Name = "postBox";
            this.postBox.Size = new System.Drawing.Size(600, 333);
            this.postBox.TabIndex = 1;
            this.postBox.TabStop = false;
            // 
            // backBox
            // 
            this.backBox.Image = null;
            this.backBox.Location = new System.Drawing.Point(316, 351);
            this.backBox.Name = "backBox";
            this.backBox.Size = new System.Drawing.Size(600, 333);
            this.backBox.TabIndex = 2;
            this.backBox.TabStop = false;
            // 
            // blobCount
            // 
            this.blobCount.Location = new System.Drawing.Point(62, 380);
            this.blobCount.Name = "blobCount";
            this.blobCount.Size = new System.Drawing.Size(100, 20);
            this.blobCount.TabIndex = 3;
            // 
            // rMax
            // 
            this.rMax.Location = new System.Drawing.Point(62, 472);
            this.rMax.Name = "rMax";
            this.rMax.Size = new System.Drawing.Size(100, 20);
            this.rMax.TabIndex = 4;
            this.rMax.Text = "85";
            // 
            // rMin
            // 
            this.rMin.Location = new System.Drawing.Point(62, 498);
            this.rMin.Name = "rMin";
            this.rMin.Size = new System.Drawing.Size(100, 20);
            this.rMin.TabIndex = 5;
            this.rMin.Text = "55";
            // 
            // gMax
            // 
            this.gMax.Location = new System.Drawing.Point(62, 549);
            this.gMax.Name = "gMax";
            this.gMax.Size = new System.Drawing.Size(100, 20);
            this.gMax.TabIndex = 6;
            this.gMax.Text = "75";
            // 
            // gMin
            // 
            this.gMin.Location = new System.Drawing.Point(62, 575);
            this.gMin.Name = "gMin";
            this.gMin.Size = new System.Drawing.Size(100, 20);
            this.gMin.TabIndex = 7;
            this.gMin.Text = "45";
            // 
            // bMax
            // 
            this.bMax.Location = new System.Drawing.Point(62, 612);
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(100, 20);
            this.bMax.TabIndex = 8;
            this.bMax.Text = "75";
            // 
            // bMin
            // 
            this.bMin.Location = new System.Drawing.Point(62, 638);
            this.bMin.Name = "bMin";
            this.bMin.Size = new System.Drawing.Size(100, 20);
            this.bMin.TabIndex = 9;
            this.bMin.Text = "45";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colourBox
            // 
            this.colourBox.Image = null;
            this.colourBox.Location = new System.Drawing.Point(931, 351);
            this.colourBox.Name = "colourBox";
            this.colourBox.Size = new System.Drawing.Size(600, 333);
            this.colourBox.TabIndex = 11;
            this.colourBox.TabStop = false;
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 700);
            this.Controls.Add(this.colourBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bMin);
            this.Controls.Add(this.bMax);
            this.Controls.Add(this.gMin);
            this.Controls.Add(this.gMax);
            this.Controls.Add(this.rMin);
            this.Controls.Add(this.rMax);
            this.Controls.Add(this.blobCount);
            this.Controls.Add(this.backBox);
            this.Controls.Add(this.postBox);
            this.Controls.Add(this.preBox);
            this.Name = "VideoForm";
            this.Text = "VideoForm";
            this.Load += new System.EventHandler(this.VideoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colourBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private AForge.Controls.PictureBox preBox;
        private AForge.Controls.PictureBox postBox;
        private AForge.Controls.PictureBox backBox;
        private System.Windows.Forms.TextBox blobCount;
        private System.Windows.Forms.TextBox rMax;
        private System.Windows.Forms.TextBox rMin;
        private System.Windows.Forms.TextBox gMax;
        private System.Windows.Forms.TextBox gMin;
        private System.Windows.Forms.TextBox bMax;
        private System.Windows.Forms.TextBox bMin;
        private System.Windows.Forms.Button button1;
        private AForge.Controls.PictureBox colourBox;
    }
}
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
            ((System.ComponentModel.ISupportInitialize)(this.preBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).BeginInit();
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
            this.backBox.Location = new System.Drawing.Point(321, 351);
            this.backBox.Name = "backBox";
            this.backBox.Size = new System.Drawing.Size(600, 333);
            this.backBox.TabIndex = 2;
            this.backBox.TabStop = false;
            // 
            // blobCount
            // 
            this.blobCount.Location = new System.Drawing.Point(1022, 522);
            this.blobCount.Name = "blobCount";
            this.blobCount.Size = new System.Drawing.Size(100, 20);
            this.blobCount.TabIndex = 3;
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 700);
            this.Controls.Add(this.blobCount);
            this.Controls.Add(this.backBox);
            this.Controls.Add(this.postBox);
            this.Controls.Add(this.preBox);
            this.Name = "VideoForm";
            this.Text = "VideoForm";
            ((System.ComponentModel.ISupportInitialize)(this.preBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private AForge.Controls.PictureBox preBox;
        private AForge.Controls.PictureBox postBox;
        private AForge.Controls.PictureBox backBox;
        private System.Windows.Forms.TextBox blobCount;
    }
}
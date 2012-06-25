namespace DogWatch
{
    partial class MainForm
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
            this.group_currentView = new System.Windows.Forms.GroupBox();
            this.currentViewBox = new AForge.Controls.PictureBox();
            this.group_Functionality = new System.Windows.Forms.GroupBox();
            this.group_networking = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.netStatusText = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.group_currentView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentViewBox)).BeginInit();
            this.group_networking.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_currentView
            // 
            this.group_currentView.Controls.Add(this.currentViewBox);
            this.group_currentView.Location = new System.Drawing.Point(13, 13);
            this.group_currentView.Name = "group_currentView";
            this.group_currentView.Size = new System.Drawing.Size(621, 368);
            this.group_currentView.TabIndex = 0;
            this.group_currentView.TabStop = false;
            this.group_currentView.Text = "Current View";
            // 
            // currentViewBox
            // 
            this.currentViewBox.Image = null;
            this.currentViewBox.Location = new System.Drawing.Point(7, 20);
            this.currentViewBox.Name = "currentViewBox";
            this.currentViewBox.Size = new System.Drawing.Size(600, 333);
            this.currentViewBox.TabIndex = 0;
            this.currentViewBox.TabStop = false;
            // 
            // group_Functionality
            // 
            this.group_Functionality.Location = new System.Drawing.Point(12, 387);
            this.group_Functionality.Name = "group_Functionality";
            this.group_Functionality.Size = new System.Drawing.Size(622, 167);
            this.group_Functionality.TabIndex = 1;
            this.group_Functionality.TabStop = false;
            this.group_Functionality.Text = "Functionality";
            // 
            // group_networking
            // 
            this.group_networking.Controls.Add(this.label1);
            this.group_networking.Controls.Add(this.netStatusText);
            this.group_networking.Controls.Add(this.listenButton);
            this.group_networking.Location = new System.Drawing.Point(655, 13);
            this.group_networking.Name = "group_networking";
            this.group_networking.Size = new System.Drawing.Size(284, 541);
            this.group_networking.TabIndex = 2;
            this.group_networking.TabStop = false;
            this.group_networking.Text = "Networking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Network Status:";
            // 
            // netStatusText
            // 
            this.netStatusText.Location = new System.Drawing.Point(6, 36);
            this.netStatusText.Name = "netStatusText";
            this.netStatusText.Size = new System.Drawing.Size(272, 20);
            this.netStatusText.TabIndex = 1;
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(6, 88);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(114, 31);
            this.listenButton.TabIndex = 0;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 566);
            this.Controls.Add(this.group_networking);
            this.Controls.Add(this.group_Functionality);
            this.Controls.Add(this.group_currentView);
            this.Name = "MainForm";
            this.Text = "DogWatch";
            this.group_currentView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentViewBox)).EndInit();
            this.group_networking.ResumeLayout(false);
            this.group_networking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_currentView;
        private AForge.Controls.PictureBox currentViewBox;
        //private System.Windows.Forms.PictureBox currentViewBox;
        private System.Windows.Forms.GroupBox group_Functionality;
        private System.Windows.Forms.GroupBox group_networking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox netStatusText;
        private System.Windows.Forms.Button listenButton;
    }
}


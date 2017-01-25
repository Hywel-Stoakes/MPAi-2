namespace MPAi.Forms.Config
{
    partial class SystemConfig
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.audioFolderTextBox = new System.Windows.Forms.TextBox();
            this.audioFolderLabel = new System.Windows.Forms.Label();
            this.audioFolderSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.videoFolderSelectButton = new System.Windows.Forms.Button();
            this.videoFolderlabel = new System.Windows.Forms.Label();
            this.videoFolderTextBox = new System.Windows.Forms.TextBox();
            this.reportFolderSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportFolderTextBox = new System.Windows.Forms.TextBox();
            this.recordingFolderSelectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.recordingFolderTextBox = new System.Windows.Forms.TextBox();
            this.HTKFolderSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HTKFolderTextBox = new System.Windows.Forms.TextBox();
            this.fomantFolderSelectButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.fomantFolderTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // audioFolderTextBox
            // 
            this.audioFolderTextBox.Enabled = false;
            this.audioFolderTextBox.Location = new System.Drawing.Point(126, 72);
            this.audioFolderTextBox.Name = "audioFolderTextBox";
            this.audioFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.audioFolderTextBox.TabIndex = 0;
            // 
            // audioFolderLabel
            // 
            this.audioFolderLabel.AutoSize = true;
            this.audioFolderLabel.Location = new System.Drawing.Point(19, 75);
            this.audioFolderLabel.Name = "audioFolderLabel";
            this.audioFolderLabel.Size = new System.Drawing.Size(66, 13);
            this.audioFolderLabel.TabIndex = 1;
            this.audioFolderLabel.Text = "Audio Folder";
            // 
            // audioFolderSelectButton
            // 
            this.audioFolderSelectButton.Location = new System.Drawing.Point(464, 72);
            this.audioFolderSelectButton.Name = "audioFolderSelectButton";
            this.audioFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.audioFolderSelectButton.TabIndex = 2;
            this.audioFolderSelectButton.Text = "...";
            this.audioFolderSelectButton.UseVisualStyleBackColor = true;
            this.audioFolderSelectButton.Click += new System.EventHandler(this.audioFolderSelectButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(388, 273);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 25);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(445, 273);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(53, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // videoFolderSelectButton
            // 
            this.videoFolderSelectButton.Location = new System.Drawing.Point(464, 106);
            this.videoFolderSelectButton.Name = "videoFolderSelectButton";
            this.videoFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.videoFolderSelectButton.TabIndex = 7;
            this.videoFolderSelectButton.Text = "...";
            this.videoFolderSelectButton.UseVisualStyleBackColor = true;
            this.videoFolderSelectButton.Click += new System.EventHandler(this.videoFolderSelectButton_Click);
            // 
            // videoFolderlabel
            // 
            this.videoFolderlabel.AutoSize = true;
            this.videoFolderlabel.Location = new System.Drawing.Point(19, 109);
            this.videoFolderlabel.Name = "videoFolderlabel";
            this.videoFolderlabel.Size = new System.Drawing.Size(66, 13);
            this.videoFolderlabel.TabIndex = 6;
            this.videoFolderlabel.Text = "Video Folder";
            // 
            // videoFolderTextBox
            // 
            this.videoFolderTextBox.Enabled = false;
            this.videoFolderTextBox.Location = new System.Drawing.Point(126, 106);
            this.videoFolderTextBox.Name = "videoFolderTextBox";
            this.videoFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.videoFolderTextBox.TabIndex = 5;
            // 
            // reportFolderSelectButton
            // 
            this.reportFolderSelectButton.Location = new System.Drawing.Point(464, 171);
            this.reportFolderSelectButton.Name = "reportFolderSelectButton";
            this.reportFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.reportFolderSelectButton.TabIndex = 13;
            this.reportFolderSelectButton.Text = "...";
            this.reportFolderSelectButton.UseVisualStyleBackColor = true;
            this.reportFolderSelectButton.Click += new System.EventHandler(this.reportFolderSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Report Folder";
            // 
            // reportFolderTextBox
            // 
            this.reportFolderTextBox.Enabled = false;
            this.reportFolderTextBox.Location = new System.Drawing.Point(126, 171);
            this.reportFolderTextBox.Name = "reportFolderTextBox";
            this.reportFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.reportFolderTextBox.TabIndex = 11;
            // 
            // recordingFolderSelectButton
            // 
            this.recordingFolderSelectButton.Location = new System.Drawing.Point(464, 138);
            this.recordingFolderSelectButton.Name = "recordingFolderSelectButton";
            this.recordingFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.recordingFolderSelectButton.TabIndex = 10;
            this.recordingFolderSelectButton.Text = "...";
            this.recordingFolderSelectButton.UseVisualStyleBackColor = true;
            this.recordingFolderSelectButton.Click += new System.EventHandler(this.recordingFolderSelectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Recording Folder";
            // 
            // recordingFolderTextBox
            // 
            this.recordingFolderTextBox.Enabled = false;
            this.recordingFolderTextBox.Location = new System.Drawing.Point(126, 138);
            this.recordingFolderTextBox.Name = "recordingFolderTextBox";
            this.recordingFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.recordingFolderTextBox.TabIndex = 8;
            // 
            // HTKFolderSelectButton
            // 
            this.HTKFolderSelectButton.Location = new System.Drawing.Point(464, 201);
            this.HTKFolderSelectButton.Name = "HTKFolderSelectButton";
            this.HTKFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.HTKFolderSelectButton.TabIndex = 16;
            this.HTKFolderSelectButton.Text = "...";
            this.HTKFolderSelectButton.UseVisualStyleBackColor = true;
            this.HTKFolderSelectButton.Click += new System.EventHandler(this.HTKFolderSelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "HTK Folder";
            // 
            // HTKFolderTextBox
            // 
            this.HTKFolderTextBox.Enabled = false;
            this.HTKFolderTextBox.Location = new System.Drawing.Point(126, 201);
            this.HTKFolderTextBox.Name = "HTKFolderTextBox";
            this.HTKFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.HTKFolderTextBox.TabIndex = 14;
            // 
            // fomantFolderSelectButton
            // 
            this.fomantFolderSelectButton.Location = new System.Drawing.Point(464, 229);
            this.fomantFolderSelectButton.Name = "fomantFolderSelectButton";
            this.fomantFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.fomantFolderSelectButton.TabIndex = 19;
            this.fomantFolderSelectButton.Text = "...";
            this.fomantFolderSelectButton.UseVisualStyleBackColor = true;
            this.fomantFolderSelectButton.Click += new System.EventHandler(this.fomantFolderSelectButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fomant Folder";
            // 
            // fomantFolderTextBox
            // 
            this.fomantFolderTextBox.Enabled = false;
            this.fomantFolderTextBox.Location = new System.Drawing.Point(126, 229);
            this.fomantFolderTextBox.Name = "fomantFolderTextBox";
            this.fomantFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.fomantFolderTextBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 25);
            this.label5.MaximumSize = new System.Drawing.Size(400, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "This allows you to set the file locations used by the system. Note that MPAi depe" +
    "nds on files it finds in these locations; it is advised not to change these.";
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 304);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fomantFolderSelectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fomantFolderTextBox);
            this.Controls.Add(this.HTKFolderSelectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HTKFolderTextBox);
            this.Controls.Add(this.reportFolderSelectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportFolderTextBox);
            this.Controls.Add(this.recordingFolderSelectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recordingFolderTextBox);
            this.Controls.Add(this.videoFolderSelectButton);
            this.Controls.Add(this.videoFolderlabel);
            this.Controls.Add(this.videoFolderTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.audioFolderSelectButton);
            this.Controls.Add(this.audioFolderLabel);
            this.Controls.Add(this.audioFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set System Paths";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox audioFolderTextBox;
        private System.Windows.Forms.Label audioFolderLabel;
        private System.Windows.Forms.Button audioFolderSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button videoFolderSelectButton;
        private System.Windows.Forms.Label videoFolderlabel;
        private System.Windows.Forms.TextBox videoFolderTextBox;
        private System.Windows.Forms.Button reportFolderSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reportFolderTextBox;
        private System.Windows.Forms.Button recordingFolderSelectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox recordingFolderTextBox;
        private System.Windows.Forms.Button HTKFolderSelectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HTKFolderTextBox;
        private System.Windows.Forms.Button fomantFolderSelectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fomantFolderTextBox;
        private System.Windows.Forms.Label label5;
    }
}

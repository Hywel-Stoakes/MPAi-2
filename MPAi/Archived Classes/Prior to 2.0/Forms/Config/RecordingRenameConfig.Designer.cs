namespace MPAi.Forms.Config
{
    partial class RecordingRenameConfig
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filePickerButton = new System.Windows.Forms.Button();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.speakerTextBox = new System.Windows.Forms.TextBox();
            this.speakerLabel = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.wordLabel = new System.Windows.Forms.Label();
            this.labelTextBox = new System.Windows.Forms.TextBox();
            this.labelLabel = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(312, 204);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(393, 204);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 1;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "recording";
            this.openFileDialog.Filter = "Audio files (*.wav)|*.wav|All files (*.*)|*.*";
            // 
            // filePickerButton
            // 
            this.filePickerButton.Location = new System.Drawing.Point(418, 41);
            this.filePickerButton.Name = "filePickerButton";
            this.filePickerButton.Size = new System.Drawing.Size(50, 23);
            this.filePickerButton.TabIndex = 2;
            this.filePickerButton.Text = "...";
            this.filePickerButton.UseVisualStyleBackColor = true;
            this.filePickerButton.Click += new System.EventHandler(this.filePickerButton_Click);
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(35, 46);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(49, 13);
            this.filenameLabel.TabIndex = 3;
            this.filenameLabel.Text = "Filename";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Location = new System.Drawing.Point(90, 43);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.ReadOnly = true;
            this.filenameTextBox.Size = new System.Drawing.Size(322, 20);
            this.filenameTextBox.TabIndex = 4;
            // 
            // speakerTextBox
            // 
            this.speakerTextBox.Location = new System.Drawing.Point(90, 73);
            this.speakerTextBox.Name = "speakerTextBox";
            this.speakerTextBox.Size = new System.Drawing.Size(322, 20);
            this.speakerTextBox.TabIndex = 6;
            // 
            // speakerLabel
            // 
            this.speakerLabel.AutoSize = true;
            this.speakerLabel.Location = new System.Drawing.Point(35, 78);
            this.speakerLabel.Name = "speakerLabel";
            this.speakerLabel.Size = new System.Drawing.Size(47, 13);
            this.speakerLabel.TabIndex = 5;
            this.speakerLabel.Text = "Speaker";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(90, 99);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(322, 20);
            this.categoryTextBox.TabIndex = 8;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(35, 104);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(49, 13);
            this.CategoryLabel.TabIndex = 7;
            this.CategoryLabel.Text = "Category";
            // 
            // wordTextBox
            // 
            this.wordTextBox.Location = new System.Drawing.Point(90, 125);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(322, 20);
            this.wordTextBox.TabIndex = 10;
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(35, 130);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(33, 13);
            this.wordLabel.TabIndex = 9;
            this.wordLabel.Text = "Word";
            // 
            // labelTextBox
            // 
            this.labelTextBox.Location = new System.Drawing.Point(90, 151);
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(322, 20);
            this.labelTextBox.TabIndex = 12;
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(35, 156);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(33, 13);
            this.labelLabel.TabIndex = 11;
            this.labelLabel.Text = "Label";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(418, 74);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(50, 23);
            this.testButton.TabIndex = 13;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // RecordingRenameConfig
            // 
            this.AcceptButton = this.renameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(501, 239);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.labelTextBox);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.speakerTextBox);
            this.Controls.Add(this.speakerLabel);
            this.Controls.Add(this.filenameTextBox);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.filePickerButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordingRenameConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Recordings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button filePickerButton;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.TextBox speakerTextBox;
        private System.Windows.Forms.Label speakerLabel;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.TextBox labelTextBox;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Button testButton;
    }
}
using MPAi.Components;

namespace MPAi.Forms.Popups
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfig));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveButton = new MPAi.Components.MPAiButton(this.components);
            this.cancelButton = new MPAi.Components.MPAiButton(this.components);
            this.videoFolderSelectButton = new MPAi.Components.MPAiButton(this.components);
            this.videoFolderlabel = new System.Windows.Forms.Label();
            this.videoFolderTextBox = new System.Windows.Forms.TextBox();
            this.reportFolderSelectButton = new MPAi.Components.MPAiButton(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.reportFolderTextBox = new System.Windows.Forms.TextBox();
            this.formantFolderSelectButton = new MPAi.Components.MPAiButton(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.formantFolderTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(779, 401);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(102, 48);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(893, 401);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 48);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // videoFolderSelectButton
            // 
            this.videoFolderSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.videoFolderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoFolderSelectButton.ForeColor = System.Drawing.Color.White;
            this.videoFolderSelectButton.Location = new System.Drawing.Point(927, 157);
            this.videoFolderSelectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.videoFolderSelectButton.Name = "videoFolderSelectButton";
            this.videoFolderSelectButton.Size = new System.Drawing.Size(66, 48);
            this.videoFolderSelectButton.TabIndex = 7;
            this.videoFolderSelectButton.Text = "...";
            this.videoFolderSelectButton.UseVisualStyleBackColor = true;
            this.videoFolderSelectButton.Click += new System.EventHandler(this.videoFolderSelectButton_Click);
            // 
            // videoFolderlabel
            // 
            this.videoFolderlabel.AutoSize = true;
            this.videoFolderlabel.Location = new System.Drawing.Point(37, 163);
            this.videoFolderlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.videoFolderlabel.Name = "videoFolderlabel";
            this.videoFolderlabel.Size = new System.Drawing.Size(134, 25);
            this.videoFolderlabel.TabIndex = 6;
            this.videoFolderlabel.Text = "Video Folder";
            // 
            // videoFolderTextBox
            // 
            this.videoFolderTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.videoFolderTextBox.Enabled = false;
            this.videoFolderTextBox.Location = new System.Drawing.Point(251, 157);
            this.videoFolderTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.videoFolderTextBox.Name = "videoFolderTextBox";
            this.videoFolderTextBox.Size = new System.Drawing.Size(660, 31);
            this.videoFolderTextBox.TabIndex = 5;
            // 
            // reportFolderSelectButton
            // 
            this.reportFolderSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.reportFolderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportFolderSelectButton.ForeColor = System.Drawing.Color.White;
            this.reportFolderSelectButton.Location = new System.Drawing.Point(927, 231);
            this.reportFolderSelectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.reportFolderSelectButton.Name = "reportFolderSelectButton";
            this.reportFolderSelectButton.Size = new System.Drawing.Size(66, 48);
            this.reportFolderSelectButton.TabIndex = 13;
            this.reportFolderSelectButton.Text = "...";
            this.reportFolderSelectButton.UseVisualStyleBackColor = true;
            this.reportFolderSelectButton.Click += new System.EventHandler(this.reportFolderSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 237);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Report Folder";
            // 
            // reportFolderTextBox
            // 
            this.reportFolderTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportFolderTextBox.Enabled = false;
            this.reportFolderTextBox.Location = new System.Drawing.Point(251, 231);
            this.reportFolderTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.reportFolderTextBox.Name = "reportFolderTextBox";
            this.reportFolderTextBox.Size = new System.Drawing.Size(660, 31);
            this.reportFolderTextBox.TabIndex = 11;
            // 
            // formantFolderSelectButton
            // 
            this.formantFolderSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.formantFolderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formantFolderSelectButton.ForeColor = System.Drawing.Color.White;
            this.formantFolderSelectButton.Location = new System.Drawing.Point(927, 304);
            this.formantFolderSelectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.formantFolderSelectButton.Name = "formantFolderSelectButton";
            this.formantFolderSelectButton.Size = new System.Drawing.Size(66, 48);
            this.formantFolderSelectButton.TabIndex = 19;
            this.formantFolderSelectButton.Text = "...";
            this.formantFolderSelectButton.UseVisualStyleBackColor = true;
            this.formantFolderSelectButton.Click += new System.EventHandler(this.formantFolderSelectButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Formant Folder";
            // 
            // formantFolderTextBox
            // 
            this.formantFolderTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.formantFolderTextBox.Enabled = false;
            this.formantFolderTextBox.Location = new System.Drawing.Point(251, 304);
            this.formantFolderTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.formantFolderTextBox.Name = "formantFolderTextBox";
            this.formantFolderTextBox.Size = new System.Drawing.Size(660, 31);
            this.formantFolderTextBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.MaximumSize = new System.Drawing.Size(800, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(741, 50);
            this.label5.TabIndex = 20;
            this.label5.Text = "This allows you to set the file locations used by the system. Note that MPAi depe" +
    "nds on files it finds in these locations; it is advised not to change these.";
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 482);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.formantFolderSelectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.formantFolderTextBox);
            this.Controls.Add(this.reportFolderSelectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportFolderTextBox);
            this.Controls.Add(this.videoFolderSelectButton);
            this.Controls.Add(this.videoFolderlabel);
            this.Controls.Add(this.videoFolderTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set System Paths";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private MPAiButton saveButton;
        private MPAiButton cancelButton;
        private MPAiButton videoFolderSelectButton;
        private System.Windows.Forms.Label videoFolderlabel;
        private System.Windows.Forms.TextBox videoFolderTextBox;
        private MPAiButton reportFolderSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reportFolderTextBox;
        private MPAiButton formantFolderSelectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox formantFolderTextBox;
        private System.Windows.Forms.Label label5;
    }
}

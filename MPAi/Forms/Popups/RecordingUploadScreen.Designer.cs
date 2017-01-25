namespace MPAi.NewForms
{
    partial class RecordingUploadScreen
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
            this.toLocalButton = new System.Windows.Forms.Button();
            this.toDBButton = new System.Windows.Forms.Button();
            this.onDBListBox = new System.Windows.Forms.ListBox();
            this.allLocalItemsButton = new System.Windows.Forms.Button();
            this.mediaLocalListBox = new System.Windows.Forms.ListBox();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.currentFolderTextBox = new System.Windows.Forms.TextBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.allDatabaseItemsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // toLocalButton
            // 
            this.toLocalButton.Location = new System.Drawing.Point(218, 65);
            this.toLocalButton.Name = "toLocalButton";
            this.toLocalButton.Size = new System.Drawing.Size(148, 25);
            this.toLocalButton.TabIndex = 12;
            this.toLocalButton.Text = "Delete from Database";
            this.toLocalButton.UseVisualStyleBackColor = true;
            this.toLocalButton.Click += new System.EventHandler(this.toLocalButton_Click);
            // 
            // toDBButton
            // 
            this.toDBButton.Location = new System.Drawing.Point(218, 34);
            this.toDBButton.Name = "toDBButton";
            this.toDBButton.Size = new System.Drawing.Size(148, 25);
            this.toDBButton.TabIndex = 11;
            this.toDBButton.Text = "Add to Database";
            this.toDBButton.UseVisualStyleBackColor = true;
            this.toDBButton.Click += new System.EventHandler(this.toDBButton_Click);
            // 
            // onDBListBox
            // 
            this.onDBListBox.FormattingEnabled = true;
            this.onDBListBox.HorizontalScrollbar = true;
            this.onDBListBox.Location = new System.Drawing.Point(372, 35);
            this.onDBListBox.Name = "onDBListBox";
            this.onDBListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.onDBListBox.Size = new System.Drawing.Size(200, 147);
            this.onDBListBox.TabIndex = 10;
            // 
            // allLocalItemsButton
            // 
            this.allLocalItemsButton.Location = new System.Drawing.Point(218, 96);
            this.allLocalItemsButton.Name = "allLocalItemsButton";
            this.allLocalItemsButton.Size = new System.Drawing.Size(148, 23);
            this.allLocalItemsButton.TabIndex = 15;
            this.allLocalItemsButton.Tag = "1";
            this.allLocalItemsButton.Text = "Select All Local Files";
            this.allLocalItemsButton.UseVisualStyleBackColor = true;
            this.allLocalItemsButton.Click += new System.EventHandler(this.allLocalItemsButton_Click);
            // 
            // mediaLocalListBox
            // 
            this.mediaLocalListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaLocalListBox.FormattingEnabled = true;
            this.mediaLocalListBox.HorizontalScrollbar = true;
            this.mediaLocalListBox.Location = new System.Drawing.Point(12, 35);
            this.mediaLocalListBox.Name = "mediaLocalListBox";
            this.mediaLocalListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.mediaLocalListBox.Size = new System.Drawing.Size(200, 147);
            this.mediaLocalListBox.TabIndex = 14;
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Location = new System.Drawing.Point(369, 15);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(70, 13);
            this.databaseLabel.TabIndex = 16;
            this.databaseLabel.Text = "On Database";
            // 
            // currentFolderTextBox
            // 
            this.currentFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentFolderTextBox.Location = new System.Drawing.Point(12, 9);
            this.currentFolderTextBox.MaximumSize = new System.Drawing.Size(175, 15);
            this.currentFolderTextBox.MinimumSize = new System.Drawing.Size(175, 15);
            this.currentFolderTextBox.Name = "currentFolderTextBox";
            this.currentFolderTextBox.ReadOnly = true;
            this.currentFolderTextBox.Size = new System.Drawing.Size(175, 20);
            this.currentFolderTextBox.TabIndex = 17;
            this.currentFolderTextBox.Text = "No Folder Selected";
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(192, 8);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(27, 23);
            this.selectFolderButton.TabIndex = 18;
            this.selectFolderButton.Text = "...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // allDatabaseItemsButton
            // 
            this.allDatabaseItemsButton.Location = new System.Drawing.Point(218, 125);
            this.allDatabaseItemsButton.Name = "allDatabaseItemsButton";
            this.allDatabaseItemsButton.Size = new System.Drawing.Size(148, 23);
            this.allDatabaseItemsButton.TabIndex = 19;
            this.allDatabaseItemsButton.Tag = "1";
            this.allDatabaseItemsButton.Text = "Select All Database Files";
            this.allDatabaseItemsButton.UseVisualStyleBackColor = true;
            this.allDatabaseItemsButton.Click += new System.EventHandler(this.allDatabaseItemsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(218, 154);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(148, 23);
            this.backButton.TabIndex = 20;
            this.backButton.Tag = "1";
            this.backButton.Text = "Close";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // RecordingUploadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 193);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.allDatabaseItemsButton);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.currentFolderTextBox);
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.toLocalButton);
            this.Controls.Add(this.toDBButton);
            this.Controls.Add(this.onDBListBox);
            this.Controls.Add(this.allLocalItemsButton);
            this.Controls.Add(this.mediaLocalListBox);
            this.Name = "RecordingUploadScreen";
            this.Text = "RecordingUploadScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toLocalButton;
        private System.Windows.Forms.Button toDBButton;
        private System.Windows.Forms.ListBox onDBListBox;
        private System.Windows.Forms.Button allLocalItemsButton;
        private System.Windows.Forms.ListBox mediaLocalListBox;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.TextBox currentFolderTextBox;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.Button allDatabaseItemsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
using MPAi.Models;

namespace MPAi.Forms.Config
{
    partial class RecordingUploadConfig
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
            this.onDBListBox = new System.Windows.Forms.ListBox();
            this.toDBButton = new System.Windows.Forms.Button();
            this.toLocalButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mediaLocalListBox = new System.Windows.Forms.ListBox();
            this.allItemsButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.DBRadioButton = new System.Windows.Forms.RadioButton();
            this.localRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // onDBListBox
            // 
            this.onDBListBox.FormattingEnabled = true;
            this.onDBListBox.HorizontalScrollbar = true;
            this.onDBListBox.Location = new System.Drawing.Point(37, 34);
            this.onDBListBox.Name = "onDBListBox";
            this.onDBListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.onDBListBox.Size = new System.Drawing.Size(189, 251);
            this.onDBListBox.TabIndex = 1;
            // 
            // toDBButton
            // 
            this.toDBButton.Location = new System.Drawing.Point(247, 34);
            this.toDBButton.Name = "toDBButton";
            this.toDBButton.Size = new System.Drawing.Size(50, 25);
            this.toDBButton.TabIndex = 2;
            this.toDBButton.Text = "<<";
            this.toDBButton.UseVisualStyleBackColor = true;
            this.toDBButton.Click += new System.EventHandler(this.toDBButton_Click);
            // 
            // toLocalButton
            // 
            this.toLocalButton.Location = new System.Drawing.Point(247, 92);
            this.toLocalButton.Name = "toLocalButton";
            this.toLocalButton.Size = new System.Drawing.Size(50, 25);
            this.toLocalButton.TabIndex = 3;
            this.toLocalButton.Text = ">>";
            this.toLocalButton.UseVisualStyleBackColor = true;
            this.toLocalButton.Click += new System.EventHandler(this.toLocalButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(247, 260);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(50, 25);
            this.selectFileButton.TabIndex = 4;
            this.selectFileButton.Text = "Select";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Speaker-Category-Word.Ext";
            this.openFileDialog.Multiselect = true;
            // 
            // mediaLocalListBox
            // 
            this.mediaLocalListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaLocalListBox.FormattingEnabled = true;
            this.mediaLocalListBox.HorizontalScrollbar = true;
            this.mediaLocalListBox.Location = new System.Drawing.Point(314, 34);
            this.mediaLocalListBox.Name = "mediaLocalListBox";
            this.mediaLocalListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.mediaLocalListBox.Size = new System.Drawing.Size(201, 251);
            this.mediaLocalListBox.TabIndex = 5;
            // 
            // allItemsButton
            // 
            this.allItemsButton.Location = new System.Drawing.Point(247, 195);
            this.allItemsButton.Name = "allItemsButton";
            this.allItemsButton.Size = new System.Drawing.Size(50, 23);
            this.allItemsButton.TabIndex = 6;
            this.allItemsButton.Tag = "1";
            this.allItemsButton.Text = "All";
            this.allItemsButton.UseVisualStyleBackColor = true;
            this.allItemsButton.Click += new System.EventHandler(this.allItemsButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-54, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // DBRadioButton
            // 
            this.DBRadioButton.AutoSize = true;
            this.DBRadioButton.Location = new System.Drawing.Point(37, 12);
            this.DBRadioButton.Name = "DBRadioButton";
            this.DBRadioButton.Size = new System.Drawing.Size(107, 17);
            this.DBRadioButton.TabIndex = 8;
            this.DBRadioButton.Text = "Database Listbox";
            this.DBRadioButton.UseVisualStyleBackColor = true;
            // 
            // localRadioButton
            // 
            this.localRadioButton.AutoSize = true;
            this.localRadioButton.Checked = true;
            this.localRadioButton.Location = new System.Drawing.Point(314, 11);
            this.localRadioButton.Name = "localRadioButton";
            this.localRadioButton.Size = new System.Drawing.Size(87, 17);
            this.localRadioButton.TabIndex = 9;
            this.localRadioButton.TabStop = true;
            this.localRadioButton.Text = "Local Listbox";
            this.localRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecordingUploadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 312);
            this.Controls.Add(this.localRadioButton);
            this.Controls.Add(this.DBRadioButton);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.allItemsButton);
            this.Controls.Add(this.mediaLocalListBox);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.toLocalButton);
            this.Controls.Add(this.toDBButton);
            this.Controls.Add(this.onDBListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordingUploadConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload to Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox onDBListBox;
        private System.Windows.Forms.Button toDBButton;
        private System.Windows.Forms.Button toLocalButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox mediaLocalListBox;
        private System.Windows.Forms.Button allItemsButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton DBRadioButton;
        private System.Windows.Forms.RadioButton localRadioButton;
    }
}

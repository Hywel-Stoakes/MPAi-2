namespace MPAi.NewForms
{
    partial class SpeechRecognitionTest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeechRecognitionTest));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mpAiSoundMenuStrip1 = new MPAi.NewForms.MenuStrip(this.components);
            this.SpeechRecognitionTestPanel = new System.Windows.Forms.SplitContainer();
            this.backButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.WordComboBox = new System.Windows.Forms.ComboBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.recordingProgressBarLabel = new System.Windows.Forms.Label();
            this.recordButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.recordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.AudioInputDeviceButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.ScoreReportButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.RecordingListBox = new System.Windows.Forms.ListBox();
            this.RecordingListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpeechRecognitionTestPanel)).BeginInit();
            this.SpeechRecognitionTestPanel.Panel1.SuspendLayout();
            this.SpeechRecognitionTestPanel.Panel2.SuspendLayout();
            this.SpeechRecognitionTestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Wave files (*.wav)|*.wav|All Files(*.*)|*.*";
            this.openFileDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.MyMusic, Environment.SpecialF" +
    "olderOption.None)";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Select a Recording...";
            // 
            // mpAiSoundMenuStrip1
            // 
            this.mpAiSoundMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.mpAiSoundMenuStrip1.Name = "mpAiSoundMenuStrip1";
            this.mpAiSoundMenuStrip1.Size = new System.Drawing.Size(584, 24);
            this.mpAiSoundMenuStrip1.TabIndex = 43;
            this.mpAiSoundMenuStrip1.Text = "mpAiSoundMenuStrip1";
            // 
            // SpeechRecognitionTestPanel
            // 
            this.SpeechRecognitionTestPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeechRecognitionTestPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SpeechRecognitionTestPanel.Location = new System.Drawing.Point(0, 24);
            this.SpeechRecognitionTestPanel.Name = "SpeechRecognitionTestPanel";
            this.SpeechRecognitionTestPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SpeechRecognitionTestPanel.Panel1
            // 
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.backButton);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.optionsButton);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.WordComboBox);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.analyzeButton);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.recordingProgressBarLabel);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.recordButton);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.playButton);
            this.SpeechRecognitionTestPanel.Panel1.Controls.Add(this.recordingProgressBar);
            // 
            // SpeechRecognitionTestPanel.Panel2
            // 
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.AudioInputDeviceButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.RenameButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.AudioInputDeviceComboBox);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.DeleteButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.AudioInputDeviceLabel);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.AddButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.ScoreReportButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.SelectButton);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.RecordingListBox);
            this.SpeechRecognitionTestPanel.Panel2.Controls.Add(this.RecordingListLabel);
            this.SpeechRecognitionTestPanel.Panel2MinSize = 250;
            this.SpeechRecognitionTestPanel.Size = new System.Drawing.Size(584, 535);
            this.SpeechRecognitionTestPanel.SplitterDistance = 240;
            this.SpeechRecognitionTestPanel.SplitterWidth = 1;
            this.SpeechRecognitionTestPanel.TabIndex = 44;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(474, 206);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 25);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(368, 206);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(100, 25);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Less...";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // WordComboBox
            // 
            this.WordComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WordComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.WordComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.WordComboBox.FormattingEnabled = true;
            this.WordComboBox.ItemHeight = 13;
            this.WordComboBox.Location = new System.Drawing.Point(115, 21);
            this.WordComboBox.Name = "WordComboBox";
            this.WordComboBox.Size = new System.Drawing.Size(350, 21);
            this.WordComboBox.TabIndex = 0;
            this.WordComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WordComboBox_KeyPress);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzeButton.Enabled = false;
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.analyzeButton.Location = new System.Drawing.Point(150, 145);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(300, 25);
            this.analyzeButton.TabIndex = 3;
            this.analyzeButton.Text = "&Analyze!";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // recordingProgressBarLabel
            // 
            this.recordingProgressBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBarLabel.BackColor = System.Drawing.SystemColors.Control;
            this.recordingProgressBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recordingProgressBarLabel.Location = new System.Drawing.Point(117, 80);
            this.recordingProgressBarLabel.Name = "recordingProgressBarLabel";
            this.recordingProgressBarLabel.Size = new System.Drawing.Size(350, 50);
            this.recordingProgressBarLabel.TabIndex = 36;
            this.recordingProgressBarLabel.Text = "No current file";
            this.recordingProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recordingProgressBarLabel.TextChanged += new System.EventHandler(this.recordingProgressBarLabel_TextChanged);
            // 
            // recordButton
            // 
            this.recordButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(10, 92);
            this.recordButton.Margin = new System.Windows.Forms.Padding(0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(100, 25);
            this.recordButton.TabIndex = 1;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playButton.Enabled = false;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playButton.Location = new System.Drawing.Point(474, 92);
            this.playButton.Margin = new System.Windows.Forms.Padding(0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(100, 25);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // recordingProgressBar
            // 
            this.recordingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBar.Location = new System.Drawing.Point(117, 80);
            this.recordingProgressBar.Name = "recordingProgressBar";
            this.recordingProgressBar.Size = new System.Drawing.Size(350, 50);
            this.recordingProgressBar.TabIndex = 40;
            // 
            // AudioInputDeviceButton
            // 
            this.AudioInputDeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioInputDeviceButton.Location = new System.Drawing.Point(474, 22);
            this.AudioInputDeviceButton.Margin = new System.Windows.Forms.Padding(10);
            this.AudioInputDeviceButton.Name = "AudioInputDeviceButton";
            this.AudioInputDeviceButton.Size = new System.Drawing.Size(100, 25);
            this.AudioInputDeviceButton.TabIndex = 7;
            this.AudioInputDeviceButton.Text = "Refresh";
            this.AudioInputDeviceButton.UseVisualStyleBackColor = true;
            this.AudioInputDeviceButton.Click += new System.EventHandler(this.AudioInputDeviceButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameButton.Enabled = false;
            this.RenameButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RenameButton.Location = new System.Drawing.Point(474, 208);
            this.RenameButton.Margin = new System.Windows.Forms.Padding(10);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(100, 25);
            this.RenameButton.TabIndex = 12;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(115, 24);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(353, 21);
            this.AudioInputDeviceComboBox.TabIndex = 6;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DeleteButton.Location = new System.Drawing.Point(474, 163);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(10);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 25);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(7, 27);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(98, 13);
            this.AudioInputDeviceLabel.TabIndex = 0;
            this.AudioInputDeviceLabel.Text = "Audio Input Device";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddButton.Location = new System.Drawing.Point(474, 118);
            this.AddButton.Margin = new System.Windows.Forms.Padding(10);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 25);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add...";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ScoreReportButton
            // 
            this.ScoreReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreReportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ScoreReportButton.Location = new System.Drawing.Point(150, 253);
            this.ScoreReportButton.Margin = new System.Windows.Forms.Padding(0);
            this.ScoreReportButton.Name = "ScoreReportButton";
            this.ScoreReportButton.Size = new System.Drawing.Size(300, 25);
            this.ScoreReportButton.TabIndex = 13;
            this.ScoreReportButton.Text = "Score Report";
            this.ScoreReportButton.UseVisualStyleBackColor = true;
            this.ScoreReportButton.Click += new System.EventHandler(this.ScoreReportButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectButton.Enabled = false;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectButton.Location = new System.Drawing.Point(474, 73);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(10);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(100, 25);
            this.SelectButton.TabIndex = 9;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // RecordingListBox
            // 
            this.RecordingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordingListBox.FormattingEnabled = true;
            this.RecordingListBox.Location = new System.Drawing.Point(10, 75);
            this.RecordingListBox.Name = "RecordingListBox";
            this.RecordingListBox.Size = new System.Drawing.Size(458, 160);
            this.RecordingListBox.TabIndex = 8;
            this.RecordingListBox.SelectedIndexChanged += new System.EventHandler(this.RecordingListBox_SelectedIndexChanged);
            this.RecordingListBox.DoubleClick += new System.EventHandler(this.SelectButton_Click);
            // 
            // RecordingListLabel
            // 
            this.RecordingListLabel.AutoSize = true;
            this.RecordingListLabel.Location = new System.Drawing.Point(7, 59);
            this.RecordingListLabel.Name = "RecordingListLabel";
            this.RecordingListLabel.Size = new System.Drawing.Size(75, 13);
            this.RecordingListLabel.TabIndex = 1;
            this.RecordingListLabel.Text = "Recording List";
            // 
            // SpeechRecognitionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.SpeechRecognitionTestPanel);
            this.Controls.Add(this.mpAiSoundMenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mpAiSoundMenuStrip1;
            this.MinimumSize = new System.Drawing.Size(375, 600);
            this.Name = "SpeechRecognitionTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPAi - Version 4.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeechRecognitionTest_FormClosing);
            this.SpeechRecognitionTestPanel.Panel1.ResumeLayout(false);
            this.SpeechRecognitionTestPanel.Panel2.ResumeLayout(false);
            this.SpeechRecognitionTestPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeechRecognitionTestPanel)).EndInit();
            this.SpeechRecognitionTestPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private MenuStrip mpAiSoundMenuStrip1;
        private System.Windows.Forms.SplitContainer SpeechRecognitionTestPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.ComboBox WordComboBox;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label recordingProgressBarLabel;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ProgressBar recordingProgressBar;
        private System.Windows.Forms.Button AudioInputDeviceButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.ComboBox AudioInputDeviceComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label AudioInputDeviceLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ScoreReportButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ListBox RecordingListBox;
        private System.Windows.Forms.Label RecordingListLabel;
    }
}
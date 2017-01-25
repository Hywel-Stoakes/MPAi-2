namespace MPAi.UserControls
{
    partial class NAudioRecorder
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
            this.RECListBox = new System.Windows.Forms.ListBox();
            this.recordButton = new System.Windows.Forms.Button();
            this.fromFileButton = new System.Windows.Forms.Button();
            this.showReportButton = new System.Windows.Forms.Button();
            this.correctnessLabel = new System.Windows.Forms.Label();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.audioDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deviceRefreshButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RECListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.RECListBox, 5);
            this.RECListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RECListBox.FormattingEnabled = true;
            this.RECListBox.HorizontalScrollbar = true;
            this.RECListBox.Location = new System.Drawing.Point(3, 34);
            this.RECListBox.Name = "RECListBox";
            this.tableLayoutPanel1.SetRowSpan(this.RECListBox, 5);
            this.RECListBox.Size = new System.Drawing.Size(426, 149);
            this.RECListBox.TabIndex = 23;
            this.RECListBox.SelectedValueChanged += new System.EventHandler(this.RECListBox_SelectedValueChanged);
            this.RECListBox.DoubleClick += new System.EventHandler(this.RECListBox_DoubleClick);
            // 
            // recordButton
            // 
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(435, 34);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(39, 25);
            this.recordButton.TabIndex = 15;
            this.recordButton.Text = "&Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // fromFileButton
            // 
            this.fromFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fromFileButton.Location = new System.Drawing.Point(435, 158);
            this.fromFileButton.Name = "fromFileButton";
            this.fromFileButton.Size = new System.Drawing.Size(39, 25);
            this.fromFileButton.TabIndex = 21;
            this.fromFileButton.Text = "From file";
            this.fromFileButton.UseVisualStyleBackColor = true;
            this.fromFileButton.Click += new System.EventHandler(this.fromFileButton_Click);
            // 
            // showReportButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.showReportButton, 2);
            this.showReportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showReportButton.Enabled = false;
            this.showReportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showReportButton.Location = new System.Drawing.Point(199, 220);
            this.showReportButton.Name = "showReportButton";
            this.showReportButton.Size = new System.Drawing.Size(114, 29);
            this.showReportButton.TabIndex = 20;
            this.showReportButton.Text = "Show score report";
            this.showReportButton.UseVisualStyleBackColor = true;
            this.showReportButton.Click += new System.EventHandler(this.showReportButton_Click);
            // 
            // correctnessLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.correctnessLabel, 6);
            this.correctnessLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctnessLabel.ForeColor = System.Drawing.Color.Green;
            this.correctnessLabel.Location = new System.Drawing.Point(3, 186);
            this.correctnessLabel.Name = "correctnessLabel";
            this.correctnessLabel.Size = new System.Drawing.Size(471, 31);
            this.correctnessLabel.TabIndex = 19;
            this.correctnessLabel.Text = "Correctness";
            this.correctnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyzeButton.Enabled = false;
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.analyzeButton.Location = new System.Drawing.Point(435, 127);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(39, 25);
            this.analyzeButton.TabIndex = 16;
            this.analyzeButton.Text = "&Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(435, 65);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(39, 25);
            this.stopButton.TabIndex = 14;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // audioDeviceComboBox
            // 
            this.audioDeviceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioDeviceComboBox.FormattingEnabled = true;
            this.audioDeviceComboBox.Location = new System.Drawing.Point(83, 3);
            this.audioDeviceComboBox.Name = "audioDeviceComboBox";
            this.audioDeviceComboBox.Size = new System.Drawing.Size(110, 21);
            this.audioDeviceComboBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 31);
            this.label1.TabIndex = 24;
            this.label1.Text = "Audio Device";
            // 
            // recordingProgressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.recordingProgressBar, 2);
            this.recordingProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingProgressBar.Location = new System.Drawing.Point(319, 3);
            this.recordingProgressBar.Name = "recordingProgressBar";
            this.recordingProgressBar.Size = new System.Drawing.Size(155, 25);
            this.recordingProgressBar.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(239, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "Recording Progress";
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(435, 96);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(39, 25);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deviceRefreshButton
            // 
            this.deviceRefreshButton.Image = global::MPAi.Properties.Resources.refresh_16;
            this.deviceRefreshButton.Location = new System.Drawing.Point(199, 3);
            this.deviceRefreshButton.Name = "deviceRefreshButton";
            this.deviceRefreshButton.Size = new System.Drawing.Size(23, 21);
            this.deviceRefreshButton.TabIndex = 29;
            this.deviceRefreshButton.UseVisualStyleBackColor = true;
            this.deviceRefreshButton.Click += new System.EventHandler(this.deviceRefreshButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.Controls.Add(this.audioDeviceComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromFileButton, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.deviceRefreshButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.recordButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.analyzeButton, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.RECListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stopButton, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.correctnessLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.recordingProgressBar, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.showReportButton, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 252);
            this.tableLayoutPanel1.TabIndex = 30;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // NAudioRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NAudioRecorder";
            this.Size = new System.Drawing.Size(477, 252);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label correctnessLabel;
        private System.Windows.Forms.Button showReportButton;
        private System.Windows.Forms.Button fromFileButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.ListBox RECListBox;
        private System.Windows.Forms.ComboBox audioDeviceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar recordingProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deviceRefreshButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

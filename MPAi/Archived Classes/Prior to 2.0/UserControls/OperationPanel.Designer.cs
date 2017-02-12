namespace MPAi.UserControls
{
    partial class OperationPanel
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
            this.operationTabControl = new System.Windows.Forms.TabControl();
            this.videoPlayerTabPage = new System.Windows.Forms.TabPage();
            this.recognizerTabPage = new System.Windows.Forms.TabPage();
            this.pronunAidTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vlcPlayer = new MPAi.UserControls.VlcPlayer();
            this.naudioRecorder = new MPAi.UserControls.NAudioRecorder();
            this.tdButtonFormantPlot = new MPAi.TDButton();
            this.operationTabControl.SuspendLayout();
            this.videoPlayerTabPage.SuspendLayout();
            this.recognizerTabPage.SuspendLayout();
            this.pronunAidTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationTabControl
            // 
            this.operationTabControl.Controls.Add(this.videoPlayerTabPage);
            this.operationTabControl.Controls.Add(this.recognizerTabPage);
            this.operationTabControl.Controls.Add(this.pronunAidTabPage);
            this.operationTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationTabControl.Location = new System.Drawing.Point(3, 17);
            this.operationTabControl.Name = "operationTabControl";
            this.operationTabControl.SelectedIndex = 0;
            this.operationTabControl.Size = new System.Drawing.Size(643, 418);
            this.operationTabControl.TabIndex = 0;
            this.operationTabControl.Tag = "";
            this.operationTabControl.SelectedIndexChanged += new System.EventHandler(this.operationTabControlSelectedIndexChanged);
            // 
            // videoPlayerTabPage
            // 
            this.videoPlayerTabPage.Controls.Add(this.vlcPlayer);
            this.videoPlayerTabPage.Location = new System.Drawing.Point(4, 22);
            this.videoPlayerTabPage.Name = "videoPlayerTabPage";
            this.videoPlayerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoPlayerTabPage.Size = new System.Drawing.Size(635, 392);
            this.videoPlayerTabPage.TabIndex = 0;
            this.videoPlayerTabPage.Text = "Video Player";
            this.videoPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // recognizerTabPage
            // 
            this.recognizerTabPage.Controls.Add(this.naudioRecorder);
            this.recognizerTabPage.Location = new System.Drawing.Point(4, 22);
            this.recognizerTabPage.Name = "recognizerTabPage";
            this.recognizerTabPage.Size = new System.Drawing.Size(635, 392);
            this.recognizerTabPage.TabIndex = 2;
            this.recognizerTabPage.Text = "Recognizer";
            this.recognizerTabPage.UseVisualStyleBackColor = true;
            // 
            // pronunAidTabPage
            // 
            this.pronunAidTabPage.Controls.Add(this.groupBox4);
            this.pronunAidTabPage.Location = new System.Drawing.Point(4, 22);
            this.pronunAidTabPage.Name = "pronunAidTabPage";
            this.pronunAidTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pronunAidTabPage.Size = new System.Drawing.Size(635, 392);
            this.pronunAidTabPage.TabIndex = 1;
            this.pronunAidTabPage.Text = "Pronunciation Aid";
            this.pronunAidTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tdButtonFormantPlot);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 51);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Formant Plot";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.operationTabControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 438);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Panel";
            // 
            // vlcPlayer
            // 
            this.vlcPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcPlayer.Location = new System.Drawing.Point(3, 3);
            this.vlcPlayer.Name = "vlcPlayer";
            this.vlcPlayer.Size = new System.Drawing.Size(629, 386);
            this.vlcPlayer.TabIndex = 0;
            // 
            // naudioRecorder
            // 
            this.naudioRecorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.naudioRecorder.Location = new System.Drawing.Point(4, 4);
            this.naudioRecorder.Name = "naudioRecorder";
            this.naudioRecorder.Size = new System.Drawing.Size(616, 387);
            this.naudioRecorder.TabIndex = 0;
            // 
            // tdButtonFormantPlot
            // 
            this.tdButtonFormantPlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tdButtonFormantPlot.BackgroundImage = global::MPAi.Properties.Resources.ButtonYellow_0;
            this.tdButtonFormantPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tdButtonFormantPlot.FlatAppearance.BorderSize = 0;
            this.tdButtonFormantPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tdButtonFormantPlot.Location = new System.Drawing.Point(166, 18);
            this.tdButtonFormantPlot.Name = "tdButtonFormantPlot";
            this.tdButtonFormantPlot.Size = new System.Drawing.Size(247, 25);
            this.tdButtonFormantPlot.TabIndex = 0;
            this.tdButtonFormantPlot.Text = "Open Formant Plot";
            this.tdButtonFormantPlot.UseVisualStyleBackColor = true;
            this.tdButtonFormantPlot.Click += new System.EventHandler(this.tdButtonFormantPlot_Click);
            // 
            // OperationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(649, 438);
            this.operationTabControl.ResumeLayout(false);
            this.videoPlayerTabPage.ResumeLayout(false);
            this.recognizerTabPage.ResumeLayout(false);
            this.pronunAidTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl operationTabControl;
        private System.Windows.Forms.TabPage videoPlayerTabPage;
        private VlcPlayer vlcPlayer;
        private System.Windows.Forms.TabPage pronunAidTabPage;
        private System.Windows.Forms.GroupBox groupBox4;
        private TDButton tdButtonFormantPlot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage recognizerTabPage;
        private NAudioRecorder naudioRecorder;
    }
}

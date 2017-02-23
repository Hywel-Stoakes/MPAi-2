﻿using MPAi.Components;

namespace MPAi.Forms
{
    partial class MPAiSoundMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPAiSoundMainMenu));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.headerBox = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.testPanel = new System.Windows.Forms.Panel();
            this.TestTipLabel = new System.Windows.Forms.Label();
            this.TargetTipLabel = new System.Windows.Forms.Label();
            this.formantButton = new MPAi.Components.MPAiButton(this.components);
            this.targetButton = new MPAi.Components.MPAiButton(this.components);
            this.learnPanel = new System.Windows.Forms.Panel();
            this.LearnTipLabel = new System.Windows.Forms.Label();
            this.learnButton = new MPAi.Components.MPAiButton(this.components);
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.ScoreTipLabel = new System.Windows.Forms.Label();
            this.reportButton = new MPAi.Components.MPAiButton(this.components);
            this.menuStrip1 = new MPAi.Components.MenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.testPanel.SuspendLayout();
            this.learnPanel.SuspendLayout();
            this.ReportPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.headerBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(544, 361);
            this.splitContainer1.SplitterDistance = 103;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // headerBox
            // 
            this.headerBox.BackgroundImage = global::MPAi.Properties.Resources.header;
            this.headerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.headerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerBox.Location = new System.Drawing.Point(0, 25);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(544, 78);
            this.headerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.headerBox.TabIndex = 1;
            this.headerBox.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Panel1.Controls.Add(this.greetingLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(544, 254);
            this.splitContainer2.SplitterDistance = 87;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // greetingLabel
            // 
            this.greetingLabel.BackColor = System.Drawing.Color.Transparent;
            this.greetingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greetingLabel.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.Location = new System.Drawing.Point(0, 0);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(544, 87);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Kia Ora, User!";
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.testPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.learnPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReportPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 163);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // testPanel
            // 
            this.testPanel.Controls.Add(this.TestTipLabel);
            this.testPanel.Controls.Add(this.TargetTipLabel);
            this.testPanel.Controls.Add(this.formantButton);
            this.testPanel.Controls.Add(this.targetButton);
            this.testPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPanel.Location = new System.Drawing.Point(3, 57);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(538, 48);
            this.testPanel.TabIndex = 3;
            // 
            // TestTipLabel
            // 
            this.TestTipLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TestTipLabel.Location = new System.Drawing.Point(0, 33);
            this.TestTipLabel.Name = "TestTipLabel";
            this.TestTipLabel.Size = new System.Drawing.Size(538, 13);
            this.TestTipLabel.TabIndex = 6;
            this.TestTipLabel.Text = "Hone your pronunciation at your own pace with the full Formant space!";
            this.TestTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TestTipLabel.Visible = false;
            // 
            // TargetTipLabel
            // 
            this.TargetTipLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TargetTipLabel.Location = new System.Drawing.Point(0, 33);
            this.TargetTipLabel.Name = "TargetTipLabel";
            this.TargetTipLabel.Size = new System.Drawing.Size(541, 13);
            this.TargetTipLabel.TabIndex = 5;
            this.TargetTipLabel.Text = "Test your vowel pronunciation with our Formant target!";
            this.TargetTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TargetTipLabel.Visible = false;
            // 
            // formantButton
            // 
            this.formantButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formantButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.formantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formantButton.ForeColor = System.Drawing.Color.White;
            this.formantButton.Location = new System.Drawing.Point(274, 7);
            this.formantButton.Name = "formantButton";
            this.formantButton.Size = new System.Drawing.Size(70, 23);
            this.formantButton.TabIndex = 3;
            this.formantButton.Text = "Test";
            this.formantButton.UseVisualStyleBackColor = false;
            this.formantButton.Click += new System.EventHandler(this.formantButton_Click);
            this.formantButton.MouseEnter += new System.EventHandler(this.formantButton_MouseEnter);
            this.formantButton.MouseLeave += new System.EventHandler(this.formantButton_MouseLeave);
            // 
            // targetButton
            // 
            this.targetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.targetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.targetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetButton.ForeColor = System.Drawing.Color.White;
            this.targetButton.Location = new System.Drawing.Point(194, 7);
            this.targetButton.Name = "targetButton";
            this.targetButton.Size = new System.Drawing.Size(70, 23);
            this.targetButton.TabIndex = 2;
            this.targetButton.Text = "Target";
            this.targetButton.UseVisualStyleBackColor = true;
            this.targetButton.Click += new System.EventHandler(this.testButton_Click);
            this.targetButton.MouseEnter += new System.EventHandler(this.targetButton_MouseEnter);
            this.targetButton.MouseLeave += new System.EventHandler(this.targetButton_MouseLeave);
            // 
            // learnPanel
            // 
            this.learnPanel.Controls.Add(this.LearnTipLabel);
            this.learnPanel.Controls.Add(this.learnButton);
            this.learnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.learnPanel.Location = new System.Drawing.Point(3, 3);
            this.learnPanel.Name = "learnPanel";
            this.learnPanel.Size = new System.Drawing.Size(538, 48);
            this.learnPanel.TabIndex = 4;
            // 
            // LearnTipLabel
            // 
            this.LearnTipLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LearnTipLabel.Location = new System.Drawing.Point(-3, 28);
            this.LearnTipLabel.Name = "LearnTipLabel";
            this.LearnTipLabel.Size = new System.Drawing.Size(541, 12);
            this.LearnTipLabel.TabIndex = 4;
            this.LearnTipLabel.Text = "Watch videos or vocal tract images of Maori sounds!";
            this.LearnTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LearnTipLabel.Visible = false;
            // 
            // learnButton
            // 
            this.learnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.learnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.learnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learnButton.ForeColor = System.Drawing.Color.White;
            this.learnButton.Location = new System.Drawing.Point(194, 2);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(150, 23);
            this.learnButton.TabIndex = 0;
            this.learnButton.Text = "Learn";
            this.learnButton.UseVisualStyleBackColor = true;
            this.learnButton.Click += new System.EventHandler(this.learnButton_Click);
            this.learnButton.MouseEnter += new System.EventHandler(this.learnButton_MouseEnter);
            this.learnButton.MouseLeave += new System.EventHandler(this.learnButton_MouseLeave);
            // 
            // ReportPanel
            // 
            this.ReportPanel.Controls.Add(this.ScoreTipLabel);
            this.ReportPanel.Controls.Add(this.reportButton);
            this.ReportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPanel.Location = new System.Drawing.Point(3, 111);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(538, 49);
            this.ReportPanel.TabIndex = 5;
            // 
            // ScoreTipLabel
            // 
            this.ScoreTipLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScoreTipLabel.Location = new System.Drawing.Point(0, 31);
            this.ScoreTipLabel.Name = "ScoreTipLabel";
            this.ScoreTipLabel.Size = new System.Drawing.Size(538, 16);
            this.ScoreTipLabel.TabIndex = 7;
            this.ScoreTipLabel.Text = "View your best scores!";
            this.ScoreTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ScoreTipLabel.Visible = false;
            // 
            // reportButton
            // 
            this.reportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.ForeColor = System.Drawing.Color.White;
            this.reportButton.Location = new System.Drawing.Point(194, 7);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(150, 23);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "Score Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            this.reportButton.MouseEnter += new System.EventHandler(this.reportButton_MouseEnter);
            this.reportButton.MouseLeave += new System.EventHandler(this.reportButton_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MPAiSoundMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 361);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MPAiSoundMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPAi Sounds";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MPAiSoundMainMenu_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.testPanel.ResumeLayout(false);
            this.learnPanel.ResumeLayout(false);
            this.ReportPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox headerBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MPAiButton learnButton;
        private MPAiButton reportButton;
        private MenuStrip menuStrip1;
        private System.Windows.Forms.Panel testPanel;
        private MPAiButton formantButton;
        private MPAiButton targetButton;
        private System.Windows.Forms.Label TestTipLabel;
        private System.Windows.Forms.Label TargetTipLabel;
        private System.Windows.Forms.Panel learnPanel;
        private System.Windows.Forms.Label LearnTipLabel;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.Label ScoreTipLabel;
    }
}
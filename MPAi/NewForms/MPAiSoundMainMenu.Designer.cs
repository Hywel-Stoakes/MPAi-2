namespace MPAi.NewForms
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.headerBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new MPAi.NewForms.MenuStrip(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.learnButton = new MPAi.NewForms.MPAiButton(this.components);
            this.testButton = new MPAi.NewForms.MPAiButton(this.components);
            this.reportButton = new MPAi.NewForms.MPAiButton(this.components);
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
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.SplitterDistance = 95;
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
            this.headerBox.Size = new System.Drawing.Size(544, 70);
            this.headerBox.TabIndex = 1;
            this.headerBox.TabStop = false;
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
            this.splitContainer2.Size = new System.Drawing.Size(544, 262);
            this.splitContainer2.SplitterDistance = 90;
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
            this.greetingLabel.Size = new System.Drawing.Size(544, 90);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Kia Ora, User!";
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.learnButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.testButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.reportButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 168);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // learnButton
            // 
            this.learnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.learnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.learnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learnButton.ForeColor = System.Drawing.Color.White;
            this.learnButton.Location = new System.Drawing.Point(197, 16);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(150, 23);
            this.learnButton.TabIndex = 0;
            this.learnButton.Text = "Learn";
            this.learnButton.UseVisualStyleBackColor = true;
            this.learnButton.Click += new System.EventHandler(this.learnButton_Click);
            // 
            // testButton
            // 
            this.testButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton.ForeColor = System.Drawing.Color.White;
            this.testButton.Location = new System.Drawing.Point(197, 72);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(150, 23);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.ForeColor = System.Drawing.Color.White;
            this.reportButton.Location = new System.Drawing.Point(197, 128);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(150, 23);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "Score Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // MPAiSoundMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 361);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MPAiSoundMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPAiSoundMainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MPAiSoundMainMenu_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip mpAiSoundMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox headerBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MPAiButton learnButton;
        private MPAiButton testButton;
        private MPAiButton reportButton;
        private MenuStrip menuStrip1;
    }
}
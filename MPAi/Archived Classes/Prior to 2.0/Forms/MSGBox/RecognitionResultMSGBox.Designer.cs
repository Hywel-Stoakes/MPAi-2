namespace MPAi.Forms.MSGBox
{
    partial class RecognitionResultMSGBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecognitionResultMSGBox));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.guessLabel = new System.Windows.Forms.Label();
            this.recognitionResultLabel = new System.Windows.Forms.Label();
            this.elseLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.elseTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.guessLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.recognitionResultLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.elseLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.elseTextBox, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(131, 259);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // guessLabel
            // 
            this.guessLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guessLabel.Location = new System.Drawing.Point(143, 0);
            this.guessLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.guessLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.guessLabel.Name = "guessLabel";
            this.guessLabel.Size = new System.Drawing.Size(271, 17);
            this.guessLabel.TabIndex = 19;
            this.guessLabel.Text = "Are you saying:";
            this.guessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recognitionResultLabel
            // 
            this.recognitionResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recognitionResultLabel.Location = new System.Drawing.Point(143, 26);
            this.recognitionResultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.recognitionResultLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.recognitionResultLabel.Name = "recognitionResultLabel";
            this.recognitionResultLabel.Size = new System.Drawing.Size(271, 17);
            this.recognitionResultLabel.TabIndex = 0;
            this.recognitionResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // elseLabel
            // 
            this.elseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elseLabel.Location = new System.Drawing.Point(143, 52);
            this.elseLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.elseLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.elseLabel.Name = "elseLabel";
            this.elseLabel.Size = new System.Drawing.Size(271, 17);
            this.elseLabel.TabIndex = 21;
            this.elseLabel.Text = "Or something else:";
            this.elseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextBox.Location = new System.Drawing.Point(143, 107);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionTextBox.Size = new System.Drawing.Size(271, 126);
            this.descriptionTextBox.TabIndex = 23;
            this.descriptionTextBox.TabStop = false;
            this.descriptionTextBox.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(339, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // elseTextBox
            // 
            this.elseTextBox.Location = new System.Drawing.Point(140, 81);
            this.elseTextBox.Name = "elseTextBox";
            this.elseTextBox.Size = new System.Drawing.Size(274, 20);
            this.elseTextBox.TabIndex = 25;
            this.elseTextBox.Leave += new System.EventHandler(this.ElseTextBox_Leave);
            // 
            // RecognitionResultMSGBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecognitionResultMSGBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recognition Result";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label guessLabel;
        private System.Windows.Forms.Label recognitionResultLabel;
        private System.Windows.Forms.Label elseLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox elseTextBox;
    }
}

namespace MPAi
{
    partial class AdminConsole
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
            this.userDataView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataReadOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.userDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // userDataView
            // 
            this.userDataView.AllowUserToOrderColumns = true;
            this.userDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataView.Location = new System.Drawing.Point(12, 27);
            this.userDataView.Name = "userDataView";
            this.userDataView.ReadOnly = true;
            this.userDataView.Size = new System.Drawing.Size(360, 197);
            this.userDataView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "View and edit all the users:";
            // 
            // dataReadOnly
            // 
            this.dataReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataReadOnly.AutoSize = true;
            this.dataReadOnly.Checked = true;
            this.dataReadOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dataReadOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataReadOnly.Location = new System.Drawing.Point(283, 229);
            this.dataReadOnly.Name = "dataReadOnly";
            this.dataReadOnly.Size = new System.Drawing.Size(89, 20);
            this.dataReadOnly.TabIndex = 2;
            this.dataReadOnly.Text = "Read Only";
            this.dataReadOnly.UseVisualStyleBackColor = true;
            // 
            // AdminConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.dataReadOnly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userDataView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "AdminConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminConsole_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.userDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView userDataView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox dataReadOnly;
    }
}
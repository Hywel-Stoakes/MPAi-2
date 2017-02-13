using MPAi.Components;
using MPAi.Modules;

namespace MPAi.Forms.Popups
{
    partial class AdministratorConsole
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

        private System.Windows.Forms.TableLayoutPanel generateUserTable()
        {
            userButtonMap = new System.Collections.Generic.Dictionary<MPAiButton, MPAiUser>();

            System.Windows.Forms.TableLayoutPanel userTable = new System.Windows.Forms.TableLayoutPanel();
            userTable.SuspendLayout();
            userTable.AutoSize = true;
            userTable.ColumnCount = 2;
            userTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            userTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            userTable.Dock = System.Windows.Forms.DockStyle.Top;
            userTable.Location = new System.Drawing.Point(0, 0);

            if(UserManagement.GetAllUsers() == null || UserManagement.GetAllUsers().Count < 1)
            {
                userTable.RowCount = 5;
                userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                userTable.TabIndex = 0;
            }
            else
            {
                System.Collections.Generic.List<MPAiUser> users = UserManagement.GetAllUsers();
                userTable.RowCount = users.Count;
                userTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
                foreach (MPAiUser user in users)
                {
                    userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                }

                for (int i = 0; i < users.Count; i++)
                {
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                    label.Text = users[i].UserID;
                    label.Anchor = System.Windows.Forms.AnchorStyles.None;
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    label.Dock = System.Windows.Forms.DockStyle.Fill;
                    label.BackColor = System.Drawing.Color.Transparent;
                    userTable.Controls.Add(label, 0, i);

                    MPAiButton button = new MPAiButton();
                    button.Text = "Reset Password";
                    button.Size = new System.Drawing.Size(100, 23);
                    button.Anchor = System.Windows.Forms.AnchorStyles.None;
                    button.Click += resetButtonClick;
                    userTable.Controls.Add(button, 1, i);

                    userButtonMap.Add(button, users[i]);
                }
            }

            userTable.ResumeLayout();

            return userTable;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = generateUserTable();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mpAiButton1 = new MPAiButton(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 191);
            this.panel1.TabIndex = 0;
            //// 
            //// tableLayoutPanel1
            //// 
            //this.tableLayoutPanel1.AutoSize = true;
            //this.tableLayoutPanel1.ColumnCount = 2;
            //this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            //this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            //this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            //this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            //this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            //this.tableLayoutPanel1.RowCount = 5;
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            //this.tableLayoutPanel1.Size = new System.Drawing.Size(223, 200);
            //this.tableLayoutPanel1.TabIndex = 0;
            //this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            //// 
            //// label1
            //// 
            //this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            //this.label1.AutoSize = true;
            //this.label1.Location = new System.Drawing.Point(38, 13);
            //this.label1.Name = "label1";
            //this.label1.Size = new System.Drawing.Size(35, 13);
            //this.label1.TabIndex = 0;
            //this.label1.Text = "label1";
            //this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// button1
            //// 
            //this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            //this.button1.Location = new System.Drawing.Point(129, 8);
            //this.button1.Name = "button1";
            //this.button1.Size = new System.Drawing.Size(75, 23);
            //this.button1.TabIndex = 1;
            //this.button1.Text = "button1";
            //this.button1.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mpAiButton1);
            this.splitContainer1.Size = new System.Drawing.Size(284, 262);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 1;
            // 
            // mpAiButton1
            // 
            this.mpAiButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.mpAiButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mpAiButton1.ForeColor = System.Drawing.Color.White;
            this.mpAiButton1.Location = new System.Drawing.Point(197, 11);
            this.mpAiButton1.Name = "mpAiButton1";
            this.mpAiButton1.Size = new System.Drawing.Size(75, 23);
            this.mpAiButton1.TabIndex = 0;
            this.mpAiButton1.Text = "Close";
            this.mpAiButton1.UseVisualStyleBackColor = false;
            // 
            // AdministratorConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministratorConsole";
            this.Text = "Administrator Console";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel userTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MPAiButton mpAiButton1;
    }
}
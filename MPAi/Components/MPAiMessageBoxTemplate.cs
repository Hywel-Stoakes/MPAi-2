using System;
using System.Windows.Forms;

namespace MPAi.Components
{
    public partial class MPAiMessageBoxTemplate : Form
    {
        private DialogResult result = DialogResult.None;

        public MPAiMessageBoxTemplate()
        {
            InitializeComponent();
        }

        public void SetPanel1Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 0, 0);
            button.Click += buttonClick;
        }

        public void SetPanel2Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 1, 0);
            button.Click += buttonClick;
        }

        public void SetPanel3Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 2, 0);
            button.Click += buttonClick;
            button.TabIndex = 0;
            button.TabStop = true;
        }

        public void SetMessageText(string text)
        {
            messageTextBox.Text = text.Replace("\n", "\r\n");
        }

        public void SetCaptionText(string caption)
        {
            this.captionLabel.Text = caption;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            result = ((MPAiMessageBoxButton)sender).Result;
            this.Close();
        }

        public DialogResult ShowMessageBox()
        {
            this.ShowDialog();
            return result;
        }
    }
}

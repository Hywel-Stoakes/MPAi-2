using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAi.NewForms
{
    public partial class MPAiMessageBoxTemplate : Form
    {
        public MPAiMessageBoxTemplate()
        {
            InitializeComponent();
        }

        public void SetPanel1Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 0, 0);
        }

        public void SetPanel2Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 1, 0);
        }

        public void SetPanel3Button(MPAiButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 2, 0);
        }

        public void SetMessageText(string text)
        {
            messageTextBox.Text = text;
        }
    }
}

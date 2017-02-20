using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MPAi.Components
{
    public partial class MPAiButton : Button
    {
        public MPAiButton()
        {
            InitializeComponent();
        }

        private void MPAiButton_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackColor = System.Drawing.Color.FromArgb(0xFF, 0x03, 0xDC, 0x73);
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(0xFF, 0x33, 0xFC, 0xA3);
            }
        }

        public MPAiButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.FromArgb(0xFF, 0x03, 0xDC, 0x73);
            this.EnabledChanged += MPAiButton_EnabledChanged;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAi.NewForms
{
    public partial class MPAiButton : System.Windows.Forms.Button
    {
        public MPAiButton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.Red;
            this.EnabledChanged += MPAiButton_EnabledChanged;
            InitializeComponent();
        }

        private void MPAiButton_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled)
            {
                this.ForeColor = System.Drawing.Color.White;
                this.BackColor = System.Drawing.Color.Red;
            } else
            {
                this.ForeColor = System.Drawing.Color.White;
                this.BackColor = System.Drawing.Color.FromArgb(0xFF, 0xFF, 0x88, 0x88);
            }
        }

        public MPAiButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

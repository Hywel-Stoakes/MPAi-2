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

        public MPAiButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

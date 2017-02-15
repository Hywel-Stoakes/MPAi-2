using MPAi.Components;
using MPAi.Modules;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPAi.Forms.Popups
{
    public partial class AdministratorConsole : Form
    {

        private System.Collections.Generic.Dictionary<MPAiButton, MPAiUser> userButtonMap;

        public AdministratorConsole()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Row) % 2 == 1)
            {
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.CellBounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
            }
        }

        private void resetButtonClick(object sender, EventArgs e)
        {
            MPAiUser user = userButtonMap[(MPAiButton)sender];
            ConfirmRandomisedPassword dialog = new ConfirmRandomisedPassword();
            user.UserPswd = dialog.ConfirmPassword(user.GetCorrectlyCapitalisedName(), user.UserPswd);
            UserManagement.WriteSettings();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

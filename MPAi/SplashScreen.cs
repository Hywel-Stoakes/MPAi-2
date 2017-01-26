using System.Windows.Forms;

namespace MPAid
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            Width = BackgroundImage.Width;
            Height = BackgroundImage.Height;
            Icon = Properties.Resources.MPAid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAi.Cores;
using MPAi.Cores.Scoreboard;
using System.IO;
using System.Diagnostics;

namespace MPAi.NewForms
{
    public partial class AnalysisScreen : Form
    {

        public AnalysisScreen(float pronunciationCorrectness, string description)
        {
            InitializeComponent();

            correctnessLabel.Text = string.Format(@"Pronunciation is {0:0.0%} Correct", pronunciationCorrectness);
            descriptionBox.Text = description;
        }

        private void scoreReportButton_Click(object sender, EventArgs e)
        {
            ReportLauncher.GenerateMPAiSpeakScoreHTML(UserManagement.CurrentUser.SpeakScoreboard);

            if (File.Exists(ReportLauncher.MPAiSpeakScoreReportHTMLAddress))
            {
                ReportLauncher.ShowMPAiSpeakScoreReport();
            }
            else
            {
                scoreReportButton.Enabled = false;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
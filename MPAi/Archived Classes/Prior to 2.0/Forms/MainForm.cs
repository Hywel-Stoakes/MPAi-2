using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using MPAi.Forms.Config;
using MPAi.Cores;
using MPAi.Models;
using System.Data.Entity;
using MPAi.UserControls;
using System.Net.Mail;
using MPAi.Forms.MSGBox;

namespace MPAi
{
    /// <summary>
    /// The class representing the main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        public static MainForm self;

        private List<string> recordedWavFiles = new List<string>();
        private BindingList<string> listREC = new BindingList<string>();

        private LoginWindow loginForm;

        private SystemConfig systemConfigForm;

        private RecordingUploadConfig recordingUploadForm;

        private RecordingRenameConfig recordingRenameForm;

        public MPAiModel DBModel;

        /// <summary>
        /// Wrapper property for the operationPanel object, allowing reading from outside the class.
        /// </summary>
        public OperationPanel OperationPanel
        {
            get { return operationPanel; }
        }

        /// <summary>
        /// Wrapper property for the recordingPanel object, allowing reading from outside the class.
        /// </summary>
        public RecordingPanel RecordingList
        {
            get { return recordingPanel; }
        }

        /// <summary>
        /// Constructor for the main form, which shows the splash screen whil all components are set up.
        /// </summary>
        /// <param name="users">The current list of all users, being used by the login screen.</param>
        public MainForm()
        {
            MainForm.self = this;

            SplashScreen splash = new SplashScreen();
            splash.Show();

            InitializeDB();
            InitializeConfig();

            InitializeComponent();
            InitializeUI();

            splash.Close();
        }

        /// <summary>
        /// Sets the login window that called this main form.
        /// This is important because when the first window the program opens gets closed, the program terminates.
        /// We need to keep track of this main window and close it when this form is closed.
        /// </summary>
        /// <param name="loginWin">The object representing the login window.</param>
        public void SetHomeWindow(LoginWindow loginWin)
        {
            loginForm = loginWin;
        }

        /// <summary>
        /// Sets values and calls methods required to show the UI.
        /// </summary>
        private void InitializeUI()
        {
            // Updates the title text to show the current system version number.
            Text += " " + GetVersionString();

            InitializeUserProfile();

            FillLists();
        }

        /// <summary>
        /// This method sets the value of the user menu bar item.
        /// If the user is an administrator, the administrator console is made visible under the user tab.
        /// If the user is not an administrator, the option to change their own password is visible.
        /// </summary>
        private void InitializeUserProfile()
        {
            usersToolStripMenuItem.Text = UserManagement.CurrentUser.getName();

            // The administrator account is not advised to change its password.
            changePasswordToolStripMenuItem.Visible = !UserManagement.currentUserIsAdmin();
            administratorConsoleToolStripMenuItem.Visible = UserManagement.currentUserIsAdmin();
        }

        /// <summary>
        /// Sets up the system configuration forms, in the config menu.
        /// </summary>
        private void InitializeConfig()
        {
            this.systemConfigForm = new SystemConfig();
            this.systemConfigForm.InitializeContent();
            this.recordingUploadForm = new RecordingUploadConfig();
            this.recordingRenameForm = new RecordingRenameConfig();
        }

        /// <summary>
        /// Connects this form to the maintained database, and loads all relevant files.
        /// </summary>
        private void InitializeDB()
        {
            try
            {
                this.DBModel = new MPAiModel();
                this.DBModel.Database.Initialize(false);
                this.DBModel.Recording.Load();
                this.DBModel.Speaker.Load();
                this.DBModel.Category.Load();
                this.DBModel.Word.Load();
                this.DBModel.SingleFile.Load();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Database linking error!");
            }
        }

        /// <summary>
        /// Binds the recording panel to the list of recordings in the database, and fills it based on that information.
        /// </summary>
        private void FillLists()
        {
            this.recordingPanel.DataBinding();
        }

        /// <summary>
        /// Converts the stored application version into a string that can be more easily used by the program.
        /// </summary>
        /// <returns>A line of text detailing and explaining the version number, as a string.</returns>
        private string GetVersionString()
        {
            return ("[Version " + Application.ProductVersion + "]");
        }

        /// <summary>
        /// Called when the form itself is closed.
        /// If any formant plots are still open, closes them, and calls a method to determine what other forms should be closed.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlotController.ClosePlot();

            // This method will decide if the application is exiting.
            CloseOtherForms();
        }

        bool doCloseLogin = true;

        /// <summary>
        /// Checks if the application should be exited when the main form is closed, and closes the application if so.
        /// By default, always does close the application.
        /// </summary>
        private void CloseOtherForms()
        {
            if (doCloseLogin)
            {
                loginForm.Close();
                doCloseLogin = true;
            }
        }

        /// <summary>
        /// Double clicking the banner at the top of the screen brings up the About window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void headerBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                aboutToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// Handles sign out functionality, by closing the main form without terminating the program.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doCloseLogin = false;
            // Optional: Clear the username and password boxes when the login form is shown again, by uncommenting the line below.
            //loginForm.ResetUserInput();
            loginForm.Show();
            Close();
        }

        /// <summary>
        /// When the Change Password menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordWindow changePswdForm = new ChangePasswordWindow();
            changePswdForm.ShowDialog(this);
        }

        /// <summary>
        /// When the Administrator Console menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void administratorConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminConsole adminForm = new AdminConsole();
            adminForm.ShowDialog(this);
        }

        /// <summary>
        /// When the About menu item is clicked, populates and shows the appropriate window.
        /// This window is not it's own class, rather, a default message box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                this, "Maori Pronunciation Aid " + 
                GetVersionString() + "\n\n" + 
                "Dr. Catherine Watson\n" +
                "The University of Auckland",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// When the Submit Feedback menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void submitFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedbackScreen fbMSGBox = new FeedbackScreen();
            fbMSGBox.ShowDialog(this);
        }

        /// <summary>
        /// When the System Tools menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.systemConfigForm.ShowDialog(this);
        }

        /// <summary>
        /// When the Upload Recording menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordingUploadForm.ShowDialog(this);
        }

        /// <summary>
        /// When the Rename Recording menu item is clicked, shows the appropriate window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordingRenameForm.ShowDialog(this);
        }

        /// <summary>
        /// When the Help menu item is clicked, opens a browser linking to the instruction page of the Github Wiki
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string target = @"https://github.com/YsqEvilmax/MPAi/wiki/Instruction";
                Process.Start(target);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Invalid URL Address!");
            }
        }
    }
}

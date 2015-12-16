﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using System.Reflection;
using System.IO;
using MPAid.Models;

namespace MPAid.UserControls
{
    public partial class VlcPlayer : UserControl
    {
        public VlcControl VlcControl
        {
            get { return vlcControl; }
        }
        public VlcPlayer()
        {
            InitializeComponent();
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Word word = MainForm.self.RecordingList.WordListBox.SelectedItem as Word;
            vlcControl.Play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            vlcControl.Pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            vlcControl.Stop();
        }
    }
}

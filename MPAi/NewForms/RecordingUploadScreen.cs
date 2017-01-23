﻿using MPAi.Cores;
using MPAi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAi.NewForms
{
    public partial class RecordingUploadScreen : Form
    {
        // Strings kept in one place to be easier to change.
        private string selectAllDatabaseText = "Select All Database Files";
        private string deselectAllDatabaseText = "Deselect All Database Files";
        private string selectAllLocalText = "Select All Local Files";
        private string deselectAllLocalText = "Deselect All Local Files";

        private string updateFailedText = "Failed to update!";
        private string deleteFailedText = "Failed to update!";
        private string noValidFilesText = "No valid files found! MPAi recordings must be .wav or .mp4 files.";

        private string renamewarningText = "All MPAi files must follow a particular naming convention.\nFor the files that don't follow this convention, MPAi will bring up a window for you to enter thier details, and rename the automatically.\nThis may make a long time for large numbers of files.";
        private string warningText = "Warning!";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecordingUploadScreen()
        {
            InitializeComponent();

            populateListBox();
        }

        /// <summary>
        /// Fills the database list box with all recordings in the database. Also used to refresh the list box.
        /// Can't be called in a using block
        /// </summary>
        private void populateListBox()
        {
            using (MPAiModel DBModel = new MPAiModel())
            {
                // Add all local database files to the list.
                List<SingleFile> view = DBModel.SingleFile.ToList();    
                onDBListBox.DataSource = view;
                onDBListBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// Launches the default system folder picker so the user can select a folder to upload from.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo selectedDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    currentFolderTextBox.Text = selectedDirectory.FullName;
                    ListBox localListBox = mediaLocalListBox;
                    // Replace the values in the list box with the files in the folder that are of a valid format.
                    FileInfo[] view = selectedDirectory.GetFiles().Where(x => x.Extension.Equals(".wav") || x.Extension.Equals(".mp4")).ToArray();
                    localListBox.DataSource = new BindingSource() { DataSource = view}; 
                    if (view.Count() < 1)
                    {
                        MessageBox.Show(noValidFilesText);
                    }
                    localListBox.DisplayMember = "Name";     // Display the names.
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// Adds the selected items in the local list box to the database.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void toDBButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MPAiModel DBModel = new MPAiModel())
                {
                    DialogResult renameAction = MessageBox.Show(renamewarningText,
                        warningText, MessageBoxButtons.OKCancel);
                    // If the user selected cancel, don't take any action.
                    if (renameAction.Equals(DialogResult.Cancel))
                    {
                        return;
                    }
                    foreach (FileInfo item in mediaLocalListBox.SelectedItems)  // For each selected item...
                    {
                        FileInfo workingFile = item;

                        // Need to rename file.
                        // If the user wanted to rename them themselves, take the same action as in SpeechRecognitionTest - automatically bring up rename.

                        if (!NameParser.IsFileNameCorrect(workingFile.Name))
                        {
                            // Back up the file to a temporary folder.
                            File.Copy(workingFile.FullName, Path.Combine(AppDataPath.Temp, "Rename_Backup"));

                            //Open the rename dialog
                            RenameFileDialog renameDialog = new RenameFileDialog(workingFile.FullName, true);
                            if (renameDialog.ShowDialog(this).Equals(DialogResult.OK))
                            {
                                // The old file has been changed to this.
                                FileInfo renamedFile = renameDialog.RenamedFile;
                                // Restore the old file, with old name intact, from the backup.
                                File.Move(Path.Combine(AppDataPath.Temp, "Rename_Backup"), workingFile.FullName);
                                // Continue the process with the new file name.
                                workingFile = renamedFile;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        // If the file follows convention (i.e. parts.length == 4), do nothing.

                        NameParser parser = new NameParser();
                        parser.FullName = workingFile.FullName;          // Put the name into the parser
                        // Set the parser address to the audio or video folder as appropriate. 
                        if (parser.MediaFormat == "audio")
                        {
                            parser.Address = Properties.Settings.Default.AudioFolder;
                        }
                        else if (parser.MediaFormat == "video")
                        {
                            parser.Address = Properties.Settings.Default.VideoFolder;
                        }
                        // Get the file and add it to the database context.
                        DBModel.AddOrUpdateRecordingFile(parser.SingleFile);
                        // Copy the existing local file into the audio/video folder if it wasn't already there.
                        string existingFile = workingFile.FullName;
                        string newFile = Path.Combine(parser.Address, workingFile.Name);
                        if (!existingFile.Equals(newFile))
                        {
                            File.Copy(existingFile, newFile, true);
                        }
                        DBModel.SaveChanges();
                    }
                }
                populateListBox();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.StackTrace);
            }
            finally
            {
                File.Delete(Path.Combine(AppDataPath.Temp, "Rename_Backup"));
            }
        }

        /// <summary>
        /// Removes the selected items in the database list box from the database and the recordings folder.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void toLocalButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MPAiModel DBModel = new MPAiModel())
                {
                    // Creating a copy of the list box selected items to iterate through
                    List<SingleFile> selectedItemsCopy = new List<SingleFile>();
                    List<SingleFile> allItems = DBModel.SingleFile.ToList();  // Avoid n+1 selects problem in the next for loop.
                    foreach (SingleFile sf in onDBListBox.SelectedItems)
                    {
                        SingleFile toAdd = allItems.Find(x => x.SingleFileId == sf.SingleFileId);
                        selectedItemsCopy.Add(toAdd);
                    }

                    // For each item in the database list box...
                    foreach (SingleFile sf in selectedItemsCopy)
                    {
                        Recording rd = null;
                        NameParser paser = new NameParser();
                        paser.FullName = sf.Name;       // Add the file to the Parser
                        // Use the parser to create the model objects.
                        if (paser.MediaFormat == "audio")
                        {
                            rd = sf.Audio;
                        }
                        else if (paser.MediaFormat == "video")
                        {
                            rd = sf.Video;
                        }
                        Speaker spk = rd.Speaker;
                        Word word = rd.Word;
                        Category cty = word.Category;
                        string existingFile = Path.Combine(sf.Address, sf.Name);
                        File.Delete(existingFile);      // Delete it,
                        DBModel.SingleFile.Remove(sf);    // And remove it from the database.

                        // If the deleted file was: 
                        if (rd.Audios.Count == 0 && rd.Video == null)   // The last file attached to a recording, then delete the recording.
                        {
                            DBModel.Recording.Remove(rd);    
                        }
                        if (spk.Recordings.Count == 0)                  // The last recording attached to a speaker, then delete the speaker.
                        {
                            DBModel.Speaker.Remove(spk);
                        }
                        if (word.Recordings.Count == 0)                 // The last recording attached to a word, then delete the word.
                        {
                            DBModel.Word.Remove(word);
                        }                  
                        if (cty.Words.Count == 0)                       // The last word attached to a category, then delete the category.
                        {
                            DBModel.Category.Remove(cty);
                        }
                        DBModel.SaveChanges();                   
                    }
                }
                populateListBox();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, deleteFailedText);
            }
        }

        /// <summary>
        /// Toggle selection of all items in the local list box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void allLocalItemsButton_Click(object sender, EventArgs e)
        {
            if (allLocalItemsButton.Text.Equals(selectAllLocalText))
            {
                for (int i = 0; i < mediaLocalListBox.Items.Count; i++)
                {
                    mediaLocalListBox.SetSelected(i, true);
                }
                allLocalItemsButton.Text = deselectAllLocalText;
                return;
            }

            if (allLocalItemsButton.Text.Equals(deselectAllLocalText))
            {
                for (int i = 0; i < mediaLocalListBox.Items.Count; i++)
                {
                    mediaLocalListBox.SetSelected(i, false);
                }
                allLocalItemsButton.Text = selectAllLocalText;
                return;
            }
        }

        /// <summary>
        /// Toggle selection of all items in the database list box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void allDatabaseItemsButton_Click(object sender, EventArgs e)
        {
            if (allDatabaseItemsButton.Text.Equals(selectAllDatabaseText))
            {
                for (int i = 0; i < onDBListBox.Items.Count; i++)
                {
                    onDBListBox.SetSelected(i, true);
                }
                allDatabaseItemsButton.Text = deselectAllDatabaseText;
                return;
            }

            if (allDatabaseItemsButton.Text.Equals(deselectAllDatabaseText))
            {
                for (int i = 0; i < onDBListBox.Items.Count; i++)
                {
                    onDBListBox.SetSelected(i, false);
                }
                allDatabaseItemsButton.Text = selectAllDatabaseText;
                return;
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using MPAi.Cores;
using MPAi.Models;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace MPAi.NewForms
{
    public partial class VideoPlayer : Form, MainFormInterface
    {
        // Strings kept in fields to make text easier to change.
        private string optionsLess = "Less...";
        private string optionsMore = "More...";
        private string recordText = "Record";
        private string stopText = "Stop";

        private string noFileText = "No current file";
        private string myRecordingText = "My new recording";
        private string selectFolderString = "Select Vlc libraries folder.";

        private string invalidStateString = "Invalid State!";
        private string noVideoString = "No video recording was found for that sound.";
        private string invalidRecordingString = "Invalid recording!";
        private string vowelNotFoundText = "That sound is not valid. Try another, or select from the list.";
        private string formatErrorText = "A problem was encountered during recording {0}";
        private string warningText = "Warning";
        private string noAudioDeviceText = "No audio device plugged in.";
        private string wrongFileFormatError = "The audio player can only accept wave files (.wav). Please try another, or record one using the record button.";

        private string[] spinnerText = { "Repeat Forever", "Repeat 10 Times", "Repeat 9 Times", "Repeat 8 Times", "Repeat 7 Times", "Repeat 6 Times", "Repeat 5 Times", "Repeat 4 Times", "Repeat 3 Times", "Repeat Twice", "Repeat Once", "Don't Repeat" };

        private string audioFilePath = Path.Combine(AppDataPath.Temp, "VideoPlayerRecordedAudio.wav");
        private WaveFileWriter writer;
        private WasapiCapture waveIn;
        private NAudioPlayer audioPlayer = new NAudioPlayer();

        // Used to keep track of the currently playing file.
        private string filePath;

        // Delegate required for VLC Player.
        delegate void delegatePlayer(Uri file, string[] pars);
        delegate void delegateStopper();

        // The list of recordings to play.
        private List<Word> wordsList;
        // The index of the current recording.
        private int currentRecordingIndex = 0;

        // Variables used to determine the number of times to repeat a video.
        private int repeatTimes = 0;
        private int repeatsRemaining = 0;

        /// <summary>
        /// Holds the height of the bottom panel between clicks of the options button.
        /// </summary>
        private readonly int bottomHeight;

        private bool appClosing = true;

        /// <summary>
        /// Wrapper propety for repeatTimes, also prevents too many repeats by updating repeatsRemaining.
        /// </summary>
        public int RepeatTimes
        {
            get
            {
                return repeatTimes;
            }

            set
            {
                repeatTimes = value;
                repeatsRemaining = Math.Min(repeatsRemaining, value);
            }
        }

        public VideoPlayer()
        {
            InitializeComponent();
            populateBoxes();
            setUpSpinner();
            LoadWasapiDevices();

            bottomHeight = VideoPlayerPanel.Height - VideoPlayerPanel.SplitterDistance;
            toggleOptions();    // For development, the bottom panel is visible, but the user won't need the bottom panel most of the time.
        }

        /// <summary>
        /// Set up repeat spinner programatically. Visual Studio tends to delete values when set up in the designer, and some values can't be set in form properties.
        /// </summary>
        private void setUpSpinner()
        {
            repeatSpinner.SelectedIndex = repeatSpinner.Items.Count - 1;
            repeatSpinner.Items.AddRange(spinnerText);
            repeatSpinner.SelectedIndex = repeatSpinner.Items.Count - 1;
            repeatSpinner.SelectedItemChanged += repeatSpinner_SelectedItemChanged;
        }

        /// <summary>
        /// Gets the words from the database.
        /// </summary>
        private void populateBoxes()
        {
            try
            {
                // Create new database context.
                using (MPAiModel DBModel = new MPAiModel())
                {
                    DBModel.Database.Initialize(false); // Added for safety; if the database has not been initialised, initialise it.

                    MPAiUser current = UserManagement.CurrentUser;

                    List<Word> view = DBModel.Word.Where(x => (
                       x.Category.Name.Equals("Vowel")
                       && x.Recordings.Any(y => y.Speaker.SpeakerId == current.Speaker.SpeakerId) 
                       )).ToList();

                    // Can't sort a control's Items field, so we sort a list and add values.
                    view.Sort(new VowelComparer());

                    // Lists of Word objects, but only their name needs to be displayed to the user.
                    soundListAllListBox.DisplayMember = "Name";
                    VowelComboBox.DisplayMember = "Name";
                    soundListCurrentListBox.DisplayMember = "Name";

                    // Set the values in all the lists used by the program.
                    soundListAllListBox.DataSource = new BindingSource() { DataSource = view };
                    foreach (Word wd in view)
                    {
                        soundListCurrentListBox.Items.Add(wd);
                        VowelComboBox.Items.Add(wd);
                    }
                    wordsList = view;

                    selectItemInComboBox();                 
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// Prevents two lists appearing onscreen at once by closing the main list when the suggestion list is visible.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void VowelComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            VowelComboBox.DroppedDown = false;
        }

        /// <summary>
        /// Ensures only valid words are entered, by comparing the text to the names of all words when focus is lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VowelComboBox_Leave(object sender, EventArgs e)
        {
            //Prevents the user getting stuck when there are no words.
            if (VowelComboBox.Items.Count < 1)
            {
                return;
            }
            foreach (Word w in VowelComboBox.Items)
            {
                if (w.Name.Equals(VowelComboBox.Text))
                {
                    return;
                }
            }
            MessageBox.Show(vowelNotFoundText);
            VowelComboBox.Focus();
        }

        /// <summary>
        /// Changing the index of the combo box will cause a different word to be played by the audio player.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void VowelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentRecordingIndex = VowelComboBox.SelectedIndex;
        }

        /// <summary>
        /// Handles the functionality for the options button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            toggleOptions();
        }

        /// <summary>
        /// Shows/hides the options panel, changes button text, and resizes the form as appropriate.
        /// </summary>
        private void toggleOptions()
        {
            if (VideoPlayerPanel.Panel2Collapsed)
            {
                Height += bottomHeight - 3;
                MinimumSize = new Size(MinimumSize.Width, 625);
                optionsButton.Text = optionsLess;
                VideoPlayerPanel.Panel2Collapsed = !VideoPlayerPanel.Panel2Collapsed;
            }
            else
            {
                VideoPlayerPanel.Panel2Collapsed = !VideoPlayerPanel.Panel2Collapsed;
                MinimumSize = new Size(MinimumSize.Width, 300);
                Height -= bottomHeight - 3;
                optionsButton.Text = optionsMore;
            }
        }

        /// <summary>
        /// Handles the functionality for the back button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            new MPAiSoundMainMenu().Show();
            closeThis();
        }

        /// <summary>
        /// Closes the form, but not the application.
        /// </summary>
        public void closeThis()
        {
            appClosing = false; // Tell the FormClosing event not to end the program.
            Close();
        }

        /// <summary>
        /// When the track bar's value changes, also change the spinner to match.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void repeatTrackBar_ValueChanged(object sender, EventArgs e)
        {
            RepeatTimes = repeatTrackBar.Value;
            repeatSpinner.SelectedIndex = (repeatSpinner.Items.Count - 1) - RepeatTimes;
        }

        /// <summary>
        /// When the spinner changes, also change the track bar to match.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void repeatSpinner_SelectedItemChanged(object sender, EventArgs e)
        {
            RepeatTimes = (repeatSpinner.Items.Count - 1) - repeatSpinner.SelectedIndex;
            repeatTrackBar.Value = RepeatTimes;
        }

        /// <summary>
        /// Gets all the audio input devices attached to the system, converts them to a list, and populates the audio device combo box.
        /// </summary>
        public void LoadWasapiDevices()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            AudioInputDeviceComboBox.DataSource = devices.Count == 0 ? null : devices;
            AudioInputDeviceComboBox.DisplayMember = "FriendlyName";
        }

        /// <summary>
        /// Functionality for the refresh devices button.
        /// Reloads any attached devices into the combo box, and refreshes it's value.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void AudioInputDeviceButton_Click(object sender, EventArgs e)
        {
            LoadWasapiDevices();
        }

        /// <summary>
        /// Calls a dialog box for the user to select a file to overlay.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void addFromFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName).Equals(".wav"))
                {
                    File.Copy(openFileDialog.FileName, audioFilePath, true);
                    recordingProgressBarLabel.Text = openFileDialog.FileName;
                    removeButton.Enabled = true;
                }
                else
                {
                    // If they select a file that is not a wav file, stop them and retry.
                    MessageBox.Show(wrongFileFormatError);
                    addFromFileButton_Click(sender, e);
                }
            }
            // If the user presses cancel, return.
        }
        /// <summary>
        /// Handles functionality of the record/stop button, calling appropriate methods and changing it's text.
        /// As there is no global isRecording field, and such a field would interfere with existing code, the button text is used as the recording status.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void recordButton_Click(object sender, EventArgs e)
        {
            if (recordButton.Text.Equals(recordText))
            {
                record();
            }
            else
            {
                StopRecording();
            }
        }

        /// <summary>
        /// If a file is being recorded, stop recording and tidy up the stream.
        /// </summary>
        private void StopRecording()
        {
            waveIn.DataAvailable -= OnDataAvailable;

            recordButton.Text = recordText;
            if (waveIn != null)
            {
                waveIn.StopRecording();
            }
            FinalizeWaveFile(writer);
        }

        /// <summary>
        /// Tidies up the stream after a wave file has been played or recorded.
        /// </summary>
        /// <param name="s">The stream to dispose of.</param>
        private void FinalizeWaveFile(Stream s)
        {
            if (s != null)
            {
                s.Dispose();
                s = null;
            }
        }

        /// <summary>
        /// Sets up the audio device, and the file to record into, adds listeners to the events, starts recording, and toggles the buttons.
        /// </summary>
        private void record()
        {
            try
            {
                var device = (MMDevice)AudioInputDeviceComboBox.SelectedItem;
                if (!(device == null))
                {

                    recordButton.Text = stopText;
                    recordingProgressBar.Value = 0;

                    device.AudioEndpointVolume.Mute = false;
                    // Use wasapi by default
                    waveIn = new WasapiCapture(device);
                    waveIn.DataAvailable += OnDataAvailable;
                    waveIn.RecordingStopped += OnRecordingStopped;

                    writer = new WaveFileWriter(audioFilePath, waveIn.WaveFormat);
                    waveIn.StartRecording();
                    SetControlStates(true);
                }
                else
                {
                    recordButton.Text = recordText;
                    MessageBox.Show(noAudioDeviceText, warningText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
#if DEBUG
                MessageBox.Show(exp.Message, warningText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        /// <summary>
        /// Event to handle audio buffering and updating of the progress bar.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired) // If it is necessary to invoke this method on a separate thread
            {
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e); // Send this event to the relevant thread.
            }
            else
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded); // Record audio into a buffer
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                recordingProgressBar.Value = secondsRecorded * 10;  // Increase the progress bar
                if (secondsRecorded >= 10)
                {
                    StopRecording(); // If we have recorded more than 10s of audio then stop recording
                }
            }
        }

        /// <summary>
        /// Functionality to tidy up when recording has stopped.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired) // If it is necessary to invoke this on a different thread
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e); // Send this event to the relevant thread
            }
            else
            {
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format(formatErrorText, e.Exception.Message));
                }
                SetControlStates(false);    // Toggle the record and stop buttons
                recordingProgressBarLabel.Text = myRecordingText;
            }
        }

        /// <summary>
        /// Handles the state of the buttons based on whether or not the user is recording.
        /// </summary>
        /// <param name="isRecording">Boolean value representing whether or not the screen is recording.</param>
        private void SetControlStates(bool isRecording)
        {
            recordButton.Text = isRecording ? stopText : recordText;
            recordingProgressBar.Visible = isRecording;
            recordingProgressBarLabel.Visible = !isRecording;
            addFromFileButton.Enabled = !isRecording;
            removeButton.Enabled = !isRecording;
        }

        /// <summary>
        /// Removes the current audio file from storage.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            asyncStop();
            recordingProgressBarLabel.Text = noFileText;
            File.Delete(audioFilePath);
            removeButton.Enabled = false;
        }

        /// <summary>
        /// Fires when the control needs to have it's library directory assigned to it.
        /// Navigates to where the directories should be, and sets them, or asks the user to find the directory if it's not there.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();  // Get the currently running project
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;    // Get the directory of the currently running project
            if (currentDirectory == null)   // If there isn't one, return.
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)  // If the computer is running an x86 architecture, use the x86 folder.
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"VlcLibs\vlcx86\"));
            else        // otherwise use the x64 folder.
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"VlcLibs\vlcx64\"));

            if (!e.VlcLibDirectory.Exists)      // If a folder is missing
            {
                var folderBrowserDialog = new FolderBrowserDialog();       // Raise a browser window and let the user find it.
                folderBrowserDialog.Description = selectFolderString;
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        /// <summary>
        /// Handles the functionality of the play/pause button, which differs based on the state of the player.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void playButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (vlcControl.State)
                {
                    case Vlc.DotNet.Core.Interops.Signatures.MediaStates.NothingSpecial:    // Occurs when control is finished loading. Same functionality as stopped.
                    case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended:             // Occurs when control has finished playing a video. Same funcionaility as stopped.
                    case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Stopped:           // Occurs when the player has been stopped. No video is loaded in.
                        {
                            playVideo();
                        }
                        break;
                    case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing:   // If playing, pause and update the button.
                        {
                            vlcControl.Pause();
                            audioPlayer.Pause();
                            playButton.ImageIndex = 1;
                        }
                        break;
                    case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Paused:    // If paused, play and update the button.
                        {
                            vlcControl.Play();  // asyncPlay is not used here, as it starts playback from the beginning.
                            audioPlayer.Unpause();
                            playButton.ImageIndex = 3;
                        }
                        break;
                    default:
                        MessageBox.Show(invalidStateString);
                        break;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// Plays or pauses the video, depending on the VLC player's current state.
        /// </summary>
        private void playVideo()
        {
            using (MPAiModel DBModel = new MPAiModel())
            {
                Word wd = wordsList[currentRecordingIndex];
                Speaker spk = null;   // Get the speaker from user settings.
                Recording rd = DBModel.Recording.SingleOrDefault(x => x.WordId == wd.WordId
                //&& x.SpeakerId == spk.SpeakerId // Comment this line out to test until we have user settings up and running.
                );    // Get the recording that corresponds to the speaker and word above.

                if (rd != null) // If the recording exists
                {
                    SingleFile sf = rd.Video;
                    if (sf == null)
                    {
                        asyncStop();
                        MessageBox.Show(noVideoString);
                        return;
                    }
                    filePath = Path.Combine(sf.Address, sf.Name);

                    asyncPlay();
                    playButton.ImageIndex = 3;
                }
                else
                {
                    MessageBox.Show(invalidRecordingString);
                }
            }
        }

        /// <summary>
        /// The VLCPlayer is not threadsafe, so it is much easier to invoke it with delegates.
        /// This should be used to play the video; it also handles the audio overlay.
        /// </summary>
        private void asyncPlay()
        {
            // Get a new instance of the delegate
            delegatePlayer VLCDelegate = new delegatePlayer(vlcControl.Play);
            // Call play asynchronously.
            VLCDelegate.BeginInvoke(new Uri(filePath), new string[] { }, null, null);
            if (!recordingProgressBarLabel.Text.Equals(noFileText))
            {
                // Play audio at same time as video
                audioPlayer.Stop();
                audioPlayer.Play(audioFilePath);
            }

        }

        /// <summary>
        /// The VLCPlayer is not threadsafe, so it is much easier to invoke it with delegates.
        /// This should be used to stop the video; it also stops audio overlay playback.
        /// </summary>
        private void asyncStop()
        {
            // Get a new instance of the delegate
            delegateStopper VLCDelegate = new delegateStopper(vlcControl.Stop);
            // Call stop asynchronously.
            VLCDelegate.BeginInvoke(null, null);
            if (!recordingProgressBarLabel.Text.Equals(noFileText))
            {
                // Stop audio when video is stopped.
                audioPlayer.Stop();
            }
        }

        /// <summary>
        /// When the video is stopped, make the pause button into the play button, by swapping the images.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void OnVlcControlStopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            playButton.ImageIndex = 1;
        }

        /// <summary>
        /// When the mouse hovers over the play button, it highlights.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            playButton.ImageIndex = vlcControl.State != Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing ? 0 : 2;
        }

        /// <summary>
        /// When the mouse leaves the play button, stop it from highlighting.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            playButton.ImageIndex = vlcControl.State != Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing ? 1 : 3;
        }

        /// <summary>
        /// When the mouse hovers over the back button, it highlights.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backwardButton_MouseEnter(object sender, EventArgs e)
        {
            backwardButton.ImageIndex = 0;
        }

        /// <summary>
        /// When the mouse leaves the back button, stop it from highlighting.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backwardButton_MouseLeave(object sender, EventArgs e)
        {
            backwardButton.ImageIndex = 1;
        }

        /// <summary>
        /// When the mouse hovers over the forward button, it highlights.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void forwardButton_MouseEnter(object sender, EventArgs e)
        {
            forwardButton.ImageIndex = 0;
        }

        /// <summary>
        /// When the mouse leaves the forward button, stop it from highlighting.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void forwardButton_MouseLeave(object sender, EventArgs e)
        {
            forwardButton.ImageIndex = 1;
        }

        /// <summary>
        /// When the video finishes playing, revert the play button to it's original state, and repeat the video if the user has set it to repeat.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void vlcControl_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            // The only way to loop playback is to have a delegate call play asynchronously. 
            if (RepeatTimes == 11)
            {
                asyncPlay();
            }
            else if (repeatsRemaining > 0)
            {
                asyncPlay();
                repeatsRemaining -= 1;
            }
            else
            {
                repeatsRemaining = RepeatTimes;
                // Autoplay functionality
                if (playNextCheckBox.Checked)
                {
                    if (currentRecordingIndex < wordsList.Count - 1)
                    {
                        currentRecordingIndex += 1;
                        // Run this command on the GUI thread
                        Invoke((MethodInvoker)delegate {
                            VowelComboBox.SelectedIndex += 1;
                        });
                    }
                    else    // Move back to beginning if the user reaches the end of the list.
                    {
                        currentRecordingIndex = 0;
                        Invoke((MethodInvoker)delegate {
                            VowelComboBox.SelectedIndex = 0;
                        });
                    }
                    playVideo();
                }
                else
                {
                    playButton.ImageIndex = 1;
                }
            }
        }

        /// <summary>
        /// Move to the next sound when the next button is clicked.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (currentRecordingIndex < wordsList.Count - 1)
            {
                currentRecordingIndex += 1;
                VowelComboBox.SelectedIndex += 1;
            }
            else    // Move back to beginning if the user reaches the end of the list.
            {
                currentRecordingIndex = 0;
                VowelComboBox.SelectedIndex = 0;
            }

            // If the video is playing, automatically play the next one.
            if (vlcControl.State.Equals(Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing))
            {
                playVideo();
            }
            else
            {
                asyncStop();  // So the old image doesn't stay on screen.
            }

        }

        /// <summary>
        /// Move to the previous sound when the previous button is clicked.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backwardButton_Click(object sender, EventArgs e)
        {
            if (currentRecordingIndex > 0)
            {
                currentRecordingIndex -= 1;
                VowelComboBox.SelectedIndex -= 1;
            }
            else    // Move to the end if the user reaches the beginning of the list.
            {
                currentRecordingIndex = wordsList.Count - 1;
                VowelComboBox.SelectedIndex = wordsList.Count - 1;
            }
            // If the video is playing, automatically play the next one.
            if (vlcControl.State.Equals(Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing))
            {
                playVideo();
            }
            else
            {
                asyncStop();  // So the old image doesn't stay on screen.
            }
        }

        /// <summary>
        /// Removes the selected word from the Sound List Current List Box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void soundListRemoveButton_Click(object sender, EventArgs e)
        {
            asyncStop();    // Stop playback - changing lists can cause unusual behaviour.

            // Can't remove from a list as we iterate through it, so add the items to remove to a list, then delete them.
            List<Word> tempList = new List<Word>(); 
            foreach (Word wd in soundListCurrentListBox.SelectedItems)
            {
                tempList.Add(wd);
            }

            // Remove the word from all the lists used by the screen.
            foreach (Word wd in tempList)   
            {
                soundListCurrentListBox.Items.Remove(wd);
                VowelComboBox.Items.Remove(wd);
                wordsList.Remove(wd);
            }

            selectItemInComboBox();
        }

        /// <summary>
        /// Adds all the available words to the Sound List Current List Box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void soundListAddAllButton_Click(object sender, EventArgs e)
        {
            asyncStop();        // Stop playback - changing lists can cause unusual behaviour.

            // Clear all lists - this is more efficient than sorting them.
            soundListCurrentListBox.Items.Clear();
            VowelComboBox.Items.Clear();
            wordsList.Clear();

            // Add all words to each list used by the screen. These will always be in he correct order, as the All box doesn't change.
            soundListCurrentListBox.Items.AddRange(soundListAllListBox.Items);
            foreach (Word wd in soundListAllListBox.Items)     
            {
                VowelComboBox.Items.Add(wd);
                wordsList.Add(wd);
            }

            selectItemInComboBox();
        }

        /// <summary>
        /// Adds all the available words to the Sound List Current List Box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void soundListAddButton_Click(object sender, EventArgs e)
        {
            asyncStop();        // Stop playback - changing lists can cause unusual behaviour.

            List<Word> tempList = new List<Word>();
            // Add all words tha should be added to each list used by the screen. These will always be in he correct order, as the All box doesn't change.
            foreach (Word wd in soundListAllListBox.Items)
            {
                if (soundListCurrentListBox.Items.Contains(wd) || soundListAllListBox.SelectedItems.Contains(wd))   
                {
                    tempList.Add(wd);
                }
            }

            // It is more efficient to clear the lists and add new items than to sort the existing lists.
            VowelComboBox.Items.Clear();
            soundListCurrentListBox.Items.Clear();
            foreach (Word wd in tempList)
            {
                VowelComboBox.Items.Add(wd);
                soundListCurrentListBox.Items.Add(wd);
            }
            wordsList = tempList;

            selectItemInComboBox();
        }

        /// <summary>
        /// VowelComboBox should always have a value selected. 
        /// This method should be called when the selected item may have been deleted, and it selects index 0 if this is the case.
        /// </summary>
        private void selectItemInComboBox()
        {
            if (VowelComboBox.SelectedItem == null)
            {
                VowelComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Restores all options to their default settings.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            asyncStop();    // Stop playback.
            soundListAddAllButton_Click(sender, e); // Add all words back to the lists.
            VowelComboBox.SelectedIndex = 0;    // Reset the combobox.
            if (!recordingProgressBarLabel.Text.Equals(noFileText))
            {
                removeButton_Click(sender, e);  // Remove any audio file that may have been added.
            }
            repeatTrackBar.Value = 0;   // Reset repeats to 0.
            playNextCheckBox.Checked = false;   // Reset play next to false.
        }

        /// <summary>
        /// Fires when the form closes. 
        /// If the user pressed the back button, the next form will be loaded. 
        /// If the user closed the form in some other way, the app will temrinate.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void VideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appClosing)
            {
                UserManagement.WriteSettings();
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }
    }
}


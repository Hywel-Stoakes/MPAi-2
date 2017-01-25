using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MPAi.Cores
{
    /// <summary>
    /// System configuration is held in a static object, which is loaded from the local file called "SystemConfig.ini".
    /// </summary>
    class SystemConfigration
    {         
        static public SysCfg configs = Serializer<SysCfg>.Load<BinaryFormatter>(SysCfg.path);
    }
    /// <summary>
    /// Serialization controls for the System Configuration object.
    /// </summary>
    [Serializable]
    public class SysCfg : ISerializable
    {
        /// <summary>
        /// Default constructor, sets the local folder addresses for each of the required system folders.
        /// </summary>
        public SysCfg()
        {
            audioFolderAddr = new FolderAddress("Audio");
            videoFolderAddr = new FolderAddress("Video");
            recordingFolderAddr = new FolderAddress("Recording");
            reportFolderAddr = new FolderAddress("Report");
            htkFolderAddr = new FolderAddress("HTK");
            fomantFolderAddr = new FolderAddress("Fomant");
        }
        /// <summary>
        /// Override of the default constructor, accepting a file path argument.
        /// In addition to the tasks done in the default constructor, also sets the file path field.
        /// The file path is not used anywhere else in the code.
        /// </summary>
        /// <param name="path">The path to set as the file path, as a string.</param>
        public SysCfg(string path)
            : this()
        {
            this.filePath = path;
        }
        //Overrides necessary to convert objects to and from a bytestream.
        #region Serialization Control
        protected SysCfg(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            this.audioFolderAddr = info.GetValue("Audio Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.videoFolderAddr = info.GetValue("Video Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.recordingFolderAddr = info.GetValue("Personal Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.reportFolderAddr = info.GetValue("Personal Report Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.htkFolderAddr = info.GetValue("HTK Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.fomantFolderAddr = info.GetValue("Fomant Slot Folder Address", typeof(FolderAddress)) as FolderAddress;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("Audio Recording Folder Address", this.audioFolderAddr);
            info.AddValue("Video Recording Folder Address", this.videoFolderAddr);
            info.AddValue("Personal Recording Folder Address", this.recordingFolderAddr);
            info.AddValue("Personal Report Folder Address", this.reportFolderAddr);
            info.AddValue("HTK Folder Address", this.htkFolderAddr);
            info.AddValue("Fomant Slot Folder Address", this.fomantFolderAddr);
        }
        #endregion
        /// <summary>
        /// Currently unused.
        /// </summary>
        [NonSerialized]
        private String filePath;
        /// <summary>
        /// The path to the SystemConfig.ini file on this machine.
        /// Not serialized, as it may be different on other machines that it is loaded on.
        /// </summary>
        [NonSerialized]
        public static readonly String path = Path.Combine(System.Windows.Forms.Application.StartupPath, @"SystemConfig.ini");
        /// <summary>
        /// Property for the FolderAddress object representing the audio folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress audioFolderAddr;
        public FolderAddress AudioFolderAddr
        {
            get {return audioFolderAddr; }
            set{ audioFolderAddr = value; }
        }
        /// <summary>
        /// Property for the FolderAddress object representing the video folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress videoFolderAddr;
        public FolderAddress VideoFolderAddr
        {
            get{return videoFolderAddr;}
            set {videoFolderAddr = value;}
        }
        /// <summary>
        /// Property for the FolderAddress object representing the recording folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress recordingFolderAddr;
        public FolderAddress RecordingFolderAddr
        {
            get { return recordingFolderAddr; }
            set { recordingFolderAddr = value; }
        }
        /// <summary>
        /// Property for the FolderAddress object representing the report folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress reportFolderAddr;
        public FolderAddress ReportFolderAddr
        {
            get { return reportFolderAddr; }
            set { reportFolderAddr = value; }
        }
        /// <summary>
        /// Property for the FolderAddress object representing the HTK folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress htkFolderAddr;
        public FolderAddress HTKFolderAddr
        {
            get { return htkFolderAddr; }
            set { htkFolderAddr = value; }
        }
        /// <summary>
        /// Property for the FolderAddress object representing the Fomant folder, allowing access from outside the class.
        /// </summary>
        private FolderAddress fomantFolderAddr;
        public FolderAddress FomantFolderAddr
        {
            get { return fomantFolderAddr; }
            set { fomantFolderAddr = value; }
        }
    }
    /// <summary>
    /// Serializable wrapper class representing the address of each folder within the MPAi directory.
    /// Allows the relative location of data files to be maintained across systems.
    /// </summary>
    [Serializable]
    public class FolderAddress : ISerializable
    {
        /// <summary>
        /// A default constructor is required by most ORM frameworks.
        /// By not specifying a subfolder, this address only points to the base MPAi folder.
        /// </summary>
        public FolderAddress()
        {}
        /// <param name="subFolder">Allows this FolderAddress object to reference a subfolder of the base MPAi folder.</param>
        public FolderAddress(String subFolder)
            : this()
        {
            this.subFolder = subFolder;
        }
        //Overrides necessary to convert objects to and from a bytestream.
        #region Serialization Control
        protected FolderAddress(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            this.baseFolder = info.GetString("Base Folder Address");
            this.subFolder = info.GetString("Sub Folder Address");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("Base Folder Address", this.baseFolder);
            info.AddValue("Sub Folder Address", this.subFolder);
        }
        #endregion
        /// <summary>
        /// This string represents the path to the MPAi directory.
        /// </summary>
        private String baseFolder;
        /// <summary>
        /// Wrapper property for baseFolder, allowing it to be accessed from outside the class.
        /// Also provides a default value (The MPAi directory) if it has not been set.
        /// </summary>
        public String BaseFolder
        {
            get { return string.IsNullOrEmpty(baseFolder) ? System.Windows.Forms.Application.StartupPath : baseFolder; }
            set { baseFolder = value; }
        }
        /// <summary>
        /// This string represents the path to the subfolder this object refers to, starting from the base folder.
        /// </summary>
        private String subFolder;
        /// <summary>
        /// Wrapper property for subFolder, allowing it to be accessed from outside the class.
        /// </summary>
        public String SubFolder
        {
            get { return subFolder; }
            set { subFolder = value; }
        }
        /// <summary>
        /// This string represents the complete path that this FolderAddress object refers to.
        /// </summary>
        private String folderAddr;
        /// <summary>
        /// Wrapper property for folderAddr, allowing it to be accessed from outside the class.
        /// Creates the directory specified by the folderAddr if it does not already exist when get() is called.
        /// Also assigns a default value (The subFolder appended to the baseFolder) to this variable if it has not been set.
        /// </summary>
        public String FolderAddr
        {
            get
            {
                folderAddr = string.IsNullOrEmpty(folderAddr) ? Path.Combine(BaseFolder, SubFolder) : folderAddr;
                System.IO.Directory.CreateDirectory(folderAddr);
                return folderAddr;
            }
            set
            {
                folderAddr = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAi.Cores.Scoreboard
{
    public class MPAiSoundScoreBoardItem
    {
        string vowel;

        public string Vowel
        {
            get { return vowel; }
        }

        float correctnessPercentage;

        public float CorrectnessPercentage
        {
            get { return correctnessPercentage; }
        }

        public MPAiSoundScoreBoardItem(string vowel, float correctnessPercentage)
        {
            this.vowel = vowel;
            this.correctnessPercentage = correctnessPercentage;
        }
    }

    public class MPAiSoundScoreBoardSession
    {
        private DateTime dateAndTime;

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
        }

        private List<MPAiSoundScoreBoardItem> content = new List<MPAiSoundScoreBoardItem>();

        public List<MPAiSoundScoreBoardItem> Content
        {
            get { return content; }
        }

        float overallCorrectnessPercentage;

        public float OverallCorrectnessPercentage
        {
            get { return overallCorrectnessPercentage; }
            set { overallCorrectnessPercentage = value; }
        }

        public MPAiSoundScoreBoardSession(DateTime dateAndTime)
        {
            this.dateAndTime = dateAndTime;
        }

        public MPAiSoundScoreBoardSession(DateTime dateAndTime, List<MPAiSoundScoreBoardItem> content)
        {
            this.dateAndTime = dateAndTime;
            this.content = content;
        }

        public void AddScoreBoardItem(string vowel, float correctnessPercentage)
        {
            Content.Add(new MPAiSoundScoreBoardItem(vowel, correctnessPercentage));
        }

        public static int ComparisionByDate(MPAiSoundScoreBoardSession x, MPAiSoundScoreBoardSession y)
        {
            return DateTime.Compare(y.DateAndTime, x.DateAndTime);
        }

        public bool IsEmpty()
        {
            return !Content.Any();
        }
    }

    public class MPAiSoundScoreBoard
    { 
        private MPAiUser user;

        public MPAiUser User
        {
            get { return user; }
        }
        /// <summary>
        /// A list of all of the scoreboard sessions on the scoreboard.
        /// </summary>     
        private List<MPAiSoundScoreBoardSession> sessions = new List<MPAiSoundScoreBoardSession>();

        public List<MPAiSoundScoreBoardSession> Sessions
        {               
            get         
            {           
                sessions.Sort(MPAiSoundScoreBoardSession.ComparisionByDate);
                return sessions;
            }           
        }               
                        
        public MPAiSoundScoreBoard(MPAiUser user)
        {               
            this.user = user;
        }               
                        
        public MPAiSoundScoreBoardSession NewScoreBoardSession()
        {               
            MPAiSoundScoreBoardSession session = new MPAiSoundScoreBoardSession(DateTime.Now);
            sessions.Add(session);
            return session;
        }               
                        
        public MPAiSoundScoreBoardSession NewScoreBoardSession(DateTime dateAndTime, List<MPAiSoundScoreBoardItem> content)
        {               
            MPAiSoundScoreBoardSession session = new MPAiSoundScoreBoardSession(dateAndTime, content);
            sessions.Add(session);
            return session;
        }               
                        
        public void SaveScoreBoardToFile()
        {               
            MPAiSoundScoreboardLoader.SaveScoreboard(this);
        }

        public bool IsEmpty()
        {
            foreach (MPAiSoundScoreBoardSession session in Sessions)
            {
                if (!session.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }
    }
}

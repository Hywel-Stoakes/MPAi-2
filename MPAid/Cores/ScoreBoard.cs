using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    public delegate float SimilarityAlgorithmCallBack(string str1, string str2);
    /// <summary>
    /// Class representing each item on the scoreboard.
    /// </summary>
    class ScoreBoardItem
    {
        /// <summary>
        /// Calls the similarity algorithm to calculate the difference between the two arguments.
        /// </summary>
        /// <param name="simi">The delegate method to use to calculate the difference between the two arguments.</param>
        /// <returns>A float representing the percentage difference.</returns>
        public float Similarity(SimilarityAlgorithmCallBack simi)
        {
            return simi(recognisedText, expectingText);
        }
        /// <summary>
        /// The text the HTKEngine identified.
        /// </summary>
        private string recognisedText;
        public string RecognisedText
        {
            get { return recognisedText; }
            set { recognisedText = value; }
        }
        /// <summary>
        /// The text the user input as what they were trying to say.
        /// </summary>
        private string expectingText;
        public string ExpectingText
        {
            get { return expectingText; }
            set { expectingText = value; }
        }
        /// <summary>
        /// The text describing what the user got right and wrong.
        /// </summary>
        private string analysis;
        public string Analysis
        {
            get { return analysis; }
            set { analysis = value; }
        }
    }
    /// <summary>
    /// Class representing the scoreboard as a whole.
    /// </summary>
    class ScoreBoard
    {
        /// <summary>
        /// A list of all of the scoreboard items on the scoreboard.
        /// </summary>     
        public List<ScoreBoardItem> Content = new List<ScoreBoardItem>();
        /// <summary>
        /// Calculates the overall correctness of each entry, by adding each entry's correctness and dividing by the number of entries.
        /// </summary>
        public float CalculateCorrectness
        {
            get { return CalculateScore / Content.Count;}
        }
        /// <summary>
        /// Calculates the total score of each entry on the scoreboard.
        /// </summary>
        public float CalculateScore
        {
            get
            {
                float sum = 0;
                foreach(ScoreBoardItem item in Content)
                {
                    sum += item.Similarity(SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm);
                }
                return sum;
            }
        }
    }
    /// <summary>
    /// Wrapper class for the similarity algorithm employed for the correctness value.
    /// </summary>
    public static class SimilarityAlgorithm
    {
        /// <summary>
        /// Implementation of the Damereau-Levenshein Distance Algorithm with adjacent transpositions.
        /// This calculates the difference between two strings based on the minimal number of operations to get from one to the other.
        /// </summary>
        /// <param name="str1">The first string to compare.</param>
        /// <param name="str2">The second string to compare.</param>
        /// <returns>A float representing the percentage difference between the two parameters.</returns>
        public static float DamereauLevensheinDistanceAlgorithm(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1))
            {
                if (string.IsNullOrEmpty(str2))
                    return 0;
                return str2.Length;
            }

            if (string.IsNullOrEmpty(str2))
            {
                return str1.Length;
            }

            int n = str1.Length;
            int m = str2.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return Math.Abs(1 - (float)d[n, m] / m);
        }
    }
}

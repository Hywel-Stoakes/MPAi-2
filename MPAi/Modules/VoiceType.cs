using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAi.Models
{
    /// <summary>
    /// Enum representing the VoiceType setting for a user.
    /// </summary>
    public enum VoiceType
    {
        MASCULINE_HERITAGE, MASCULINE_MODERN, FEMININE_HERITAGE, FEMININE_MODERN
    }

    /// <summary>
    /// Class for retrieving the appropriate VoiceType enum value from the given string
    /// </summary>
    public static class VoiceTypeConverter
    {
        // It is more efficient to have two dictionaries; we need to look up keys by value and values by key.

        private static Dictionary<string, VoiceType?> voiceTypeDictionary = new Dictionary<string, VoiceType?>()
        {
            { "MASCULINE_HERITAGE", VoiceType.MASCULINE_HERITAGE },
            { "MASCULINE_MODERN", VoiceType.MASCULINE_MODERN },
            { "FEMININE_HERITAGE", VoiceType.FEMININE_HERITAGE },
            { "FEMININE_MODERN", VoiceType.FEMININE_MODERN },
        };

        private static Dictionary<VoiceType?, string> voiceStringDictionary = new Dictionary<VoiceType?, string>()
        {
            { VoiceType.MASCULINE_HERITAGE, "MASCULINE_HERITAGE" },
            { VoiceType.MASCULINE_MODERN, "MASCULINE_MODERN" },
            { VoiceType.FEMININE_HERITAGE, "FEMININE_HERITAGE" },
            { VoiceType.FEMININE_MODERN, "FEMININE_MODERN" },
        };

        /// <summary>
        /// Returns the appropriate enum for the inputted string; null if string is not in dictionary.
        /// </summary>
        /// <param name="voiceString">The string to convert into VoiceType</param>
        public static VoiceType? getVoiceTypeFromString(string voiceString)
        {
            if(voiceTypeDictionary.ContainsKey(voiceString))
            {
                return voiceTypeDictionary[voiceString];
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the appropriate string for the inputted enum; null if enum is not in dictionary.
        /// </summary>
        /// <param name="voiceString">The enum to convert into a string.</param>
        public static string getStringFromVoiceType(VoiceType? voiceType)
        {
            if (voiceTypeDictionary.ContainsValue(voiceType))
            {
                return voiceStringDictionary[voiceType];
            }
            else
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAi.Modules
{
    /// <summary>
    /// Enum representing the VoiceType setting for a user.
    /// </summary>
    public enum VoiceType
    {
        MASCULINE_NATIVE, MASCULINE_MODERN, FEMININE_NATIVE, FEMININE_MODERN
    }

    /// <summary>
    /// Class for retrieving the appropriate VoiceType enum value from the given string
    /// </summary>
    public static class VoiceTypeConverter
    {
        // It is more efficient to have two dictionaries; we need to look up keys by value and values by key.

        private static Dictionary<string, VoiceType?> voiceTypeDictionary = new Dictionary<string, VoiceType?>()
        {
            { "MASCULINE_NATIVE", VoiceType.MASCULINE_NATIVE },
            { "MASCULINE_MODERN", VoiceType.MASCULINE_MODERN },
            { "FEMININE_NATIVE", VoiceType.FEMININE_NATIVE },
            { "FEMININE_MODERN", VoiceType.FEMININE_MODERN },
        };

        private static Dictionary<VoiceType?, string> voiceStringDictionary = new Dictionary<VoiceType?, string>()
        {
            { VoiceType.MASCULINE_NATIVE, "MASCULINE_NATIVE" },
            { VoiceType.MASCULINE_MODERN, "MASCULINE_MODERN" },
            { VoiceType.FEMININE_NATIVE, "FEMININE_NATIVE" },
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

        public static string getDisplayNameFromVoiceType(VoiceType? voicetype)
        {
            switch(voicetype)
            {
                case VoiceType.FEMININE_MODERN:
                    return "Feminine, Modern Māori";
                case VoiceType.FEMININE_NATIVE:
                    return "Feminine, Kuia Māori";
                case VoiceType.MASCULINE_MODERN:
                    return "Masculine, Modern Māori";
                case VoiceType.MASCULINE_NATIVE:
                    return "Masculine, Kaumatua Māori";
            }
            return "No Voice Type";
        }
    }

    public enum Gender
    {
        FEMININE, MASCULINE
    }

    public static class DisplayVoice
    {
        public static string DisplayNative(Gender gender)
        {
            switch (gender)
            {
                case Gender.FEMININE:
                    return "Kuia Māori";
                case Gender.MASCULINE:
                    return "Kaumatua Māori";
                default:
                    return null;
            }
        }
    }
}
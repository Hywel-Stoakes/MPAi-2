using System.Collections.Generic;

namespace MPAi.Modules
{

    public enum GenderType
    {
        FEMININE, MASCULINE
    }

    public enum LanguageType
    {
        NATIVE, MODERN
    }

    public class VoiceType
    {
        private GenderType gender;

        public GenderType Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        private LanguageType language;
        public LanguageType Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }


        public VoiceType(GenderType gender, LanguageType language)
        {
            this.language = language;
            this.gender = gender;
        }

        /// <summary>
        /// Returns the appropriate enum for the inputted string; null if string is not in dictionary.
        /// </summary>
        /// <param name="voiceString">The string to convert into VoiceType</param>
        public static VoiceType getVoiceTypeFromString(string voiceString)
        {
            switch(voiceString)
            {
                case "MASCULINE_NATIVE":
                    return new VoiceType(GenderType.MASCULINE, LanguageType.NATIVE);
                case "MASCULINE_MODERN":
                    return new VoiceType(GenderType.MASCULINE, LanguageType.MODERN);
                case "FEMININE_NATIVE":
                    return new VoiceType(GenderType.FEMININE, LanguageType.NATIVE);
                case "FEMININE_MODERN":
                    return new VoiceType(GenderType.FEMININE, LanguageType.MODERN);
            }
            return null;
        }

        /// <summary>
        /// Returns the appropriate string for the inputted enum; null if enum is not in dictionary.
        /// </summary>
        /// <param name="voiceString">The enum to convert into a string.</param>
        public static string getStringFromVoiceType(VoiceType voiceType)
        {
            if (voiceType.Gender.Equals(GenderType.MASCULINE) && voiceType.Language.Equals(LanguageType.NATIVE))
            {
                return "MASCULINE_NATIVE";
            }
            else if (voiceType.Gender.Equals(GenderType.FEMININE) && voiceType.Language.Equals(LanguageType.NATIVE))
            {
                return "FEMININE_NATIVE";
            }
            else if (voiceType.Gender.Equals(GenderType.MASCULINE) && voiceType.Language.Equals(LanguageType.MODERN))
            {
                return "MASCULINE_MODERN";
            }
            else if (voiceType.Gender.Equals(GenderType.FEMININE) && voiceType.Language.Equals(LanguageType.MODERN))
            {
                return "FEMININE_MODERN";
            }

            return null;
        }

        public static string getDisplayNameFromVoiceType(VoiceType voiceType)
        {
            if (voiceType.Gender.Equals(GenderType.MASCULINE) && voiceType.Language.Equals(LanguageType.NATIVE))
            {
                return "Masculine, Kaumatua Māori";       
            }
            else if (voiceType.Gender.Equals(GenderType.FEMININE) && voiceType.Language.Equals(LanguageType.NATIVE))
            {
                return "Feminine, Kuia Māori";
            }
            else if (voiceType.Gender.Equals(GenderType.MASCULINE) && voiceType.Language.Equals(LanguageType.MODERN))
            {
                return "Masculine, Modern Māori";
            }
            else if (voiceType.Gender.Equals(GenderType.FEMININE) && voiceType.Language.Equals(LanguageType.MODERN))
            {
                return "Feminine, Modern Māori";
            }
            return "No Voice Type";
        }
    }


    public static class DisplayVoice
    {
        public static string DisplayNative(GenderType gender)
        {
            switch (gender)
            {
                case GenderType.FEMININE:
                    return "Kuia Māori";
                case GenderType.MASCULINE:
                    return "Kaumatua Māori";
                default:
                    return null;
            }
        }
    }
}
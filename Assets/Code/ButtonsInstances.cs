using UnityEngine.UIElements.Experimental;

namespace Assets.Code
{
    public class ButtonsInstances
    {
        private static SettingsScript settings;
        private static JumpButtonBehaviour jump;
        private static MoreCharactersScript moreCharacters;
        private static VKButtonScript vkButton;
        private static RankingScript ranking;

        public static SettingsScript Settings
        {
            get => settings;
            set => settings = value;
        }

        public static JumpButtonBehaviour Jump
        {
            get => jump;
            set => jump = value;
        }

        public static MoreCharactersScript MoreCharacters
        {
            get => moreCharacters;
            set => moreCharacters = value;
        }

        public static VKButtonScript VkButton
        {
            get => vkButton;
            set => vkButton = value;
        }

        public static RankingScript Ranking
        {
            get => ranking;
            set => ranking = value;
        }
    }
}
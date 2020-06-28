using UnityEngine.UIElements.Experimental;

namespace Assets.Code
{
    public class ButtonsInstances
    {
        private static SettingsScript settings;
        private static JumpButtonBehaviour jump;
        private static MoreCharactersScript moreCharacters;

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
    }
}
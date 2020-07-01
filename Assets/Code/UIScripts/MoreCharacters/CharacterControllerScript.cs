using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class CharacterControllerScript : MonoBehaviour
    {
        private static List<PlayerBehaviour> charactersList = new List<PlayerBehaviour>();
        private static Vector2 startPosition = new Vector2(0f, -3.2f);
        private static Vector2 hidePosition = new Vector2(0f, -10f);
        private static string currentCharacter;
        

        public static List<PlayerBehaviour> CharactersList => charactersList;

        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey(StringConsts.CURRENT_CHARACTER))
            {
                var characterTag = PlayerPrefs.GetString(StringConsts.CURRENT_CHARACTER);
                foreach (var character in charactersList)
                {
                    if (character.tag == characterTag)
                    {
                        character.gameObject.SetActive(true);
                        character.MoveToPosition(startPosition);
                        PlayerInstance.setInstance(character);
                        currentCharacter = characterTag;
                        break;
                    }
                }
            }
            else
            {
                PlayerPrefs.SetString(StringConsts.START_CHARACTER, StringConsts.EQUIPED);
                PlayerPrefs.SetString(StringConsts.CURRENT_CHARACTER, StringConsts.START_CHARACTER);
                foreach (var character in charactersList)
                {
                    if (character.tag == StringConsts.START_CHARACTER)
                    {
                        character.gameObject.SetActive(true);
                        character.MoveToPosition(startPosition);
                        PlayerInstance.setInstance(character);
                        currentCharacter = StringConsts.START_CHARACTER;
                    }
                }
            }
            PlayerPrefs.Save();
        }

        public static void ChangeCharacter(string newCharacter)
        {
            foreach (var character in charactersList)
            {
                if (character.tag == currentCharacter)
                {
                    character.MoveToPosition(hidePosition);
                    character.gameObject.SetActive(false);
                    character.MoveToPosition(hidePosition);
                    continue;
                }
                if (character.tag == newCharacter)
                {
                    character.MoveToPosition(startPosition);
                    character.gameObject.SetActive(true);
                    character.Coins = PlayerPrefs.GetInt(StringConsts.COINS);
                    character.BestScore = PlayerPrefs.GetInt(StringConsts.BEST_SCORE);
                    PlayerInstance.setInstance(character);
                }
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class CharacterControllerScript : MonoBehaviour
    {
        [SerializeField] private GameObject character_0 = default;
        [SerializeField] private GameObject character_1 = default;
        [SerializeField] private GameObject character_2 = default;
        
        private static List<GameObject> charactersList = new List<GameObject>();
        private static Vector2 startPosition = new Vector2(0f, -3.2f);

        void Awake()
        {
            charactersList.Add(character_0);
            charactersList.Add(character_1);
            charactersList.Add(character_2);
        }
        

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
                        GameObject newCharacter = Instantiate(character, startPosition, Quaternion.identity);
                        PlayerInstance.setInstance(newCharacter.GetComponent<PlayerBehaviour>());
                        EventsController.AddToFreezableItems(newCharacter.GetComponent<PlayerBehaviour>());
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
                        GameObject newCharacter = Instantiate(character, startPosition, Quaternion.identity);
                        PlayerInstance.setInstance(newCharacter.GetComponent<PlayerBehaviour>());
                        EventsController.AddToFreezableItems(newCharacter.GetComponent<PlayerBehaviour>());
                    }
                }
            }
            PlayerPrefs.Save();
        }

        public static void ChangeCharacter(string newCharacterTag)
        {                 
            EventsController.RemoveFromFreezable(PlayerInstance.getInstance());
            Destroy(PlayerInstance.getInstance().gameObject);
            
            foreach (var character in charactersList)
            {
                if(character.tag == newCharacterTag)
                {
                    GameObject newCharacter = Instantiate(character, startPosition, Quaternion.identity);
                    PlayerInstance.setInstance(newCharacter.GetComponent<PlayerBehaviour>());
                    EventsController.AddToFreezableItems(newCharacter.GetComponent<PlayerBehaviour>());
                    break;
                }
            }
        }
    }
}

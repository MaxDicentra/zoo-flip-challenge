using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Code
{
    public class EventsController: MonoBehaviour
    {
        [SerializeField] AudioMixer am = default;
        private static RestartScript restart;
        private static List<IFreezable> freezableItems = new List<IFreezable>();

        public static RestartScript Restart
        {
            set => restart = value;
            get => restart;
        }

        public static List<IFreezable> FreezableItems
        {
            get => freezableItems;
            set => freezableItems = value;
        }

        public static void AddToFreezableItems(IFreezable item)
        {
            freezableItems.Add(item);
        }

        public static void RemoveFromFreezable(IFreezable item)
        {
            freezableItems.Remove(item);
        }

        void Start()
        {
            if (PlayerPrefs.HasKey(StringConsts.VOLUME))
            {
                am.SetFloat("VolumeParam", PlayerPrefs.GetFloat(StringConsts.VOLUME));
            }
            else
            {
                PlayerPrefs.SetFloat(StringConsts.VOLUME, StringConsts.MUSIC_ON);
                PlayerPrefs.Save();
            }
        }
        
        public static void GameOver()
        {
            foreach (var freezable in freezableItems) 
            { 
                freezable.Freeze();
            }
            
            BasePanelScript.Instance.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);

            restart.Move();
        }
    }
}
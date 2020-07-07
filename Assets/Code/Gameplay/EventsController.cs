using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EventsController: MonoBehaviour
    {
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
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EventsController: MonoBehaviour
    {
        private static SpikesBehaviour spikes;
        private static RestartScript restart;
        private static List<IFreezable> freezableItems = new List<IFreezable>();

        private bool isAllSet = false;

        public static RestartScript Restart
        {
            set => restart = value;
        }

        public static SpikesBehaviour Spikes
        {
            set => spikes = value;
        }

        public static List<IFreezable> FreezableItems => freezableItems;

        void Start()
        {
            
        }

        void Update()
        {
            if (!isAllSet)
            {
                isAllSet = true;
                SetGameOverEvents();
            }
        }

        public static void AddToFreezableItems(IFreezable item)
        {
            freezableItems.Add(item);
        }
        
        void SetGameOverEvents()
        {
            spikes.GoNotify += restart.Move;
            foreach (var freezable in freezableItems)
            {
                spikes.GoNotify += freezable.Freeze;

                spikes.FreezeAll += freezable.Freeze;
            }
        }
    }
}
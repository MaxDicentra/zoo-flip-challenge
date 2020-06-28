using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EventsController: MonoBehaviour
    {
        private static List<SpikesBehaviour> spikes = new List<SpikesBehaviour>();
        private static RestartScript restart;
        private static List<IFreezable> freezableItems = new List<IFreezable>();

        private bool isAllSet = false;

        public static RestartScript Restart
        {
            set => restart = value;
        }

        public static List<SpikesBehaviour> Spikes => spikes;

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
            foreach (var spike in spikes)
            {
                spike.GoNotify += restart.Move;

                foreach (var freezable in freezableItems)
                {
                    spike.GoNotify += freezable.Freeze;
                }
            }
        }
    }
}
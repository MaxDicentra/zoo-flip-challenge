using System.Collections.Generic;
using Assets.Code;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class PlatformsController: MonoBehaviour
    {
        private static List<PlatformScript> platforms = new List<PlatformScript>();
        
        public static List<PlatformScript> Platforms
        {
            get => platforms;
            set => platforms = value;
        }

        void Awake()
        {
            platforms = new List<PlatformScript>();
        }

        public static void AddPlatform(PlatformScript pl)
        {
            platforms.Add(pl);
        }

        public static PlatformScript GetOtherPlatform(PlatformScript caller)
        {
            foreach (var platform in platforms)
            {
                if (platform != caller)
                {
                    return platform;
                }
            }

            return null;
        }
    }
}
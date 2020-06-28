using Assets.Code;
using UnityEngine;

namespace Assets
{
    public class PlatformsController: MonoBehaviour
    {
        private static PlatformScript pl1;
        private static PlatformScript pl2;

        public static void AddPlatform(PlatformScript pl)
        {
            if (pl1 == null)
            {
                pl1 = pl;
                return;
            }

            if (pl2 == null)
            {
                pl2 = pl;
            }
        }

        public static PlatformScript GetOtherPlatform(PlatformScript caller)
        {
            if (caller != pl1)
            {
                return pl1;
            }
            return pl2;
        }
    }
}
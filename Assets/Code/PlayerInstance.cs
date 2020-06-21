using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

namespace Assets.Code
{
    public class PlayerInstance
    {
        public static PlayerBehaviour playerInstance;

        public static PlayerBehaviour getInstance()
        {
            return playerInstance;
        }

        public static void setInstance(PlayerBehaviour inst)
        {
            playerInstance = inst;
        }
        
    }
}
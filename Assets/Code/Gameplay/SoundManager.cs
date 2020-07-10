using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager Instance
    {
        get
        {
            return Instance;
        }
    }

    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(transform.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.Code;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{

    public delegate void GameOverHandler();
    private event GameOverHandler GONotify;
    
    public delegate void FreezeHandler();
    private event FreezeHandler freezeAll;
    

    public GameOverHandler GoNotify
    {
        get => GONotify;
        set => GONotify = value;
    }
    
    public FreezeHandler FreezeAll
    {
        get => freezeAll;
        set => freezeAll = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventsController.AddToSpikes(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // freeze everything
        // move final score panel
        FreezeAll?.Invoke();
        GONotify?.Invoke();
    }
}

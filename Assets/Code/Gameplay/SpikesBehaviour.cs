using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.Code;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // freeze everything
        // move final score panel
        EventsController.GameOver();
    }
}

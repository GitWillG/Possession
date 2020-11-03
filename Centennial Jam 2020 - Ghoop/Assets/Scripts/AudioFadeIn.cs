using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{

    AudioSource myVar;
    
    // Start is called before the first frame update
    void Start()
    {
         myVar = GetComponent<AudioSource>();
         myVar.volume = 0;
         myVar.pitch = -0.45f;
    }

    // Update is called once per frame
    void Update()
    {
        if(myVar.volume < 1)
        {
            myVar.volume += 0.001f;
        }
    }
}

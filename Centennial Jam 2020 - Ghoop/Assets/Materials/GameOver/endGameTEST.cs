﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class endGameTEST : MonoBehaviour
{
    public Canvas panel; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void onClick()
    {
        panel.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public GameObject eventTarget;
    public UnityEvent onInteracted;
    public void Interact()
    {
        //if the interactable has a function, run that function
        onInteracted?.Invoke();
    }

    internal void interact()
    {
        throw new NotImplementedException();
    }
}

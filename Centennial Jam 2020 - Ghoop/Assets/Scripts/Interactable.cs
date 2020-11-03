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
        onInteracted?.Invoke();
    }

    internal void interact()
    {
        throw new NotImplementedException();
    }
}

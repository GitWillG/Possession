using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public GameObject eventTarget;
    public List<GameObject> pressingButton;
    public UnityEvent onInteracted;
    public UnityEvent onInteracted2;

    private void Update()
    {
        if (pressingButton.Count == 0)
        {
            Interact2();
        }
    }
    public void Interact()
    {
        //if the interactable has a function, run that function
        onInteracted?.Invoke();
        playSound();
    }
    public void Interact2()
    {
        //if the interactable has a function, run that function
        onInteracted2?.Invoke();
    }

    public void playSound()
    {
        AudioManager.Instance.PlaySound("Start Button");
    }

    internal void interact()
    {
        throw new NotImplementedException();
    }
}

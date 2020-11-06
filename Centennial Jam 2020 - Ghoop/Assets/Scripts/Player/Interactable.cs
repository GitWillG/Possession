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
        if (this.gameObject.name == "Smoke")
        {
            playSmoke();
        }
        else
        {

            playSound();
        }
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
    public void playSmoke()
    {
        AudioManager.Instance.PlaySound("Gas");
    }

    internal void interact()
    {
        throw new NotImplementedException();
    }
}

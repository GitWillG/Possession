using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public GameObject eventTarget;
    public UnityEvent onInteracted;
    public void interact()
    {
        onInteracted?.Invoke();
    }

}

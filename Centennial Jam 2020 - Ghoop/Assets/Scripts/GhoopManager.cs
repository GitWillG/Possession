using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhoopManager : MonoBehaviour
{
    public float ghoop;
    public bool isGhost;
    public Slider ghoopSlider;
    // Start is called before the first frame update
    void Start()
    {
        isGhost = false;
        ghoop = 25f;
        ghoopSlider.maxValue = 25f;

    }

    // Update is called once per frame
    void Update()
    {
        if (ghoop >= 0)
        {
            ghoopSlider.value = ghoop;

        }
    }
    public void loseGame()
    {
        if (ghoop <= 0)
        {
            Debug.Log("you lose");
        }
    }
}

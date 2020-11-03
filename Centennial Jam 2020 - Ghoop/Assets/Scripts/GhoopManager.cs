using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhoopManager : MonoBehaviour
{
    public float ghoop;
    public bool isGhost;
    public Slider ghoopSlider;
    public float timeLeft;
    public Text timerText;
    public Text interactText;
    public Possess tempGhost;



    // Start is called before the first frame update
    void Start()
    {
        //initializing values
        timeLeft = 5f; 
        isGhost = false;
        ghoop = 25f;
        ghoopSlider.maxValue = 25f;

        //if these UI output texts exist, we save the reference
        timerText = GameObject.Find("TimerText")?.GetComponent<Text>();
        interactText = GameObject.Find("PressE")?.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhost)
        {
            //counterdown timers for ghost form
            timeLeft -= Time.unscaledDeltaTime;
            ghoop -= Time.unscaledDeltaTime; 

            //updating the display as long as you're a ghost
            if (timerText != null)
            {
                timerText.text = timeLeft.ToString();

            }

        }

        //when out of ghost-form time we reset the player back to an in corpse state, setting our ghost values back to the default state
        if (timeLeft <= 0f)
        {
            if (timerText != null)
            {
                timerText.text = "";

            }
            tempGhost.PossessCorpse(tempGhost.oldCorpse);

            //ghost values
            isGhost = false;
            timeLeft = 5f;
            return;

        }

        //as long as our ghoop meter isn't empty we will update it.
        if (ghoop >= 0)
        {
            ghoopSlider.value = ghoop;

        }

        //our only loss state is if you run out of total ghoop
        if (ghoop <= 0)
        {
            loseGame();
        }
    }
    public void loseGame()
    {
        Debug.Log("you lose");
    }

    //functions for displaying/hiding interactable elements
    public void DisplayInteraction(string input)
    {
        interactText.text = input;
    }
    public void HideInteraction()
    {
        interactText.text = "";
    }
}

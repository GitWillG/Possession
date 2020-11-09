using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GhoopManager : MonoBehaviour
{
    public float ghoop;
    public bool isGhost;
    public Slider ghoopSlider;
    public float timeLeft;
    public Text timerText;
    public GameObject loseScreen;
    public Text interactText;
    public Possess tempGhost;



    // Start is called before the first frame update
    void Start()
    {
        //initializing values
        timeLeft = 5f; 
        isGhost = false;
        //if (ghoopSlider = null)
        //{
        //    ghoopSlider = GameObject.FindObjectOfType<Slider>();
        //}
        if (ghoopSlider!= null)
        {
            
            ghoopSlider.maxValue = timeLeft;
        }

        //if these UI output texts exist, we save the reference
        timerText = GameObject.Find("TimerText")?.GetComponent<Text>();
        interactText = GameObject.Find("PressE")?.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ghoop = timeLeft;
        if (isGhost && Time.timeScale != 0)
        {
            //counterdown timers for ghost form
            timeLeft -= Time.unscaledDeltaTime;
            //ghoop -= Time.unscaledDeltaTime; 

            //updating the display as long as you're a ghost
            //if (timerText != null)
            //{
            //    //timerText.text = "Ghost Time" + '\n'+ "Remaining: " + Mathf.Round(timeLeft).ToString();

            //}

        }

        //when out of ghost-form time we reset the player back to an in corpse state, setting our ghost values back to the default state
        if (timeLeft <= 0f)
        {
            //if (timerText != null)
            //{
            //    timerText.text = "";


            //}
            tempGhost.PossessCorpse(tempGhost.oldCorpse);

            //ghost values
            isGhost = false;
            timeLeft = 5f;

            //    if (ghoop <= 0)
            //{
            //    tempGhost.PossessCorpse(tempGhost.oldCorpse);
            //    loseGame();
            //}
            return;

        }

        //as long as our ghoop meter isn't empty we will update it.
        if (ghoop >= 0)
        {
            if (ghoopSlider != null)
            {
                ghoopSlider.value = ghoop;
            }

        }
        else
        {
            timeLeft = 5;
        }

        //our only loss state is if you run out of total ghoop
        
    }
    public void loseGame()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
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
    public void Restart()
    {
        loseScreen.SetActive(false);

        SceneManagement.Instance.restart();

    }
    public void mainMenu()
    {
        loseScreen.SetActive(false);
        SceneManagement.Instance.loadMain();
    }
}

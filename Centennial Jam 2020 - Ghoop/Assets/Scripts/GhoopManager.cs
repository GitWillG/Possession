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
        if (timeLeft < 1)
        {
            timeLeft = 5f;
        }
        // GHM.isGhost = true;
        var item = GameObject.Find("TimerText");
        timerText = item?.GetComponent<Text>();
        var item2 = GameObject.Find("PressE");
        if (item2 != null)
        {
            interactText = item2.GetComponent<Text>();
        }
        isGhost = false;
        ghoop = 25f;
        ghoopSlider.maxValue = 25f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGhost)
        {
            timeLeft -= Time.unscaledDeltaTime;
            ghoop -= Time.unscaledDeltaTime; 
            if (timerText != null)
            {
                timerText.text = timeLeft.ToString();

            }

        }

        if (timeLeft <= 0f)
        {
            if (timerText != null)
            {
                timerText.text = "";

            }
            tempGhost.PossessCorpse(tempGhost.oldCorpse);
            isGhost = false;
            timeLeft = 5f;
            return;

        }
        if (ghoop >= 0)
        {
            ghoopSlider.value = ghoop;

        }

        if (ghoop <= 0)
        {
            loseGame();
        }
    }
    public void loseGame()
    {
        Debug.Log("you lose");
    }

    public void DisplayInteraction(string input)
    {
        interactText.text = "";
        interactText.text = input;
    }
    public void HideInteraction()
    {
        interactText.text = "";
    }
}

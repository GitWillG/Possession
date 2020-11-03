using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Possess : MonoBehaviour
{
    public GameObject ghost;
    public GameObject Corpse;
    public GameObject oldCorpse;
    public float timeLeft;
    public Text timerText;
    public Text interactText;
    public GhoopManager GHM;

    // Start is called before the first frame update
    private void Awake()
    {
        GHM = GameObject.FindObjectOfType<GhoopManager>();
        if (timeLeft <1 )
        {
            timeLeft = 5f;
        }
        GHM.isGhost = true;
        var item = GameObject.Find("TimerText");
        timerText = item?.GetComponent<Text>(); 
        var item2 = GameObject.Find("PressE");
        if (item2 != null)
        {
            interactText = item2.GetComponent<Text>();
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Corpse != null)
        {
            if (timerText != null)
            {
                timerText.text = "";

            }
            possessCorpse();
            return;

        }
        //StartCoroutine(timeLimit());
        timeLeft -= Time.unscaledDeltaTime;
        GHM.ghoop -= Time.unscaledDeltaTime;
        if (timerText != null)
        {
            timerText.text = timeLeft.ToString();

        }
        if (timeLeft <= 0f)
        {
            if (timerText != null)
            {
                timerText.text = "";

            }
            possessCorpse(oldCorpse);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            displayInteraction("Press E to possess corpse");
            Corpse = collision.gameObject;


        }
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            hideInteraction();
            Corpse = null;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            displayInteraction("Press E to possess corpse");
        }
    }

    public void possessCorpse()
    {

        GHM.isGhost = false;
        Corpse.GetComponent<Collider2D>().isTrigger = false;
        Corpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = Corpse.transform;
        Destroy(this.gameObject);
    }
    public void possessCorpse(GameObject targetcorpse)
    {
        GHM.isGhost = false;
        targetcorpse.GetComponent<Collider2D>().isTrigger = false;
        targetcorpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = targetcorpse.transform;
        Destroy(this.gameObject);
    }
    IEnumerator timeLimit()
    {
        yield return new WaitForSeconds(timeLeft);
        possessCorpse(oldCorpse);
    }
    public void displayInteraction(string input)
    {
        interactText.text = input;
    }
    public void hideInteraction()
    {
        interactText.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Possess : MonoBehaviour
{
    public GameObject ghost;
    public GameObject Corpse;
    public GameObject oldCorpse;
    public GhoopManager GHM;

    private void Awake()
    {
        //get the ghoop manager so we can alter UI text
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        //if the ghost-player has a nearby corpse and you press E you can possess it
        if (Input.GetKeyDown(KeyCode.E) && Corpse != null)
        {

            Corpse.gameObject.GetComponent<Ghostify>().enabled = true;
            PossessCorpse();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the ghost-player touches a corpse we save that as a nearby corpse
        if (collision.gameObject.tag == "Corpse")
        {
            Corpse = collision.gameObject;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //as long as the ghost-player is on a corpse we display the prompt
        if (collision.gameObject.tag == "Corpse")
        {
            GHM.DisplayInteraction("Press E to possess corpse");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the player moves away from a corpse, we forget about it and remove the prompt
        if (collision.gameObject.tag == "Corpse")
        {
            GHM.HideInteraction();
            Corpse = null;
        }
    }
 

    public void PossessCorpse()
    {
        //you're not a ghost anymore 
        GHM.isGhost = false;

        //renable player functionality of the corpse, including making the camera follow
        Corpse.GetComponent<Collider2D>().isTrigger = false;
        Corpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = Corpse.transform;
        Corpse.GetComponent<Animator>().SetBool("_isDead", false);

        //destroy the ghost
        Destroy(this.gameObject);

        //reset values
        GHM.HideInteraction();
        GHM.timerText.text = "";
        GHM.timeLeft = 5f;
    }

    //same as above except you can pass through a specific corpse
    public void PossessCorpse(GameObject targetcorpse)
    {
        GHM.isGhost = false;

        targetcorpse.gameObject.GetComponent<Ghostify>().enabled = true;
        targetcorpse.GetComponent<Collider2D>().isTrigger = false;
        targetcorpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = targetcorpse.transform;

        Destroy(this.gameObject);

        GHM.HideInteraction();
        GHM.timerText.text = "";
        GHM.timeLeft = 5f;
    }

  
}

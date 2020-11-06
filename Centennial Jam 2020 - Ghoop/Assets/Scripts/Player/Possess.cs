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
    private playerController PC;

    private void Awake()
    {
        PC = this.GetComponent<playerController>();
        //get the ghoop manager so we can alter UI text
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
        //PC.isghost = true;
    }
    // Start is called before the first frame update
    private void Update()
    {
        PC.isghost = true;
        //if the ghost-player has a nearby corpse and you press E you can possess it
        if (Input.GetKeyDown(KeyCode.E) && Corpse != null)
        {

            PC.isghost = false;
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
        Corpse.GetComponent<CorpseAnimator>().enabled = false;
        Corpse.GetComponent<Animator>().SetBool("_isDead", false);
        Corpse.GetComponent<PlayerAnimator>().enabled = true;

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
        targetcorpse.GetComponent<PlayerAnimator>().enabled = true;

        Destroy(this.gameObject);

        GHM.HideInteraction();
        GHM.timerText.text = "";
        GHM.timeLeft = 5f;
    }

  
}

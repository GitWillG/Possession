using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ghostify : MonoBehaviour
{
    public GameObject startLocation;

    public UnityEvent open;
    public GameObject ghost;

    public GameObject interactableObj;

    [SerializeField]
    private Animator _anim;
    private GhoopManager GHM;

    // Start is called before the first frame update
    private void Start()
    {
        //get the ghoop manager so we can alter UI text
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }
    private void Update()
    {
        if (interactableObj != null)
        {
            if (interactableObj.GetComponent<Interactable>() != null && Input.GetKeyDown(KeyCode.E))
            {
                //when the player is on the interactable and presses E it activates whatever function is on the interactable itself
                interactableObj.GetComponent<Interactable>().Interact();
            }
        }
    }

    //Colliders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if you colide with a hazard we stop the animations and kill the player
        if (collision.gameObject.tag == "Hazard")
        {
            this.gameObject.GetComponent<Ghostify>().enabled = false;
            interactableObj = null;
            _anim.SetBool("_isMoving", false);
            _anim.SetBool("_isDead", true);
            Incorporeal();

        }

        //if you colide with the end zone you win the game!
        else if (collision.gameObject.tag == "endZone")
        {
            this.gameObject.transform.position = new Vector2(0, 0);
            Debug.Log("you win");
        }
    }


    //Triggers
    //in case we are using a trigger zone for end of level instead of a wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "endZone")
        {
            this.gameObject.transform.position = new Vector2(0, 0);
            Debug.Log("you win");
        }
        if (collision.gameObject.tag == "weighted")
        {
            collision.gameObject.GetComponent<Interactable>().Interact();
            collision.gameObject.GetComponent<Interactable>().pressingButton.Add(this.gameObject);
            //displays the button prompt
        }     //if you colide with a hazard we stop the animations and kill the player
        if (collision.gameObject.tag == "Hazard")
        {
            this.gameObject.GetComponent<Ghostify>().enabled = false;
            interactableObj = null;
            if (this.GetComponent<playerController>().enabled == false)
            {

                this.GetComponent<basicAI>().enabled = false;
                this.tag = "Corpse";
            }
            if (this.GetComponent<playerController>().enabled == true)
            {
                Incorporeal();
            }

            _anim.SetBool("_isMoving", false);
            _anim.SetBool("_isDead", true);

        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            interactableObj = collision.gameObject;
            //displays the button prompt
            GHM.DisplayInteraction("Press E to interact");
            
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if you step away from an interactable we empty the UI display
        if (collision.gameObject.tag == "Interactable")
        {
            interactableObj = null;
            GHM.HideInteraction();
        }
        if (collision.gameObject.tag == "weighted")
        {
            collision.gameObject.GetComponent<Interactable>().pressingButton.Remove(this.gameObject);
            //displays the button prompt
        }

    }

    //Kill the player and spawn a ghost
    public void Incorporeal()
    {
        //turn the player's corpse into a trigger so it doesn't obstruct the ghost
        this.GetComponent<Collider2D>().isTrigger = true;
        //Turn off the controller so you cannot move the corpse
        this.GetComponent<playerController>().enabled = false;
        //turn the game object into a corpse
        this.gameObject.tag = "Corpse";


        //Make a ghost from our ghost prefab, make sure it is has no parent, remember the corpse we came from, and make the camera follow our ghost
        GameObject ghostOb = Instantiate(ghost, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        ghostOb.transform.parent = null;
        ghostOb.GetComponent<Possess>().oldCorpse = this.gameObject;
        Camera.main.GetComponent<CameraFollower>().target = ghostOb.transform;
        
        //for time sensitive triggers the ghoopManager needs access to our ghost
        GHM.tempGhost = ghostOb.GetComponent<Possess>();

        //you're a ghost harry
        GHM.isGhost = true;
    }

}

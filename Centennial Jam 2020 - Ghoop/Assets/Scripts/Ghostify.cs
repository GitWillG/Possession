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
    public Text interactText;

    [SerializeField]
    private Animator _anim;
    private GhoopManager GHM;

    // Start is called before the first frame update
    private void Start()
    {
        var item = GameObject.Find("PressE");
        if (item != null)
        {
            interactText = item.GetComponent<Text>();
        }

        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            _anim.SetBool("_isMoving", false);
            Incorporeal();

        }
        if (collision.gameObject.tag == "Interactable")
        {
            DisplayInteraction("Press E to interact");

        }
        else if (collision.gameObject.tag == "endZone")
        {
            Debug.Log("you win");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            if (collision.gameObject.GetComponent<Interactable>() != null && Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<Interactable>().interact();
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Hazard")
        {
            _anim.SetBool("_isMoving", false);
            if (GHM.isGhost == false)
            {
                Incorporeal();
            }
            
            if (GHM.ghoop <= 0)
            {
                GHM.loseGame();
                Debug.Log("i cri");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            HideInteraction();

        }
    }

    public void Incorporeal()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<playerController>().enabled = false;
        this.gameObject.tag = "Corpse";
        GameObject ghostOb = Instantiate(ghost, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        ghostOb.transform.parent = null;
        ghostOb.GetComponent<Possess>().oldCorpse = this.gameObject;
        Camera.main.GetComponent<CameraFollower>().target = ghostOb.transform;
        GHM.isGhost = true;
    }
    public void DisplayInteraction(string input)
    {
        interactText.text = input;
    }
    public void HideInteraction()
    {
        interactText.text = "";
    }
}

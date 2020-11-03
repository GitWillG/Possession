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
    //public Text interactText;

    [SerializeField]
    private Animator _anim;
    private GhoopManager GHM;

    // Start is called before the first frame update
    private void Start()
    {
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Hazard")
        {
            
            _anim.SetBool("_isMoving", false);
            Incorporeal();

        }

        else if (collision.gameObject.tag == "endZone")
        {
            Debug.Log("you win");
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Interactable")
    //    {


    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "endZone")
        {
            Debug.Log("you win");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Debug.Log("interaciton");
            GHM.DisplayInteraction("Press E to interact");
            if (collision.gameObject.GetComponent<Interactable>() != null && Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<Interactable>().Interact();
            }
        }
        //if (collision.gameObject.tag == "Hazard")
        //{
        //    _anim.SetBool("_isMoving", false);
        //    if (GHM.isGhost == false)
        //    {
        //        Incorporeal();
        //    }
            
        //    if (GHM.ghoop <= 0)
        //    {
        //        GHM.loseGame();
        //        Debug.Log("i cri");
        //    }
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            GHM.HideInteraction();

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
        GHM.tempGhost = ghostOb.GetComponent<Possess>();
        GHM.isGhost = true;
    }

}

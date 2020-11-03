using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ghostify : MonoBehaviour
{
    public UnityEvent open;
    public GameObject ghost;
    public Text interactText;
    // Start is called before the first frame update
    private void Start()
    {
        var item = GameObject.Find("PressE");
        if (item != null)
        {
            interactText = item.GetComponent<Text>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            incorporeal();

        }
        if (collision.gameObject.tag == "Interactable")
        {
            displayInteraction("Press E to interact");

        }
        else if (collision.gameObject.tag == "endZone")
        {
            Debug.Log("you win");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            if (collision.gameObject.GetComponent<Interactable>()!= null && Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<Interactable>().interact();
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Interactable")
        {
            Debug.Log("collision");
            hideInteraction();

        }

    }
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        open?.Invoke();
    //    }
    //}


    public void incorporeal()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<playerController>().enabled = false;
        this.gameObject.tag = "Corpse";
        GameObject ghostOb = Instantiate(ghost, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        ghostOb.transform.parent = null;
        ghostOb.GetComponent<Possess>().oldCorpse = this.gameObject;
        Camera.main.GetComponent<CameraFollower>().target = ghostOb.transform;
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

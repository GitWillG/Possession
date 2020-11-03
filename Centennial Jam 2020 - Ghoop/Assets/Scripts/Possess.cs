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
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Corpse != null)
        {
            GHM.HideInteraction();
            GHM.timerText.text = "";
            GHM.timeLeft = 5f;

            PossessCorpse();
            return;

        }
        //StartCoroutine(timeLimit());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            //GHM.DisplayInteraction("Press E to possess corpse");
            Corpse = collision.gameObject;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            GHM.DisplayInteraction("Press E to possess corpse");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            GHM.HideInteraction();
            Corpse = null;

        }
    }
 

    public void PossessCorpse()
    {
        GHM.isGhost = false;
        Corpse.GetComponent<Collider2D>().isTrigger = false;
        Corpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = Corpse.transform;
        Destroy(this.gameObject);
    }
    public void PossessCorpse(GameObject targetcorpse)
    {
        targetcorpse.GetComponent<Collider2D>().isTrigger = false;
        targetcorpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = targetcorpse.transform;
        Destroy(this.gameObject);
    }

    //public void DisplayInteraction(string input)
    //{
    //    interactText.text = input;
    //}
    //public void HideInteraction()
    //{
    //    interactText.text = "";
    //}
}

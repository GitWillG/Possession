using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour
{
    public GameObject ghost;
    public GameObject Corpse;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Corpse != null)
        {
            Debug.Log("E");
            possessCorpse();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            Corpse = collision.gameObject;

            Debug.Log("collision");

        }
        else if (collision.gameObject.tag == "endZone")
        {
            Debug.Log("you win");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            Corpse = null;

        }
    }

    public void possessCorpse()
    {
        Debug.Log("test");
        Corpse.GetComponent<Collider2D>().isTrigger = false;
        Corpse.GetComponent<playerController>().enabled = true;
        Camera.main.GetComponent<CameraFollower>().target = Corpse.transform;
        Destroy(this.gameObject);
        //this.GetComponent<Collider2D>().isTrigger = true;
        //this.GetComponent<playerController>().enabled = false;
        //this.gameObject.tag = "Corpse";
        //GameObject ghostOb = Instantiate(ghost, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        //ghostOb.transform.parent = null;
        //Camera.main.GetComponent<CameraFollower>().target = ghostOb.transform;
    }
}

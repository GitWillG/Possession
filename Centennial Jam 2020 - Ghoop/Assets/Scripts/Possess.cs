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

    // Start is called before the first frame update
    private void Awake()
    {
        if (timeLeft <1 )
        {
            timeLeft = 5f;
        }
        var item = GameObject.Find("TimerText");
        if (item != null)
        {

            timerText = item.GetComponent<Text>();
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
            Debug.Log("E");
            possessCorpse();
            return;

        }
        //StartCoroutine(timeLimit());
        timeLeft -= Time.unscaledDeltaTime;
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
            Corpse = collision.gameObject;

            Debug.Log("collision");

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
    }
    public void possessCorpse(GameObject targetcorpse)
    {
        Debug.Log("test");
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
}

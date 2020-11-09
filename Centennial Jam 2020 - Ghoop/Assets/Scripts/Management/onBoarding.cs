using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBoarding : MonoBehaviour
{
    public GameObject pointer;
    public GameObject pressSpace;
    public bool timeStop;
    public GameObject deathTut;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Corpse")
        {
            StartCoroutine(explainGoop());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timeStop)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                endTut();

            }
        }
    }
    IEnumerator explainGoop()
    {
        deathTut.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        pointer.SetActive(true);
        timeStop = true;
    }
    //public void explainGoop()
    //{

    //}
    public void endTut()
    {

        Time.timeScale = 1;
        pointer.SetActive(false);
        timeStop = false;
        Destroy(this.GetComponent<onBoarding>());
    }
}

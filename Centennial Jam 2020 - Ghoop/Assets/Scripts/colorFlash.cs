using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorFlash : MonoBehaviour
{
    Color lightRed = new Color(0.99f, 0.49f, 0.49f, 1f);
    Color darkGrey = new Color(0.09f, 0.09f, 0.09f, 1f);
    Color myVar; 
    // Start is called before the first frame update
    void Start()
    {
        myVar = GetComponent<RawImage>().color;
        
    }

    // Update is called once per frame
    void Update()
    {
       myVar = Color.Lerp(darkGrey, lightRed, Mathf.PingPong(Time.time, 1));
       this.gameObject.GetComponent<RawImage>().color = myVar;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAI : MonoBehaviour
{
    public List<GameObject> targetpoints;
    public bool walking;
    private GameObject currentTarget;
    public bool isAlive;

    private Rigidbody2D _rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.15f;
        walking = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (isAlive)
        {
            if (targetpoints.Count != 0 && walking == false)
            {
                int rand = Random.Range(0, targetpoints.Count - 1);
                currentTarget = targetpoints[rand];
                walking = true;
            }
            if (walking == true)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, currentTarget.transform.position, speed);
            }
            float dist = Vector3.Distance(currentTarget.transform.position, transform.position);
            if (dist <= 1f)
            {
                int newrand = Random.Range(0, targetpoints.Count);
                if (targetpoints[newrand].gameObject == currentTarget.gameObject)
                {
                    newrand = Random.Range(0, targetpoints.Count);
                }
                else
                {
                    currentTarget = targetpoints[newrand];
                }
            }
        }
    }

}

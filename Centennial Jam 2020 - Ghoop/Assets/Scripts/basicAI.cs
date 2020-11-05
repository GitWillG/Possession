using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAI : MonoBehaviour
{
    public List<GameObject> targetpoints;
    public bool walking;    
    private GameObject currentTarget;
    public bool isAlive;
    int newrand;
    [SerializeField]
    public Animator _anim;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    public bool waiting;
    public float speed;
    public float dir;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        waiting = false;
        speed = 5f;
        walking = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (isAlive)
        {

            if (targetpoints.Count != 0 && walking == false && currentTarget == null)
            {
                int rand = Random.Range(0, targetpoints.Count - 1);
                currentTarget = targetpoints[rand];
                walking = true;
            }

            if (walking == true)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
                dir = currentTarget.transform.position.x - this.transform.position.x; 
            }

            dist = Vector3.Distance(currentTarget.transform.position, transform.position);
            
            if (dist <= 1f && waiting == false)
            {
                stopWalking();
                newrand = Random.Range(0, targetpoints.Count);

                if (targetpoints[newrand].gameObject == currentTarget.gameObject)
                {
                    newrand = Random.Range(0, targetpoints.Count);
                }
                else
                {
                    StartCoroutine(wait1sec());
                }
               
            }
        }
    }
    IEnumerator wait1sec()
    {
        waiting = true;
        yield return new WaitForSeconds(1);
        currentTarget = targetpoints[newrand];
        walking = true;
        waiting = false;
    }
    public void stopWalking()
    {
        walking = false;
        Debug.Log("stopped");
    }

}

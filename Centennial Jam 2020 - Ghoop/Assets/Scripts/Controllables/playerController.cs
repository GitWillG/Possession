using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    #region Varibales
    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    public GameObject targetEnemy;
    public GhoopManager GHM;
    public float speed;
    #endregion

    #region Start, Update, and Fixed Update Methods
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GHM = GameObject.Find("GhoopManager").GetComponent<GhoopManager>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;

        if (targetEnemy != null && Input.GetKeyDown(KeyCode.Space))
        {

            targetEnemy.GetComponent<basicAI>().stopWalking();
            targetEnemy.GetComponent<Animator>().SetBool("_isDead", true);
            targetEnemy.GetComponent<Animator>().SetBool("_isDead", false);
            targetEnemy.GetComponent<basicAI>().enabled = false;
            targetEnemy.tag = "Corpse";
            GHM.DisplayInteraction("");
            targetEnemy = null;
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }
    #endregion

    private void PlayWalkAudio()
    {
        if (AudioManager.Instance == null)
        {
            return;
        }
        AudioManager.Instance.PlaySound("Walk");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alive")
        {
            targetEnemy = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Alive")
        {
            GHM.DisplayInteraction("Press Space to kill");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Alive")
        {
            GHM.DisplayInteraction("");
        }
    }
}

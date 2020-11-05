using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    #region Varibales
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
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

        // Checks if there are no references to the Animator or Sprite Renderer before calling the AnimationCheck method.
        if (_anim == null || _spriteRenderer == null)
            {
                return;
            }
        else
            {
                AnimationCheck();
            }
        if (targetEnemy != null && Input.GetKeyDown(KeyCode.Space))
        {

            targetEnemy.GetComponent<basicAI>().stopWalking();
            targetEnemy.GetComponent<Animator>().SetBool("_isDead", true);
            //targetEnemy.GetComponent<basicAI>()._anim.SetBool("_isMoving", false);
            //targetEnemy.GetComponent<basicAI>()._anim.enabled = false;
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

    #region Other Methods
    // Method for checking conditions for the Animator
    private void AnimationCheck()
    {
        // Sets the Animator to idle if there is no movement detected.
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _anim.SetBool("_isMoving", true);
        }
        else
        {
            _anim.SetBool("_isMoving", false);
        }

        // Flips the Sprite Renderer in it's X-axis based on whether the player is moving left or right.
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _spriteRenderer.flipX = false;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

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
}

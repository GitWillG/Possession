using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    #region Start and Update Method
    // Start is called before the first frame update
    void Start()
    {
        this.Anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationCheck();
    }
    #endregion

    // Runs base AnimationCheck() method and checks for player input as well.
    protected override void AnimationCheck()
    {
        // Checks for references to Animator and SpriteRenderer
        base.AnimationCheck();

        // Checks for player input to determine which animation state is needed
        if (!NoAnimator)
        {
            // Sets the Animator to idle if there is no movement detected.
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                Anim.SetBool("_isMoving", true);
            }
            else
            {
                Anim.SetBool("_isMoving", false);
            }

            // Flips the Sprite Renderer in it's X-axis based on whether the player is moving left or right.
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                SpriteRenderer.flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                SpriteRenderer.flipX = false;
            }
        }
        else
        {
            Debug.Log("Either Animator or SpriteRenderer is null");
        }
    }
}

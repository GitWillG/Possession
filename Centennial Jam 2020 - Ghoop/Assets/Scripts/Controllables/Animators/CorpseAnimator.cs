using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseAnimator : EntityAnimator
{
    private basicAI basicAI;
    private playerController playerController;
    public  GameObject _target;

    #region Start and Update Methods
    // Start is called before the first frame update
    void Start()
    {
        basicAI = gameObject.GetComponent<basicAI>();
      
        this.Anim = gameObject.GetComponent<Animator>();
        this.SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

        // Checks for player movement if the references are not null and the PlayerController script is enabled
        if (!NoAnimator)
        {
            Anim.SetBool("_isDead", true);
            if (basicAI.isAlive)
            {
                Anim.SetBool("_isDead", false);

                if (basicAI.walking == true)
                {
                    Anim.SetBool("_isMoving", true);
                    if (basicAI.dir < 0)
                    {
                        SpriteRenderer.flipX = true;
                    }
                    else if (basicAI.dir > 0)
                    {
                        SpriteRenderer.flipX = false;
                    }
                }
            }

        }

        if (basicAI.dist <= 1f && basicAI.waiting == true)
        {
            Anim.SetBool("_isMoving", false);
        }

        if (!basicAI.isAlive)
        {
            Anim.SetBool("_isDead", true);
            basicAI.isAlive = false;
            basicAI.enabled = false;
        }
        
    }
}

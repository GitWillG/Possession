using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseAnimator : EntityAnimator
{
    private basicAI basicAI;
    private playerController playerController;

    #region Start and Update Methods
    // Start is called before the first frame update
    void Start()
    {
        basicAI = gameObject.GetComponent<basicAI>();
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
           
        }
        else
        {
            Debug.Log("Either Animator or SpriteRenderer is null");
        }

        // Checks for basicAI related animation calls

    }
}

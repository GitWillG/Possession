using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    [SerializeField]
    protected Animator Anim;
    [SerializeField]
    protected SpriteRenderer SpriteRenderer;

    protected bool NoAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    virtual protected void AnimationCheck()
    {
        // Checks if there are no references to the Animator or Sprite Renderer before calling the AnimationCheck method.
        if (Anim == null || SpriteRenderer == null)
        {
            return;
            NoAnimator = true;
        }
    }
}

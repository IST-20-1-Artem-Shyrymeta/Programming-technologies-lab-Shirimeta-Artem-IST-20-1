using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Anim_1 : MonoBehaviour
{
    public int animationReplyCount = 3;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimationPartEnd()
    {
        animationReplyCount--;
       
        if (animationReplyCount <= 0)
        {
            animator.Play("Anim");
        }
    }
}
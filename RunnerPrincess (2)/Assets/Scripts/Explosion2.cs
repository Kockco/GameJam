using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2 : MonoBehaviour
{
    Animator animator;
    BoxCollider2D myBox;
    public float[] boomTime;
    public float currentTime;
    int a,b;
    private void Start()
    {
        animator = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
        b = boomTime.Length;
        a = 0;
    }
    private void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            myBox.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.4f
            && animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            myBox.enabled = true;
        }
    }
    private void FixedUpdate()
    {
        currentTime += 1 * Time.fixedDeltaTime;
        if (currentTime > boomTime[a])
        {
            currentTime = 0;
            animator.SetTrigger("Boom");
            a++;
            if (a == b)
                a = 0;

        }
    }
}

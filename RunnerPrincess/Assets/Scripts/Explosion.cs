using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator animator;
    BoxCollider2D myBox;
    private void Start()
    {
        animator = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            Debug.Log("충돌불가");
            myBox.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            Debug.Log("충돌가능");
            myBox.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "Character")
        {
            Debug.Log("die");
        }
    }
}

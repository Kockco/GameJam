using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator animator;
    BoxCollider2D myBox;
    public float boomTime,
        currentTime;
    private void Start()
    {
        animator = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > boomTime)
        {
            currentTime = 0;
            animator.SetTrigger("Boom");
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            Debug.Log("충돌불가");
            myBox.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.4f
            && animator.GetCurrentAnimatorStateInfo(0).IsName("boom"))
        {
            Debug.Log("충돌가능");
            myBox.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "Character")
        {
            // if(애니 사망)
            // 몇초뒤 사라짐
            Debug.Log("die");

            collision.gameObject.SetActive(false);
        }
    }
}

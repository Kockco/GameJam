using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator animator;
    float exitTime = 0.8f;

    //IEnumerator CheckAnimationState()
    //{

    //    while (!animator.GetCurrentAnimatorStateInfo(0)
    //    .IsName("boom"))
    //    {

    //        Debug.Log("yes");
    //        //전환 중일 때 실행되는 부분
    //        yield return null;
    //    }

    //    while (animator.GetCurrentAnimatorStateInfo(0)
    //    .normalizedTime < exitTime)
    //    {
    //        Debug.Log("noani");
    //        //애니메이션 재생 중 실행되는 부분
    //        yield return null;
    //    }

    //    //애니메이션 완료 후 실행되는 부분

    //}

    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}
    //private void Update()
    //{
    //    StartCoroutine(CheckAnimationState());
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionControl : MonoBehaviour
{
    Animator animator;

    // 메소드 호출 시 CatchTrigger로 트리거 설정 -> 잡기 모션
    public void catchMotion()
    {
        animator.SetTrigger("CatchTrigger");
    }
    // 메소드 호출 시 OuchTrigger로 트리거 설정 -> 피격 모션
    public void ouchMotion()
    {
        animator.SetTrigger("OuchTrigger");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

}

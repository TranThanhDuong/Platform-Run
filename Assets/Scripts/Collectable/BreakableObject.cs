using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : TouchableObj
{
    public Animator animator;
    public Collider2D colObj;

    public override void SetUp(TouchableParam param)
    {

    }
    public override void OnTouchObj()
    {
        StartCoroutine(OnBreak());
    }

    public IEnumerator OnBreak()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetTrigger("Break");
        colObj.enabled = false;
        StartCoroutine(OnRespawn());
    }
    public IEnumerator OnRespawn()
    {
        yield return new WaitForSeconds(2);
        animator.SetTrigger("Idle");
        colObj.enabled = true;
    }
}

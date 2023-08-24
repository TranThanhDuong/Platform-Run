using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OpossumAttack : FSMState
{
    [NonSerialized]
    public OpossumControl parent;
    private float timeCount;
    private float timeLimit = 2f;
    public override void Enter(object data)
    {
        RaycastHit2D hit2D = (RaycastHit2D)data;
        hit2D.collider.GetComponent<PlayerControl>().OnTakeDamage(1);
        parent.databiding.Attack = true;
        timeCount = 0;
    }

    public override void FixedUpdate()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= 2)
        {
            parent.GotoState(parent.idleState);
        }    
        base.FixedUpdate();
    }
}

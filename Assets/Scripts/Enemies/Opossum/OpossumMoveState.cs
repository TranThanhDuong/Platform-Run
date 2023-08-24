using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OpossumMoveState : FSMState
{
    [NonSerialized]
    public OpossumControl parent;
   
    float timeCount = 0;
    public override void Enter()
    {
        timeCount = 0;
        if (UnityEngine.Random.value>0.5f)
        {
            parent.dir = 1;
        }
        else
        {
            parent.dir = -1;
        }
        if (parent.dir == -1)
        {
            parent.databiding.Move = 2;
        }
        else
        {
            parent.databiding.Move = 1;
        }
        base.Enter();
    }

    public override void Update()
    {
        parent.trans.Translate(parent.dir * Vector3.left * Time.deltaTime * 2f);
        if (parent.trans.position.x<parent.left_Limit.position.x||
        parent.trans.position.x > parent.right_Limit.position.x)
        {
            parent.dir = -parent.dir;
            if(parent.dir == -1)
            {
                parent.databiding.Move = 2;
            }
            else
            {
                parent.databiding.Move = 1;
            }
        }
        timeCount += Time.deltaTime;
        if(timeCount>3)
        {
            parent.GotoState(parent.idleState);
        }
    }
    public override void Exit()
    {
        parent.databiding.Move = 0;
        base.Exit();
    }
}

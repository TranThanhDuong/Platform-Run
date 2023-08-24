using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

[Serializable]
public class OpossumIdleState : FSMState
{
    [NonSerialized]
    public OpossumControl parent;
    private float timeCount;
    private float timeLimit;
    public override void Enter()
    {
        parent.databiding.Move = 0;
        timeCount = 0;
        timeLimit = Random.Range(2f, 4f);
        //UnityEngine.Random.Range(2, 4);2,3
        base.Enter();
    }
    public override void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if(timeCount>timeLimit)
        {
            parent.GotoState(parent.moveState);
        }
        base.FixedUpdate();
    }
}

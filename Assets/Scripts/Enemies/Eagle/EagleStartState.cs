using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EagleStartState : FSMState
{
    [NonSerialized]
    public EagleControl parent;
    private float timer = 0;
    private float timeCount;
    public override void Enter()
    {
        timer = 0;
        timeCount = 2;
        base.Enter();
    }
    public override void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer>timeCount)
        {
            parent.GotoState(parent.flyState);
        }
    }
    public override void Enter(object data)
    {
        timeCount = (float)data;
        timer = 0;
    }
}

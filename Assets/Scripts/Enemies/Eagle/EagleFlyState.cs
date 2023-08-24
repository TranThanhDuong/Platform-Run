using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EagleFlyState : FSMState
{
    [NonSerialized]
    public EagleControl parent;
    private int dir = 1;
    public override void Enter()
    {
        parent.databing.IsFly = true;
        dir= parent.trans.position.x < parent.transPlayer.position.x ? -1 :  1;
        parent.model.localScale = new Vector3(dir, 1, 1);

        parent.trans.position = new Vector3(parent.trans.position.x, UnityEngine.Random.Range(0.8f, 1.5f), 0);
    }
    public override void Update()
    {
        parent.trans.Translate(dir*Vector3.left * Time.deltaTime * 4f);
    }
  
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyDeadState : FSMState
{
    [NonSerialized]
    public EnemyControl parent;
    public override void Enter()
    {
        parent.gameObject.SetActive(false);
    }
}

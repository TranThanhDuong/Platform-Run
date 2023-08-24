using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogControl : EnemyControl
{
    public FrogDatabing databing;
    public EnemyDeadState deadState;
    public FrogIdleState idleState;
    public FrogJumpState jumpState;
    public override void Setup()
    {
        base.Setup();
        idleState.parent = this;
        AddState(idleState);

        deadState.parent = this;
        AddState(deadState);

        jumpState.parent = this;
        AddState(jumpState);
    }
}

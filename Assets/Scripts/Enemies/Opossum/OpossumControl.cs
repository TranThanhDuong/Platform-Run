using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumControl : EnemyControl
{
    public OpossumDatabiding databiding;
    public EnemyDeadState deadState;
    public OpossumMoveState moveState;
    public OpossumIdleState idleState;
    public OpossumAttack attackState;

    public Transform left_Limit;
    public Transform right_Limit;

    public LayerMask maskPlayer;
    public int dir = 1;

    public bool isAttack = false;
    public override void Setup()
    {
        base.Setup();

        idleState.parent = this;
        AddState(idleState);

        deadState.parent = this;
        AddState(deadState);

        moveState.parent = this;
        AddState(moveState);

        attackState.parent = this;
        AddState(attackState);

    }
    public override void SystemUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(trans.position, dir*Vector2.left, 1, maskPlayer);

        if(hit2D.collider!=null)
        {
            if (currentState != attackState)
            {
                GotoState(attackState, hit2D);
            }
        }
    }
    public override void OnHitPlayer()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(trans.position, dir * Vector2.left, 1, maskPlayer);

        if (hit2D.collider == null)
        {
            if (currentState != deadState)
                GotoState(deadState);
        }
    }
}

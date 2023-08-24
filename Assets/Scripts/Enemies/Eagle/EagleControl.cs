using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl : EnemyControl
{
    public EagleDatabing databing;
    public EnemyDeadState deadState;
    public EagleFlyState flyState;
    public EagleStartState startState;
    public Transform transPlayer;
    public override void Setup()
    {
        base.Setup();
        transPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        startState.parent = this;
        AddState(startState);

        deadState.parent = this;
        AddState(deadState);

        flyState.parent = this;
        AddState(flyState);


    }
    public override void OnHitPlayer()
    {
        GotoState(deadState);
    }
    public override void OnHide()
    {
        float timer = UnityEngine.Random.Range(4f, 10f);
        GotoState(startState, timer);
        base.OnHide();
    }
    public override void OnShow()
    {

        base.OnShow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            collision.GetComponent<PlayerControl>().OnTakeDamage(1);
        }
    }
}

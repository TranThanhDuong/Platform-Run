using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : FSMSystem
{
    public GameObject effectDead;
    public Transform model;
    [System.NonSerialized]
    public Transform trans;

    private void Start()
    {
        Setup();
    }
    public virtual void Setup()
    {
        trans = transform;
    }
    public virtual void OnHitPlayer()
    {

    }
    public virtual void OnHide()
    {

    }
    public virtual void OnShow()
    {

    }
}

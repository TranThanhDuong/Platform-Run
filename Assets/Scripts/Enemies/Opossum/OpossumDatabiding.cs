using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumDatabiding : MonoBehaviour
{
    public Animator animator;
    public float Move
    {
        set
        {
            animator.SetFloat(key_Move, value);
        }
    }
    public bool Attack
    {
        set
        {
            if (value)
                animator.SetTrigger(key_Attack);
        }
    }
    private int key_Move;
    private int key_Attack;
    // Start is called before the first frame update
    void Start()
    {
        key_Move = Animator.StringToHash("Move");
        key_Attack = Animator.StringToHash("Attack");
    }

}

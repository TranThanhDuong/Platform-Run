using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBiding : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform model;

    public float Speed
    {
        set
        {
            animator.SetFloat(key_Speed, Mathf.Abs(value));
            if(value>0)
            {
                model.localScale = new Vector3(1, 1, 1);
            }
            else if (value < 0)
            {
                model.localScale = new Vector3(-1, 1, 1);
            }
        }
        get
        {
            return model.localScale.x;
        }
    }
    public float JumpForce
    {
        set
        {
            animator.SetFloat(key_JumpForce, -value/6f);
           
        }
    }
    public bool IsGround
    {
        set
        {
            animator.SetBool(key_IsGround,value);

        }
    }
    public bool IsLadder
    {
        set
        {
            animator.SetBool(key_IsLadder, value);

        }
    }
    public float SpeedLadder
    {
        set
        {
            animator.SetFloat(key_SpeedLadder, value);

        }
    }

    public bool IsTakingDamage
    {
        set
        {
            if(value)
                animator.SetTrigger(key_IsTakingDamage);
        }
    }


    // Start is called before the first frame update
    private int key_Speed;
    private int key_JumpForce;
    private int key_IsGround;
    private int key_SpeedLadder;
    private int key_IsLadder;
    private int key_IsTakingDamage;
    void Start()
    {
        key_Speed = Animator.StringToHash("Speed"); 
        key_JumpForce= Animator.StringToHash("JumpForce");
        key_IsGround = Animator.StringToHash("IsGround");
        key_SpeedLadder = Animator.StringToHash("SpeedLadder");
        key_IsLadder = Animator.StringToHash("IsLadder");
        key_IsTakingDamage = Animator.StringToHash("IsTakingDamage");
    }


}

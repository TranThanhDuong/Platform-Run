using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleDatabing : MonoBehaviour
{
    public Animator animator;
    public bool IsFly
    {
        set
        {
            animator.SetBool(key_Fly, value);
        }
    }
    private int key_Fly;
    // Start is called before the first frame update
    void Start()
    {
        key_Fly = Animator.StringToHash("IsFly");
    }

   
}

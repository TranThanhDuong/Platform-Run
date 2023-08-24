using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 moveDir = Vector2.zero;
    public int moveX = 0;
    public int moveY = 0;
    public bool isMove = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") + moveX;
        float y = Input.GetAxis("Vertical") + moveY;
        moveDir = new Vector2(x, y);

        if (!isMove)
            moveDir = Vector2.zero;
    }
}

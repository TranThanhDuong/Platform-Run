using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public InputManager input;
    public int x = 0;
    public int y = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (x != 0)
            input.moveX = x;

        if (y != 0)
            input.moveY = y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (x != 0)
            input.moveX = 0;

        if (y != 0)
            input.moveY = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(-Vector2.up * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("OnCollisionEnter2D");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.LogError("OnCollisionExit2D");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.LogError("OnCollisionStay2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("OnTriggerEnter2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.LogError("OnTriggerExit2D");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogError("OnTriggerStay2D");
    }
}

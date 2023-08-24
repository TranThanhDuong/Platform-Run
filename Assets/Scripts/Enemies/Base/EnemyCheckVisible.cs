using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckVisible : MonoBehaviour
{
    private EnemyControl parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.GetComponentInParent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        parent.OnHide();
    }

    private void OnBecameVisible()
    {
        parent.OnShow();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>: MonoBehaviour where T : MonoBehaviour
{
    private static T instances_;
    public static T instances
    {
        get
        {
            if(instances_ == null)
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<T>();
                gameObject.name = typeof(T).ToString();
                instances_ = gameObject.GetComponent<T>();
            }    
            return instances_;
        }
    }

    private void Awake()
    {
        instances_ = gameObject.GetComponent<T>();
        OnAwake();
    }
    public virtual void OnAwake()
    {

    }
    private void Reset()
    {
        gameObject.name = typeof(T).ToString();
    }
}

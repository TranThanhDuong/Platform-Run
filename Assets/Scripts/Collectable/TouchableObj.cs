using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableParam
{
    public PlayerControl player;
}
public class TouchableObj : MonoBehaviour
{
    public TouchableObjType typeCollect;
    public PlayerControl player;
    public virtual void SetUp(TouchableParam param)
    {

    }
    public virtual void OnTouchObj()
    {

    }
    public virtual IEnumerator DistroyThis()
    {
        yield return new WaitForSeconds(1);
    }    
}

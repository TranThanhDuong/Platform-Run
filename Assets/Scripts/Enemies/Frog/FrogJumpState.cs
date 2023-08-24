using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FrogJumpState : FSMState
{
    [NonSerialized]
    public FrogControl parent;

}

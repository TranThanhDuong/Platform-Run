using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    private List<FSMState> states= new List<FSMState>();
    public FSMState currentState;
    // Start is called before the first frame update
    public void AddState(FSMState state_)
    {
        states.Add(state_);
        if(states.Count==1)
        {
            currentState = state_;
            currentState.Enter();
        }
    }
    public void GotoState(FSMState newState)
    {
        if(currentState!=null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter();
    }
    public void GotoState(FSMState newState,object data)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(data);
    }
    // Update is called once per frame
    void Update()
    {
        if(currentState!=null)
        {
            currentState.Update();
        }
        SystemUpdate();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdate();
        }
        SystemFixedUpdate();
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.LateUpdate();
        }
        SystemLateUpdate();
    }
    public virtual void SystemUpdate()
    {

    }
    public virtual void SystemLateUpdate()
    {

    }
    public virtual void SystemFixedUpdate()
    {

    }
}

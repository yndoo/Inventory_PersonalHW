using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    protected IState currentState;

    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }
    
    public void Update()
    {
        currentState?.Update();
    }
}

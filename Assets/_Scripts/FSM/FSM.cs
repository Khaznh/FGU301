using UnityEngine;

public class FSM
{
    public State currentState;

    public FSM()
    {

    }

    public void Init(State startState)
    {
        currentState = startState;
    }

    public void ChangeState(State nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();
    }
}

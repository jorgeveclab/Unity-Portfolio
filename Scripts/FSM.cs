using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FSM 
{
    protected bool get_in = true;
    protected bool get_out = false;

    protected State _currentState;
    public State CurrentState => _currentState;
    protected State _lastState;
    public State LastState => _lastState;
    protected State _nextState;

    public void FSMLoop()
    {
        if (get_in)
        {
            _currentState.EnterState();
            get_in = false;
        }
        _currentState.UpdateState();
    }

    public void HandleTransitions()
    {
        _currentState.HandleTransition();

        if(get_out)
        {
            _currentState.ExitState();
            get_out = false;
            get_in = true;
           
            ChangeState();
        }
    }

    public void ChangeState()
    {
        _currentState = _nextState;
    }

    //set the next state to switch into and prepare ExitState() function
    public void SetNextState(State nextState, State lastState)  
    {
        _lastState = lastState;
        _nextState = nextState;
        get_out = true;
    }
}


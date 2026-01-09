using UnityEngine;

public class State 
{
    protected FSM _fsm;
    protected string _stateName, _flagIn = "in", _flagOut = "out";
    private bool _showFlags;
    public State(){}
    public State(FSM fsm, bool showFlags){ 
        _fsm = fsm;
        _showFlags = showFlags; 
        }

    
    public virtual void EnterState()
    {
        if(_showFlags) Debug.Log(_stateName + " " + _flagIn);
    }

    public virtual void UpdateState()
    {
        
    }
    public virtual void ExitState()
    {
        if(_showFlags) Debug.Log(_stateName + " " + _flagOut);
    }
    public virtual void HandleTransition()
    {
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class MState_OnAir_JUMP : MovementState
{
    IActionCommand _jumpAction;
    IActionCommand _fallAction;

    public MState_OnAir_JUMP(MovementFSM fsm, IActionCommand jumpAction, IActionCommand fallAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Jump";
        _jumpAction = jumpAction;
        _fallAction = fallAction;
    }

      public override void EnterState()
    {
        base.EnterState();
        _jumpAction.Execute();
    }

    public override void UpdateState()
    {
        _fallAction.Execute();
    }

    public override void HandleTransition()
    {
        base.HandleTransition();
    
        if(Fsm.Flags.IsGrounded == false )
        { 
            Fsm.SetNextState(Fsm.FallState, this);
        }
    }
    public override void ExitState()
    {
        base.ExitState();
    }
}

using UnityEngine;

public class MState_Move_SPRINT : MovementState
{
    public MState_Move_SPRINT(MovementFSM fsm, IActionCommand sprintAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Sprint";
        _moveAction = sprintAction as AC_Move;
    }

     public override void EnterState()
    {
        base.EnterState();
        Fsm.FallState.SetSpeed( _moveAction.GetSpeed(),  _moveAction.GetLerpTime());
    }

    public override void UpdateState()
    {
        _moveAction.Execute();
    }

    public override void HandleTransition()
    {
        base.HandleTransition();
        TransitToCrouchStates();

        if (Fsm.Flags.IsJumping)
        {
            Fsm.SetNextState(Fsm.JumpState, this);
        }
        if(Fsm.Flags.IsSprinting == false)
        {
            TransitToMoveStates();
        }
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

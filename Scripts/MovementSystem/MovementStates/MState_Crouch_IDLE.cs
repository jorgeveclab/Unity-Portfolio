using UnityEngine;

public class MState_Crouch_IDLE : MovementState
{
    public MState_Crouch_IDLE(MovementFSM fsm, IActionCommand walkAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Crouch Idle";
        _moveAction = walkAction as AC_Move;
    }

      public override void UpdateState()
    {
        _moveAction.Execute();
    }

    public override void HandleTransition()
    {
        base.HandleTransition();

        if(Fsm.Flags.IsCrouching == true)
        {
            TransitToMoveStates();
        }
        if(Fsm.Flags.IsIdling == false)
        {
            Fsm.SetNextState(Fsm.CrouchWalkState, this);
        }
         if(Fsm.Flags.IsGrounded == false )
        { 
            Fsm.SetNextState(Fsm.FallState, this);
        }
    }
}

using UnityEngine;

public class MState_Crouch_WALK : MovementState
{
    public MState_Crouch_WALK (MovementFSM fsm, IActionCommand walkAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Crouch Walk ";
        _moveAction = walkAction as AC_Move;
    }

      public override void UpdateState()
    {
        _moveAction.Execute();
    }

       public override void HandleTransition()
    {
        base.HandleTransition();

        if(Fsm.Flags.IsGrounded == false )
        { 
            Fsm.SetNextState(Fsm.FallState, this);
        }
        if(Fsm.Flags.IsCrouching == true)
        {
            TransitToMoveStates();
        }
         if(Fsm.Flags.IsIdling == true)
        {
            Fsm.SetNextState(Fsm.CrouchIdleState, this);
        }
        
    }
}

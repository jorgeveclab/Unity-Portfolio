using UnityEngine;

public class MState_Move_WALK : MovementState
{
    public MState_Move_WALK(MovementFSM fsm, IActionCommand walkAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Walk";
        _moveAction = walkAction as AC_Move;
    }
     public override void EnterState()
    {
        base.EnterState();
        Fsm.FallState.SetSpeed( _moveAction.GetSpeed() * 1.5f,  _moveAction.GetLerpTime());
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
        if(Fsm.Flags.IsIdling == true)
        {
            Fsm.SetNextState(Fsm.IdleState, this);
        }
        if(Fsm.Flags.IsRunning == true)
        {
            Fsm.SetNextState(Fsm.RunState, this);
        }
        if(Fsm.Flags.StartSprinting == true)
        {
            Fsm.SetNextState(Fsm.SprintState, this);
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
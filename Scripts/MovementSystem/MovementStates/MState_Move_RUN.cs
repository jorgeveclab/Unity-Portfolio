using UnityEngine;

public class MState_Move_RUN : MovementState
{
    public MState_Move_RUN(MovementFSM fsm, IActionCommand runAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Run";
        _moveAction = runAction as AC_Move;
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
        if(Fsm.Flags.IsWalking == true)
        {
            Fsm.SetNextState(Fsm.WalkState, this);
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

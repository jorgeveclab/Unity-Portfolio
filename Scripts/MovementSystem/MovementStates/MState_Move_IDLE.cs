using UnityEngine;

public class MState_Move_IDLE : MovementState
{
    public MState_Move_IDLE(MovementFSM fsm, IActionCommand idleAction, bool showFlags) : base(fsm,showFlags)
    {
        
        _stateName = "Idle ";
        _moveAction = idleAction  as AC_Move;
    }

    public override void EnterState()
    {
        base.EnterState();
        Fsm.FallState.SetSpeed( _moveAction.GetSpeed(),  _moveAction.GetLerpTime());//move this line to parent class

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
         if(Fsm.Flags.IsRunning == true)
        {
            Fsm.SetNextState(Fsm.RunState, this);
        }
         if(Fsm.Flags.IsGrounded == false )
        { 
            Fsm.SetNextState(Fsm.FallState, this);
        }
         if(Fsm.Flags.IsRunning == true)
        {
            Fsm.SetNextState(Fsm.RunState, this);
        }
    }
    public override void ExitState()
    {
        base.ExitState();
    }

}
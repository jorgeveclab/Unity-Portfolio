using UnityEngine;

public class MState_OnAir_FALL : MovementState
{
    AC_ApplyGravity _fallAction;
  

    public MState_OnAir_FALL(MovementFSM fsm, ActionCommand fallAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Fall ";
        _fallAction = fallAction as AC_ApplyGravity;
    }
    
      public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        _fallAction.Execute();
    }

    public override void HandleTransition()
    {
        base.HandleTransition();

        if(Fsm.Flags.IsGrounded == true )
        {
            Fsm.SetNextState(Fsm.LandState, this);
        }
         if (Fsm.Flags.IsJumping && Fsm.Flags.IsFalling)
        {
            Fsm.SetNextState(Fsm.JumpState, this);
        }
    }
    public override void ExitState()
    {
        base.ExitState(); 
    }
     public void SetSpeed(float speed, float lerp)
    {
        _fallAction.UpdateMovementSpeed(speed, lerp);
    }
}

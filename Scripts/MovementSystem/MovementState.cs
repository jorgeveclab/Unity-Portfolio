using UnityEngine;

public class MovementState : State
{
    protected MovementFSM Fsm {get {return _fsm as MovementFSM;}}
    protected AC_Move _moveAction;
    public MovementState() {}
    public MovementState(MovementFSM fsm, bool showFlags) : base(fsm, showFlags) {}

    public override void ExitState()
    {
        base.ExitState();
        
    }
    //It check for transitions to grounded states except SprintState since it has special conditions
    //Any of these grounded states can be accesed when on ground depending on joystick pressure
    //SprintState can only be accesed through these grounded states but not by Jump, Fall or Crouch states, for example
    protected void TransitToMoveStates()
    {
        if(Fsm.Flags.IsWalking == true)
        {
            Fsm.SetNextState(Fsm.WalkState, this);
        }
         if(Fsm.Flags.IsRunning == true)
        {
            Fsm.SetNextState(Fsm.RunState, this);
        }
         if(Fsm.Flags.IsIdling == true)
        {
            Fsm.SetNextState(Fsm.IdleState, this);
        }
    }
    protected void TransitToCrouchStates()
    {
        if(Fsm.Flags.IsCrouching == true)
        {
            if(Fsm.Flags.IsIdling)
                Fsm.SetNextState(Fsm.CrouchIdleState, this);
            else Fsm.SetNextState(Fsm.CrouchWalkState, this);
        }
        
    }
}



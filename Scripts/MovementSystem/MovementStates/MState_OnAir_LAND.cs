
public class MState_OnAir_LAND : MovementState
{
    Timer _landTimer;
    bool changeState = false;
    IActionCommand _landAction;

    public MState_OnAir_LAND(MovementFSM fsm, IActionCommand landAction, bool showFlags) : base(fsm,showFlags)
    {
        _stateName = "Land";
        _landAction = landAction;
        _landTimer = new Timer(.08f, () => changeState = true);
    }

    public override void EnterState()
    {
        base.EnterState();
        changeState = false;
        _landTimer.ResetTime();
        TimerManager.timerManager.AddTimer(_landTimer);
    }

    public override void UpdateState()
    {
        _landAction.Execute();
    }

    public override void HandleTransition()
    {
        base.HandleTransition();

        if(changeState == true )
        {
            Fsm.SetNextState(Fsm.IdleState, this);
        }
    }
    public override void ExitState()
    {
        base.ExitState();
    }
}

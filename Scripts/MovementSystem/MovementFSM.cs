//This FSM is on charge of manage the states dedicated to the movement 
//It can be used with any entity or agent who implement this class

public class MovementFSM : FSM
{    
    private IMovement _movement;
    public IMovement Movement => _movement;
    private IMovementFlags _flags;
    public IMovementFlags Flags => _flags;
  
  
    private MState_Move_WALK _walkState;      public MState_Move_WALK WalkState => _walkState;
    private MState_Move_IDLE _idleState;      public MState_Move_IDLE IdleState => _idleState;
    private MState_Move_RUN _runState;        public MState_Move_RUN RunState => _runState;
    private MState_Move_SPRINT _sprintState;  public MState_Move_SPRINT SprintState => _sprintState;
    private MState_OnAir_JUMP _jumpState;     public MState_OnAir_JUMP JumpState => _jumpState;
    private MState_OnAir_FALL _fallState;     public MState_OnAir_FALL FallState => _fallState;
    private MState_OnAir_LAND _landState;      public MState_OnAir_LAND LandState => _landState;
    private MState_Crouch_IDLE _crouchIdleState;    public MState_Crouch_IDLE CrouchIdleState => _crouchIdleState;
    private MState_Crouch_WALK _crouchWalkState;    public MState_Crouch_WALK CrouchWalkState => _crouchWalkState;

    private AC_Move _walkingAction;
    private AC_Move _runningAction;
    private AC_Move _sprintingAction;
    private AC_Move _idlingAction;
    private AC_Jump _jumpAction;
    private AC_ApplyGravity _fallAction;
    
    //Contructor initialize all the states. 
    public MovementFSM(IMovement movement, IMovementFlags flags, EntityAttributes attributes, bool showFlags)
    {
        _movement = movement;
        _flags = flags;
        
        //Create the ActionCommand classes that execute behavior (command pattern)
        _walkingAction = new AC_Move(
            _movement, attributes.walkSpeed, EasingFunctions.EaseInCubic(attributes.walkLerp));
        _runningAction = new AC_Move(
            _movement, attributes.runSpeed, EasingFunctions.EaseInCubic(attributes.runLerp));
        _sprintingAction = new AC_Move(
            _movement, attributes.sprintSpeed, EasingFunctions.EaseInCubic(attributes.sprintLerp));
        _idlingAction = new AC_Move(
            _movement, 0, EasingFunctions.EaseOutCubic(attributes.idlingLerp));

        _jumpAction = new AC_Jump(
            _movement, attributes.jumpHeight, attributes.gravity);
        _fallAction = new AC_ApplyGravity(
           _movement, attributes.jumpHeight, attributes.gravity, attributes.runSpeed, EasingFunctions.EaseInCubic(attributes.runLerp));

        //Instantiate the movement states. Their parameters are the ActionCommands needed to execute each state
        
        _idleState = new (this,_idlingAction, showFlags);
        _walkState = new (this,_walkingAction, showFlags);
        _runState = new (this, _runningAction ,showFlags);
        _sprintState = new (this, _sprintingAction, showFlags);

        _jumpState = new (this,_jumpAction, _fallAction, showFlags);
        _fallState = new (this, _fallAction, showFlags);
        _landState = new (this,_idlingAction, showFlags);

        _crouchIdleState = new(this, _idlingAction, showFlags);
        _crouchWalkState = new(this,_walkingAction, showFlags);

        _lastState = _runState;
        _currentState = _fallState;
    }
}
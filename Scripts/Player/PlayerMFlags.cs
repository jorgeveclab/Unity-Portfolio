
using UnityEngine;

public class PlayerMFlags : IMovementFlags
{
    CharacterController _controller;
    InputHandler _input;

    public bool IsGrounded{get;set;}
    public bool IsJumping {get;set;}
    public bool IsFalling {get;set;}
    public bool IsIdling{get;set;}
    public bool IsWalking {get;set;}
    public bool IsRunning {get;set;}
    public bool StartSprinting {get;set;}
    public bool IsSprinting {get;set;}
    public bool StartCrouching {get;set;}
    public bool IsCrouching {get;set;}

    private bool _stillOnGround = false;
    private Timer _coyoteTimer ;

      public PlayerMFlags(CharacterController controller, InputHandler input)
    {
        _controller = controller;
        _input = input;

        _coyoteTimer = new(0.2f,() =>  _stillOnGround = false);
    }

    public void UpdateFlags()
    {
        IsGrounded = _controller.isGrounded ;

        if(IsGrounded) 
            _stillOnGround = true;
        else if(!TimerManager.timerManager.Timers.Contains(_coyoteTimer))
            _coyoteTimer.RestartTimer();
        
        IsJumping = _input.BELLOW_button && (IsGrounded == true || _stillOnGround == true);
        IsCrouching = _input.RIGHT_button && IsGrounded == true;
        IsFalling = !_controller.isGrounded && _controller.velocity.y <= 0;
        IsIdling = _input.LEFT_JoystickValue.magnitude < 0.01f;
        IsWalking = _input.LEFT_JoystickValue.magnitude >= 0.01f && _input.LEFT_JoystickValue.magnitude < 0.8f;
        IsRunning = _input.LEFT_JoystickValue.magnitude >= 0.8f;
        StartSprinting = !IsIdling && _input.LEFT_JoystickButton;
        IsSprinting = _input.LEFT_JoystickValue.magnitude >= 0.95f;

    }

}

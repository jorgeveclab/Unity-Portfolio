//PlayerBehavior_Animator is in charge of updating the player animations

using UnityEngine;

public class PlayerBehavior_Animator 
{   
    public float GroundedSpeed{get;set;}
    public float OnAirSpeed{get;set;}
    private Animator _animator;
    private bool _isGrounded;
    private bool _isCrouching;

    int _isGroundedHash = Animator.StringToHash("IsGrounded");
    int _speedHash = Animator.StringToHash("Speed");
    int _jumpVelocityHash = Animator.StringToHash("JumpVelocity");
    int _crouchHash = Animator.StringToHash("Crouch");

    public PlayerBehavior_Animator(Animator animator)
    {
        _animator = animator;
    }
   
    public void UpdateAnimator(bool isGrounded, bool IsCrouching, float joyStickPressure, bool isSprinting, float x, float y)
    {
        if(_isGrounded != isGrounded)
        {
            _isGrounded = isGrounded;
            _animator.SetBool(_isGroundedHash, _isGrounded); 
        }
        if(_isCrouching != IsCrouching)
        {
            _isCrouching = IsCrouching;
            _animator.SetBool(_crouchHash, _isCrouching); 
        }
        
        if (_isGrounded)
        {
            if(_isCrouching) UpdateCrouchAnimations(joyStickPressure);
            else UpdateMoveAnimations(joyStickPressure, isSprinting);
        }
        else
        {
            float target;
            if (y > 0f) target = 1;
            else target = 0;
            _animator.SetFloat(_jumpVelocityHash, OnAirSpeed);
            // Debug.Log(OnAirSpeed);
            
            OnAirSpeed = Mathf.Lerp(OnAirSpeed, target, .05f);
        }  
    }

    public void UpdateMoveAnimations(float joyStickPressure, bool isSprinting)
    {
        // if (isSprinting) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 6.5f, .1f); 
        // //the movement Blend Tree changes its states based on joystick pressure
        // //there are four states with fixed speed so the blend occurs by linear interpolation
        // else if (joyStickPressure > 1.9f) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 4.2f, .15f);
        // else if(joyStickPressure > 1f) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 2f, .1f);
        // else if(joyStickPressure > 0.01f) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 1f, .2f);
        // else GroundedSpeed = Mathf.Lerp(GroundedSpeed, 0f, .2f);

        GroundedSpeed = Mathf.Lerp(GroundedSpeed, joyStickPressure, .15f); 
        _animator.SetFloat(_speedHash, GroundedSpeed);   
    }
    public void UpdateCrouchAnimations(float joyStickPressure)
    {
        //the movement Blend Tree changes its states based on joystick pressure
        //there are four states with fixed speed so the blend occurs by linear interpolation
        if(joyStickPressure > 0.01f) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 1f, .1f);
        else
        {
            GroundedSpeed = Mathf.Lerp(GroundedSpeed, 0f, EasingFunctions.EaseInCubic(.5f));
            if(GroundedSpeed <= 0.4f) GroundedSpeed = Mathf.Lerp(GroundedSpeed, 0f, .3f);
        }
        
        _animator.SetFloat(_speedHash, GroundedSpeed);   
    }
}

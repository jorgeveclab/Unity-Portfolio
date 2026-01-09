using UnityEngine;

public interface IMovementFlags
{
    public bool IsGrounded{get;set;}
    
    public bool IsJumping {get;set;}
    public bool IsFalling {get;set;}
    public bool IsIdling {get;set;}
    public bool IsWalking {get;set;}
    public bool IsRunning {get;set;}
    public bool IsSprinting {get;set;}  
    public bool StartSprinting {get;set;}  
    public bool StartCrouching {get;set;}
    public bool IsCrouching {get;set;}
    
}

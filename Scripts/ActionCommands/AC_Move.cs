using UnityEngine;

//AC_Move is used to translate the player or any other entity with a IMovement implementation
public class AC_Move : ActionCommand
{
    IMovement _movement;
    public float _movingSpeed;
    float _movingLerp;
    
    public AC_Move(IMovement movement, float moveSpeed, float movingLerp)
    {
        _movement = movement;
        _movingSpeed = moveSpeed;
        _movingLerp = movingLerp;
    }
    public override void Execute()
    {   
        _movement.YSpeed = -2;

        Vector3 targetVelocity =_movement.Direction * _movingSpeed ;
        Vector3 velocity = Vector3.MoveTowards(_movement.Velocity, targetVelocity, _movingLerp);
        _movement.Velocity = velocity;
    }

    public float GetSpeed() => _movingSpeed;
    public float GetLerpTime() => _movingLerp;
}
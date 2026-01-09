using UnityEngine;

public class AC_ApplyGravity : ActionCommand
{
    IMovement _movement;
    float _gravity;
    float _gravityDifference = .5f;

    public float _movingSpeed;
    float _movingLerp;
 
     public AC_ApplyGravity(IMovement movement, float jumpHeight,float gravity, float movingSpeed,  float movingLerp, float timeToPeak =.25f )
    {
        _movement = movement;
        _gravity = gravity;
        _gravity = -2 * jumpHeight / Mathf.Pow(timeToPeak, 2);

        _movingSpeed = movingSpeed;
        _movingLerp = movingLerp;
    }

    public override void Execute()
    {   
        //_movement.Y_Velocity += _gravity    * Time.deltaTime;
        if(_movement.YSpeed > .1f) _movement.YSpeed += (_gravity  + _gravityDifference)  * Time.deltaTime;
        if(_movement.YSpeed <= .1f && _movement.YSpeed >= -.1f) _movement.YSpeed += _gravity   * Time.deltaTime;
        else if (_movement.YSpeed < -.1f) _movement.YSpeed += (_gravity  - _gravityDifference)  * Time.deltaTime;

        Vector3 directionRange = new(
            Mathf.Clamp(_movement.Direction.x, _movement.Velocity.normalized.x - .2f, _movement.Velocity.normalized.x + .2f),
            0,
            Mathf.Clamp(_movement.Direction.z, _movement.Velocity.normalized.z - .2f, _movement.Velocity.normalized.z + .2f)
        );

        Vector3 targetVelocity = directionRange * _movingSpeed;
        Vector3 velocity = Vector3.Lerp(_movement.Velocity, targetVelocity, _movingLerp);
        _movement.Velocity = velocity;
    }

    public void GroundConctact()
    {
        _movement.Velocity = Vector3.zero;
    }
    public void UpdateMovementSpeed(float movingSpeed,  float movingLerp)
    {
        _movingSpeed = movingSpeed;
        _movingLerp = movingLerp;
    }
}

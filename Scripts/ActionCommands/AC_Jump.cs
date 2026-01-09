using UnityEngine;

//AC_Jump is used to execute a jump by the player or any other entity which implements IMovement 
public class AC_Jump : ActionCommand
{
    IMovement _movement;
    float _jumpHeight;
    float jumpVelocity;
    float _gravity;
 
     public AC_Jump(IMovement movement, float jumpHeight,float gravity, float timeToPeak =.25f )
    {
        _movement = movement;
        _jumpHeight = jumpHeight;
        _gravity = gravity;

        jumpVelocity = 2 * jumpHeight / timeToPeak;
    }

    public override void Execute()
    {   
        _movement.YSpeed = jumpVelocity;
        //Debug.Log(_movement.Y_Velocity / Mathf.Abs(_gravity));
    }
}
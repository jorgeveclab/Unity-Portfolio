//It implements IMovement interface which it is shared with other entities that use a FSM to manage their movement 
//
using UnityEngine;

public class PlayerBehavior_Movement : IMovement
{
    public Vector3 Velocity {get; set;}  //
    public float YSpeed {get; set;}  //IMovement velocity is equal to controller velocity
    public Vector3 Direction 
    {
        get
        {
            Vector3 dirForward = new Vector3
                (Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

            Vector3 dirRight = new Vector3
                (Camera.main.transform.right.x, 0, Camera.main.transform.right.z);

            dirForward *= _input.LEFT_JoystickValue.y;
            dirRight *= _input.LEFT_JoystickValue.x;

            return (dirForward + dirRight).normalized;
        }
    }

    private CharacterController _controller;
    public CharacterController Controller => _controller;
    private InputHandler _input;
    
    public PlayerBehavior_Movement(CharacterController controller, InputHandler input)
    {
        _controller = controller;
        _input = input;
    }
    public void MoveBody(Vector3 velocity)
    {
        Velocity = velocity;
    }
}

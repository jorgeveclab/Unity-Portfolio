using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    InputAction sprintAction;
    InputAction crouchAction;

    private bool _bellow_button;                    public bool BELLOW_button => _bellow_button;
    private bool _right_button;                     public bool RIGHT_button => _right_button;
    private bool _left_JoystickButton;              public bool LEFT_JoystickButton => _left_JoystickButton;
    private Vector2 _left_JoystickValue;            public Vector2 LEFT_JoystickValue  => _left_JoystickValue;
    private static float _left_JoystickPressure;    public static float LEFT_JoystickPressure  => _left_JoystickPressure;


    public void Awake()
    {
          moveAction = InputSystem.actions.FindAction("Move");
          jumpAction = InputSystem.actions.FindAction("Jump");
          sprintAction = InputSystem.actions.FindAction("Sprint");
          crouchAction = InputSystem.actions.FindAction("Crouch");
    }
   
    public void HandleInput()
    {
        // 4. Read the "Move" action value, which is a 2D vector
        // and the "BELLOW_button" action state, which is a boolean value

        _left_JoystickValue = moveAction.ReadValue<Vector2>();
        // your movement code here
        _left_JoystickPressure = _left_JoystickValue.magnitude;
        _bellow_button = jumpAction.WasPressedThisFrame();
        _left_JoystickButton = sprintAction.IsPressed();
        _right_button = crouchAction.WasPressedThisFrame();
    }
}

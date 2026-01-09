using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Skaillz.EditInline;

public class PlayerController : MonoBehaviour
{
    [Header("Testing")]
    public bool  showStateFlags;

    //MONOBEHAVIOR
    private InputHandler _inputComponent;
    private CharacterController _controller;
    private Animator _animator;
   
    private Vector3 _colliderCenter;
    private float _colliderHeihgt;
    private Vector3 _colliderCrouchCenter;
    private float _colliderCrouchHeihgt = 1.2f;

    //FSM COMPONENTS
    private MovementFSM _fsm;
    private PlayerMFlags _flags;
    private PlayerBehavior_Movement _movementBehavior;
    private PlayerBehavior_Animator _animatorBehavior;

    //PLAYER DATA
    [EditInline]public PlayerAttributes attributes;

    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputComponent = GetComponent<InputHandler>();
        _animator = GetComponent<Animator>();
        

        _movementBehavior = new(_controller, _inputComponent);
        _flags = new(_controller, _inputComponent);
        _animatorBehavior = new(_animator);

        _fsm = new (_movementBehavior, _flags, attributes, showStateFlags);

        _colliderCenter = _controller.center;
        _colliderHeihgt = _controller.height;

        _colliderCrouchCenter = _controller.center;
        _colliderCrouchCenter.y = -0.4f;
        
        
    }

    void FixedUpdate()
    {
        if(_inputComponent.LEFT_JoystickValue.magnitude > 0.01f)
        {
            Quaternion q = Quaternion.LookRotation(_movementBehavior.Direction, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, 0.8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _inputComponent.HandleInput();
        _fsm.FSMLoop();
        _flags.UpdateFlags();
        _fsm.HandleTransitions();

        bool isCrouching = _fsm.CurrentState == _fsm.CrouchIdleState || _fsm.CurrentState == _fsm.CrouchWalkState;
        SetStateCollider(isCrouching);

        _controller.Move((_fsm.Movement.Velocity + Vector3.up * _fsm.Movement.YSpeed) * Time.deltaTime);

        
                


       
        Debug.Log(_controller.velocity.magnitude);
       
        _animatorBehavior.UpdateAnimator(
           _controller.isGrounded,
           isCrouching,
           _controller.velocity.magnitude,
           _fsm.CurrentState == _fsm.SprintState,
           _controller.velocity.x,
           _controller.velocity.y);

    }

    private void SetStateCollider(bool b)
    {
        if (b)
        {
            _controller.center = _colliderCrouchCenter;
            _controller.height = _colliderCrouchHeihgt;
        }
        else
        {
            _controller.center = _colliderCenter;
            _controller.height = _colliderHeihgt;
        }
    }
}
    




using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Scriptable Objects/PlayerAttributes")]
public class PlayerAttributes : EntityAttributes
{
}

public class EntityAttributes : ScriptableObject
{
    [Header("MOVEMENT")]    
    [Header("Grounded")]    
    public float walkSpeed;    
    public float walkLerp; 
    [Space]      
    public float runSpeed;   
    public float runLerp; 
    [Space] 
    public float sprintSpeed;  
    public float sprintLerp;   
    [Space] 
    public float crouchingSpeed;
    public float crouchingLerp;
    [Space]
    public float idlingLerp; 
     
    [Header("On Air")]    
    public float jumpHeight;
    public float gravity = -20f;
  
}
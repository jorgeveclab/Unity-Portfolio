using UnityEngine;

public interface IMovement
{
    public Vector3 Direction{get;}
    public Vector3 Velocity{get;set;} //Property used by each entity controller to update its own velocity property before moving
    public float YSpeed{get;set;}
    public CharacterController Controller{get;}

    public void MoveBody(Vector3 velocity);
}
using Unity.Mathematics;

using UnityEngine;

public interface IAnimator
{
    public float MoveAnimationSpeed{get;set;}
    public void TriggerIdle(bool b);
    public void TriggerWalk(bool b);
    public void TriggerRun(bool b);
    public void TriggerSprint(bool b);
    public void SetFloat(float f);
}


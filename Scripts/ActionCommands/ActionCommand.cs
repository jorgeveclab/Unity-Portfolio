using UnityEngine;

//An ActionCommand is a chunk of code that can be used in different contexts. It follows Command Pattern
//You can simply call an ActionCommand to execute one exclusive behaviour instead of coupling behaviour to a class
//For example, you can call several AC from a State in a FSM to combine behaviours with no coupling and use it anywhere it is needed.

public class ActionCommand : IActionCommand
{    
    public ActionCommand(){}
  
    public virtual void Execute(){}
}




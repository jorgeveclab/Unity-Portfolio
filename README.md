# GAMEPLAY IMPLEMENTATION
## Finite State Machine
### FSM Base Class
- This is a parent class which implements the basic methods and fields to control the flow of states. 
- Using inheritance you can easily create a FSM dedicated to movement, another for weapon or item system, or any other functionality.

### State Base Class
- It owns an Enter(), Update(), HandleTransitions() and Exit() methods so its child classes can overrite and use them.
- I use inheritance in this project to create movement states, as jump, walk o crouch. Any other state type can be designed from this class (shoot, reload, aim, etc).

### ActionCommand Class

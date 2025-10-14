using UnityEngine;

public class State
{
    public FSM fsm;
    public Entity entity;

    private float timer;

    public State( FSM fsm, Entity entity )
    {
        this.fsm = fsm;
        this.entity = entity;
    }

    public virtual void Enter() 
    {
        timer = Time.time;    
    }

    public virtual void Exit() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysic() { }

    public virtual float TimeInState()
    {
        return Time.time - timer;
    }
}

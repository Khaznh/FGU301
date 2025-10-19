using UnityEngine;

public class PlayerResultState : State
{
    public PlayerResultState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(((Player)entity).fishStats);

        ((Player)entity).inventoryManager.GetComponent<InventoryManager>().AddItem(((Player)entity).fishStats.fishItem);

        fsm.ChangeState(((Player)entity).playerNormalState);
    }

    public override void Exit() 
    { 
        base.Exit(); 
    }
}

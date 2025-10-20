using UnityEngine;

public class PlayerInventoryState : State
{
    public PlayerInventoryState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ((Player)entity).mainInvenGroup.SetActive(true);
        ((Player)entity).playerAnimation.enabled = false;
        ((Player)entity).playerMovement.enabled = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (((Player)entity).input.Inventory.Inven.WasPressedThisFrame())
        {
            fsm.ChangeState(((Player)entity).playerNormalState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ((Player)entity).mainInvenGroup.SetActive(false);
        ((Player)entity).playerAnimation.enabled = true;
        ((Player)entity).playerMovement.enabled = true;
    }
}

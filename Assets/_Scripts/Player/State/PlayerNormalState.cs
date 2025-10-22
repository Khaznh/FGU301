using UnityEngine;
using UnityEngine.Windows;

public class PlayerNormalState : State
{
    public PlayerNormalState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ((Player)entity).playerMovement.enabled = true;
        ((Player)entity).playerAnimation.enabled = true;

        ((Player)entity).fishStats = null;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((Player)entity).onNearPort)
        {
            ((Player)entity).fishIcon.SetActive(true);

            if (((Player)entity).input.GamePlay.Interact.WasPressedThisFrame())
            {
                fsm.ChangeState(((Player)entity).playerCastState);
            }
        }

        if (!((Player)entity).onNearPort)
        {
            ((Player)entity).fishIcon.SetActive(false);
        }

        if (((Player)entity).onNearShop && ((Player)entity).input.Shoping.Start.WasPressedThisFrame())
        {
            fsm.ChangeState(((Player)entity).playerTradingState);
        }

        if (((Player)entity).onNearTrading && ((Player)entity).input.Shoping.Start.WasPressedThisFrame())
        {
            fsm.ChangeState(((Player)entity).playerUpgradeState);
        }

        if (((Player)entity).input.Inventory.Inven.WasPressedThisFrame())
        {
            fsm.ChangeState(((Player)entity).playerInventoryState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ((Player)entity).fishIcon.SetActive(false);
        ((Player)entity).fishStats = null;
    }
}

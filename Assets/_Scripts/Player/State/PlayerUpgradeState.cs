using UnityEngine;

public class PlayerUpgradeState : State
{
    public PlayerUpgradeState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }
    public override void Enter()
    {
        base.Enter();
        ((Player)entity).mainInvenGroup.SetActive(true);
        ((Player)entity).upgrade.SetActive(true);
        ((Player)entity).playerAnimation.enabled = false;
        ((Player)entity).playerMovement.enabled = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((Player)entity).input.Shoping.Stop.WasPressedThisFrame())
        {
            fsm.ChangeState(((Player)entity).playerNormalState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ((Player)entity).mainInvenGroup.SetActive(false);
        ((Player)entity).upgrade.SetActive(false);
        ((Player)entity).playerAnimation.enabled = true;
        ((Player)entity).playerMovement.enabled = true;
    }
}

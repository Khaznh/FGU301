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
    }

    public override void Exit()
    {
        base.Exit();
        ((Player)entity).fishIcon.SetActive(false);
        ((Player)entity).fishStats = null;
    }
}

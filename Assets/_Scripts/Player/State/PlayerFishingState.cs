using UnityEngine;

public class PlayerFishingState : State
{
    string result = "";

    public PlayerFishingState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        result = "";
        ((Player)entity).fishGamePlay.SetActive(true);
        ((Player)entity).fishGamePlay.GetComponentInChildren<FishingGamePlay>().fishSpeed = ((Player)entity).fishStats.fishSpeed;
        ((Player)entity).fishGamePlay.GetComponentInChildren<FishingGamePlay>().fishChangeDirTimer = ((Player)entity).fishStats.fishChangeDirTimer;
        ((Player)entity).fishGamePlay.GetComponentInChildren<FishingGamePlay>().lostProgress = ((Player)entity).fishStats.lostProgress;
        ((Player)entity).fishGamePlay.GetComponentInChildren<FishingGamePlay>().gainsProgress = ((Player)entity).fishStats.gainsProgress;
        ((Player)entity).fishingGamePlay.OnGetResult += FishingGamePlay_OnGetResult;
    }

    private void FishingGamePlay_OnGetResult(string obj)
    {
        result = obj;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (result == "Catch")
        {
            Debug.Log("Yeah");
            fsm.ChangeState(((Player)entity).playerResultState);
        }
        else if (result == "Fail")
        {
            Debug.Log("Nooo");
            fsm.ChangeState(((Player)entity).playerNormalState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ((Player)entity).fishGamePlay.SetActive(false);
        ((Player)entity).fishingGamePlay.OnGetResult -= FishingGamePlay_OnGetResult;
    }
}

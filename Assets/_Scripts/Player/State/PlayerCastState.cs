using System.Collections;
using UnityEngine;

public class PlayerCastState : State
{

    private Vector2 dirToRotate;
    private float randomTImer;
    private float catchTime = 2f;
    private float cautionTime = 1f;

    private float timer = 0;

    public PlayerCastState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
        ((Player)entity).playerAnimation.enabled = false;
        ((Player)entity).playerMovement.enabled = false;


        Vector3 dirToPond = ((Player)entity).transform.position - ((Player)entity).pondTransform.position;

        if (PlayerMoney.instance.currentHealth >= 1)
        {
            PlayerMoney.instance.ReduceHealth(1);
        }
        else
        {
            fsm.ChangeState(((Player)entity).playerNormalState);
            return;
        }


        if (Mathf.Abs(dirToPond.x) > Mathf.Abs(dirToPond.y))
        {
            if (dirToPond.x < 0)
            {
                dirToRotate = new Vector2(1, 0);
            }
            else
            {
                dirToRotate = new Vector2(-1, 0);
            }
        }
        else
        {
            if (dirToPond.y < 0)
            {
                dirToRotate = new Vector2(0, 1);
            }
            else
            {
                dirToRotate = new Vector2(0, -1);
            }
        }

        ((Player)entity).animator.SetFloat("LastMoveX", dirToRotate.x);
        ((Player)entity).animator.SetFloat("LastMoveY", dirToRotate.y);

        ((Player)entity).bait = ((Player)entity).playerSpawnBait.SpawnBait(dirToPond * -1);

        AudioManager.Instance.PlaySFX("Water");
        randomTImer = Random.Range(3f, 5f);

        ((Player)entity).fishStats = ((Player)entity).pondTransform.gameObject.GetComponent<PondContainer>().GetRandomFish();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();


        CatchLogic();
    }

    private void CatchLogic()
    {
        timer += Time.deltaTime;

        if (timer < randomTImer)
        {
            return;
        }

        ((Player)entity).iWarn.SetActive(true);

        if (timer < randomTImer + catchTime - cautionTime)
        {
            ((Player)entity).iWarn.GetComponent<Animator>().SetBool("isCaution", true);
        }

        if (((Player)entity).input.GamePlay.Interact.WasPressedThisFrame())
        {

            fsm.ChangeState(((Player)entity).playerFishingState);
        }

        if (timer > randomTImer + catchTime)
        {
            fsm.ChangeState(((Player)entity).playerNormalState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        ((Player)entity).iWarn.SetActive(false);
        ((Player)entity).iWarn.GetComponent<Animator>().SetBool("isCaution", false);
        ((Player)entity).DestroyBait();
    }
}

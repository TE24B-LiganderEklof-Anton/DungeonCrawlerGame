using UnityEngine;

public class AmaranthAbilityHandler : AbilityHandler
{
    public override void BattleSkill()
    {
        //move beetween the player character and closest enemy if this isn't the player character
        if (!isPlayer)
        {
            Vector2 playerPos = PlayerController.playerObject.transform.position;
            Vector2 enemyPos = Toolbox.FindClosestWithTag(playerPos, targetTag).transform.position;
            Vector2 difference = enemyPos - playerPos;
            Vector2 targetPos = playerPos + difference.normalized;
            movementHandler.TimedMoveTo(targetPos, 0.25f);
        }

        //begin blocking
        animator.SetTrigger("BattleSkill");
        eventHandler.wasHit.Bind(OnWasHit);
    }

    //called by event
    public void OnWasHit(GameObject gameObject)
    {
        print("something");
    }

    //called by animation event
    public void StopBlocking()
    {
        eventHandler.wasHit.UnBind(OnWasHit);
    }

}
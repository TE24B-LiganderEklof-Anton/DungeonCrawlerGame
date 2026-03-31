using Unity.VisualScripting;
using UnityEngine;

public class KnightAbilityHandler : AbilityHandler
{
 
    public override void BattleSkill()
    {
        entityDirectionHandler.priorityHandler.SetPriority("KnightBattleSkill", 10, 1);
        animator.SetTrigger("BattleSkill");
        GameObject targetEntity = Toolbox.FindClosestWithTag(transform.position, targetTag);

        Vector2 targetPosition = targetEntity.transform.position;
        movementHandler.TimedMoveToDistance(targetPosition,0.1f, 2);
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class KnightAbilityHandler : AbilityHandler
{
    public override void BattleSkill()
    {
        animator.SetTrigger("BattleSkill");
        if (!isPlayer)
        {
            GameObject targetEntity = Toolbox.FindClosestWithTag(transform.position, targetTag);
            Vector2 targetPosition = targetEntity.transform.position;
            movementHandler.TimedMoveToDistance(targetPosition, 0.1f, 2, 45);   
        }
    }

    //called via animation events
    public void BattleSkillSwingStart()
    {
        weaponAnimator.Play("KnightSwordFlame");
    }
    public void BattleSkillSwingEnd()
    {
        weaponAnimator.Play("KnightSwordIdle");
    }
}
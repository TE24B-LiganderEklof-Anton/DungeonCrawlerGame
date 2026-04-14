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
    void BattleSkillHit(Collider2D collision)
    {
        print("battleskill hit");
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-30);
        }
    }
    //called via animation events
    public void BattleSkillSwingStart()
    {
        weaponAnimator.Play("KnightSwordFlame");
        hitBoxHandler.Bind(BattleSkillHit);
    }
    public void BattleSkillSwingEnd()
    {
        weaponAnimator.Play("KnightSwordIdle");
        hitBoxHandler.Unbind(BattleSkillHit);
    }
}
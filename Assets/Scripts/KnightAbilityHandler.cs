using UnityEngine;

public class KnightAbilityHandler : AbilityHandler
{
    public override void BattleSkill()
    {
        if (!manaHandler.UseMana(30)) return;
        animator.SetTrigger("BattleSkill");
        if (!isPlayer)
        {
            GameObject targetEntity = Toolbox.FindClosestWithTag(transform.position, targetTag);
            Vector2 targetPosition = targetEntity.transform.position;
            movementHandler.TimedMoveToDistance(targetPosition, 0.1f, 2, 45);
            entityDirectionHandler.LookAtPosition(targetPosition, "KnightBattleSkill", 100);
        }
    }
    void BattleSkillHit(Collider2D collision)
    {
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-30);
        }
        ElementHandler elementHandler = collision.gameObject.GetComponent<ElementHandler>();
        if (elementHandler != null)
        {
            elementHandler.Add(Elements.fire, 1);
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
        entityDirectionHandler.priorityHandler.SetPriority("KnightBattleSkill",0,1);
    }
}
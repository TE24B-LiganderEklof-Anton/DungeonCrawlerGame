using UnityEngine;

public class KnightAbilityHandler : AbilityHandler// handles abilities for the knight character
{
    public override void BattleSkill()
    {
        if (!manaHandler.UseMana(30)) return;
        animator.SetTrigger("BattleSkill");
        if (!isPlayer)
        {
            //find position of closest enemy
            GameObject targetEntity = Toolbox.FindClosestWithTag(transform.position, targetTag);
            Vector2 targetPosition = targetEntity.transform.position;
            //move
            movementHandler.TimedMoveToDistance(targetPosition, 0.1f, 2, 45);
            //look at target position
            entityDirectionHandler.LookAtPosition(targetPosition, "KnightBattleSkill", 100);
        }
    }
    void BattleSkillHit(Collider2D collision)
    {
        //deal damage if applicable
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-30);
        }
        //apply fire if applicable
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
        entityDirectionHandler.priorityHandler.SetPriority("KnightBattleSkill", 0, 1);
    }
}
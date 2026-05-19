using System;
using UnityEngine;

public class AmaranthAbilityHandler : AbilityHandler
{
    ParticleSystem battleSkillParticles;
    HitBoxHandler battleSkillHitBox;
    void Start()
    {
        base.Start();
        Transform battleSkillEffects = transform.Find("BattleSkillEffects");
        battleSkillParticles = battleSkillEffects.GetComponent<ParticleSystem>();
        battleSkillHitBox = battleSkillEffects.GetComponent<HitBoxHandler>();
    }
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
    void OnCounterHit(Collider2D collision)
    {
        print(collision.gameObject.name);
        //deal damage
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-20);
        }
        //apply element
        ElementHandler elementHandler = collision.gameObject.GetComponent<ElementHandler>();
        if (elementHandler!=null)
        {
            elementHandler.Add(Elements.nature,2);
        }
    }

    //used by Invoke beacuse it's I have to use a methods string as a name
    void UnbindCounterHit()
    {
        battleSkillHitBox.Unbind(OnCounterHit);
    }
    //called by event
    public void OnWasHit(GameObject gameObject)
    {
        eventHandler.wasHit.UnBind(OnWasHit);
        //counter attack
        battleSkillParticles.Play();
        battleSkillHitBox.Bind(OnCounterHit);
        Invoke("UnbindCounterHit",0.35f);
    }

    //called by animation event
    public void StopBlocking()
    {
        eventHandler.wasHit.UnBind(OnWasHit);
    }

}
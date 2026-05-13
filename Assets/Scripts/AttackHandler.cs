using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour //handles basic attacks
{

    List<GameObject> hits = new();
    Animator animator;
    List<Collider2D> collidersInTrigger = new();
    HitBoxHandler hitBoxHandler;
    void Start()
    {
        animator = GetComponent<Animator>();
        hitBoxHandler = GetComponent<HitBoxHandler>();
    }

    public void Hit(Collider2D collision) //gets bound to HitBoxHandler 
    {
        //deal damage if applicable
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-10);
        }
    }
    //the following are called by animation events
    public void MakeActive() //makes the trigger able to detect collisions and deal damage, called at the beginning of a attack
    {
        if (animator.GetBool("Attacking"))//this method can sometimes be called whilst transitioning to the idle animation and not actively attcking, must therefor double check
        {
            animator.SetBool("Active", true);
            hitBoxHandler.Bind(Hit);
        }
    }
    public void MakeDeactive()// makes the trigger unable to detect collisions, called at the end of an attack.
    {
        animator.SetBool("Active", false);
        hitBoxHandler.Unbind(Hit);
    }
    public void ResetHits()//called when a new attack begins without any downtime from the previous.
    {
        hitBoxHandler.FireCollisions(Hit);
    }

    //the following are primarily used by other scripts:
    public void BeginAttacking()
    {
        if (!animator.GetBool("Attacking") && !animator.GetBool("Active"))//verifies that the entity isn't already attacking
        {
            animator.SetTrigger("BeginAttacking");
        }
        animator.SetBool("Attacking", true);
    }
    public void StopAttacking()
    {
        animator.SetBool("Attacking", false);
    }
}

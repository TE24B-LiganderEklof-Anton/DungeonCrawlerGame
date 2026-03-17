using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{

    List<GameObject> hits = new();
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void MakeActive()
    {
        animator.SetBool("Active", true);
        ResetHits();
    }
    public void MakeDeactive()
    {
        animator.SetBool("Active", false);
    }
    public void ResetHits()
    {
        hits.Clear();
    }
    public void BeginAttacking()
    {
        if (!animator.GetBool("Attacking") && !animator.GetBool("Active"))
        {
            animator.SetTrigger("BeginAttacking");
        }
        animator.SetBool("Attacking", true);
    }
    public void StopAttacking()
    {
        animator.SetBool("Attacking", false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
    }
}

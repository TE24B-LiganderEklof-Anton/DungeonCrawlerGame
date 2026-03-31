using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    protected string targetTag;
    protected MovementHandler movementHandler;
    protected Animator animator;
    protected EntityDirectionHandler entityDirectionHandler;

    void Awake()
    {
        movementHandler = GetComponent<MovementHandler>();
        targetTag = Toolbox.GetEnemyTag(this.gameObject.tag);
        animator = GetComponent<Animator>();
        entityDirectionHandler = GetComponent<EntityDirectionHandler>();
    }
    public virtual void BattleSkill()
    {
        print("BattleSkill");
    }
    public virtual void ChainSkill()
    {
        print("ChainSkill");
    }
}



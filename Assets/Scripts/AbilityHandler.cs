using UnityEngine;
using UnityEngine.AI;

public class AbilityHandler : MonoBehaviour
{
    protected string targetTag;
    protected MovementHandler movementHandler;
    protected Animator animator;
    protected EntityDirectionHandler entityDirectionHandler;
    protected Animator weaponAnimator;
    protected HitBoxHandler hitBoxHandler;
    protected ManaHandler manaHandler;
    GameObject weapon;
    protected bool isPlayer;

    void Start()
    {
        movementHandler = GetComponent<MovementHandler>();
        targetTag = Toolbox.GetEnemyTag(this.gameObject.tag);
        animator = GetComponent<Animator>();
        entityDirectionHandler = GetComponent<EntityDirectionHandler>();
        weapon = transform.Find("Torso").transform.Find("RightShoulder").transform.Find("RightArm").transform.Find("Weapon").gameObject;
        weaponAnimator = weapon.GetComponent<Animator>();
        hitBoxHandler = GetComponent<HitBoxHandler>();
        manaHandler = Toolbox.manaHandler;//really whack will fix
        if (GetComponent<PlayerController>() == null)
        {
            isPlayer = false;
        }
        else
        {
            isPlayer = true;
        }
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



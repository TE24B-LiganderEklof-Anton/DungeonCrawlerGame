using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    //variables intended for use by this class' subclasses, so that I won't have to bother getting them in every subclass script
    protected string targetTag;
    protected MovementHandler movementHandler;
    protected Animator animator;
    protected EntityDirectionHandler entityDirectionHandler;
    protected Animator weaponAnimator;
    protected HitBoxHandler hitBoxHandler;
    protected ManaHandler manaHandler;
    protected EventHandler eventHandler;
    protected bool isPlayer;
    GameObject weapon;

    void Start()
    {
        //getting components/gameobjects
        movementHandler = GetComponent<MovementHandler>();
        targetTag = Toolbox.GetEnemyTag(this.gameObject.tag);
        animator = GetComponent<Animator>();
        entityDirectionHandler = GetComponent<EntityDirectionHandler>();
        weapon = transform.Find("Torso").transform.Find("RightShoulder").transform.Find("RightArm").transform.Find("Weapon").gameObject;
        weaponAnimator = weapon.GetComponent<Animator>();
        hitBoxHandler = GetComponent<HitBoxHandler>();
        manaHandler = Toolbox.manaHandler;
        eventHandler = GetComponent<EventHandler>();

        //detecting is this script is on the player character
        if (GetComponent<PlayerController>() == null)
        {
            isPlayer = false;
        }
        else
        {
            isPlayer = true;
        }
    }

    //intended to be overridden by subclasses, should never be called if not overridden.
    public virtual void BattleSkill()
    {
        print("BattleSkill");
    }
    public virtual void ChainSkill()
    {
        print("ChainSkill");
    }
}



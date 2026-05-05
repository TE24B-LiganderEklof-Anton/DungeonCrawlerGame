using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveVector = Vector2.zero;
    MovementHandler movementHandler;
    AttackHandler attackHandler;
    public static GameObject playerObject;
    void Start()
    {
        movementHandler = GetComponent<MovementHandler>();
        attackHandler = GetComponent<AttackHandler>();
        playerObject = this.gameObject;
    }
    void FixedUpdate()
    {
        if (moveVector.magnitude == 0)

        {
            movementHandler.StopMovement();
        }
        else
        {
            movementHandler.MoveInDirection(moveVector);
        }
    }
    public void OnMove(InputValue input)
    {
        moveVector = input.Get<Vector2>();
    }
    public void OnAttack(InputValue input)
    {
        if (input.Get() == null) //input.Get() is always either null(released) or 1(pressed) do not ask me why
        {
            attackHandler.StopAttacking();
        }
        else
        {
            attackHandler.BeginAttacking();
        }
    }
    public void OnAbility(InputValue input)
    {
        if (input.Get() == null) //input.Get() is always either null(released) or 1(pressed) do not ask me why
        {
            //do stuff, will be used later
        }
        else
        {
            int value = (int)(float)input.Get();//throws an exception when being cast directly to an int despite the inputsystem being set to outputting an integer, so convertion to float first is necessary.
            //finds the corresponding playerEntity to call it's battle skill, will probably want to replace since, from my understanding, using tags this way might cause the array to be a different order at different times, atleast after scene change
            GameObject[] playerEntities = GameObject.FindGameObjectsWithTag("PlayerEntity");//uses array since it will never be changing length or content
            if (value < playerEntities.Length)
            {
                GameObject targetEntity = playerEntities[value];
                targetEntity.GetComponent<AbilityHandler>().BattleSkill();
            }

        }
    }
}

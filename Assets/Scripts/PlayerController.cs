using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Vector2 moveVector = Vector2.zero;
    MovementHandler movementHandler;
    AttackHandler attackHandler;
    void Start()
    {
        movementHandler = GetComponent<MovementHandler>();
        attackHandler = GetComponent<AttackHandler>();
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
}

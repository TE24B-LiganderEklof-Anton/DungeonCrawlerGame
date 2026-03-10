using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Vector2 moveVector = Vector2.zero;
    void FixedUpdate()
    {
        if (moveVector.magnitude == 0)

        {
            GetComponent<MovementHandler>().StopMovement();
        }
        else
        {
            GetComponent<MovementHandler>().MoveInDirection(moveVector);
        }
    }
    public void OnMove(InputValue input)
    {
        moveVector = input.Get<Vector2>();
    }
}

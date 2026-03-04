using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveVector = Vector2.zero;
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().linearVelocity = moveVector*20;
    }
    public void OnMove(InputValue input)
    {
        moveVector = input.Get<Vector2>();
    }
}

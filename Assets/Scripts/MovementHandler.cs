using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    Vector2 moveToPosition;
    Rigidbody2D rigidBody;
    bool active = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveToPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active) return;

        //movement
            Vector2 moveVector = moveToPosition - (Vector2)transform.position;
            float moveMagnitude = moveVector.magnitude;

            moveVector = moveVector.normalized;

            //directly sets the position instead of using velocity if moveToPosition will be reached within one FixedUpdate to prevent overshooting.
            if (moveMagnitude < (moveVector * Time.fixedDeltaTime).magnitude)
            {
                transform.position = moveToPosition;
                StopMovement();
            }
            else
            {
                rigidBody.linearVelocity = moveVector;
            }
    }

    public void MoveTo(Vector2 position)
    {
        moveToPosition = position;
        active = true;
    }
    public void StopMovement()
    {
        rigidBody.linearVelocity = Vector2.zero;
        moveToPosition = transform.position;
        active = false;
    }
    public void MoveInDirection(Vector2 direction)
    {
        moveToPosition = (Vector2)transform.position + direction.normalized*1000000;
        active = true;
    }
}

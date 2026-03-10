using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    Vector2 moveToPosition;
    Rigidbody2D rigidBody;
    Animator animator;
    bool active = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveToPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    void Activate()
    {
        active = true;
        animator.Play("Run");

        int direction = 1;
        if ((moveToPosition-(Vector2)transform.position).x < 0)
        {
            direction = -1;
        }
        GetComponent<EntityDirectionHandler>().SetRotation(direction);
    }
    void Deactivate()
    {
        active = false;
        animator.Play("Idle");
    }
    public void MoveTo(Vector2 position)
    {
        moveToPosition = position;
        Activate();
    }
    public void StopMovement()
    {
        rigidBody.linearVelocity = Vector2.zero;
        moveToPosition = transform.position;
        Deactivate();
    }
    public void MoveInDirection(Vector2 direction)
    {
        MoveTo((Vector2)transform.position + direction.normalized*100000);
    }
}

using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class MovementHandler : MonoBehaviour
{
    Action handleMovement;
    Vector2 moveToPosition;
    Vector2 timedMoveToPosition;
    Rigidbody2D rigidBody;
    Animator animator;
    EntityDirectionHandler directionHandler;
    bool active = false;
    bool blockMoveTo = false;
    [SerializeField]
    float moveSpeed = 1;

    float timedMoveSpeedMult = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handleMovement = BasicMove;
        moveToPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        directionHandler = GetComponent<EntityDirectionHandler>();
    }
    void BasicMove()
    {
        if (!active) return;

        Vector2 distance = moveToPosition - (Vector2)transform.position;
        float totalMult = moveSpeed;
        Vector2 moveVector = distance.normalized * totalMult;

        //directly sets the position instead of using velocity if moveToPosition will be reached within one FixedUpdate to prevent overshooting.
        if (distance.magnitude < (moveVector * Time.fixedDeltaTime).magnitude)
        {
            transform.position = moveToPosition;
            StopMovement();
        }
        else
        {
            rigidBody.linearVelocity = moveVector;
        }
    }

    void TimedMove()
    {
        Vector2 distance = timedMoveToPosition - (Vector2)transform.position;
        float totalMult = timedMoveSpeedMult * moveSpeed;
        Vector2 moveVector = distance.normalized * totalMult; //causes problems because the normalized siatnce becomes zero due to being too small


        print(distance.magnitude);
        print((moveVector * Time.fixedDeltaTime).magnitude);
        //directly sets the position instead of using velocity if moveToPosition will be reached within one FixedUpdate to prevent overshooting.
        if (distance.magnitude < 0.0001f || distance.magnitude <= (moveVector * Time.fixedDeltaTime).magnitude)
        {
            transform.position = timedMoveToPosition;
            blockMoveTo = false;
            StopMovement();
            handleMovement = BasicMove;
        }
        else
        {
            rigidBody.linearVelocity = moveVector;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        handleMovement();
    }
    void Activate()
    {
        active = true;
        animator.SetBool("Running", true);


        if ((moveToPosition - (Vector2)transform.position).x < 0)
        {
            directionHandler.priorityHandler.SetPriority("MovementHandler", 1, -1);
        }
        else if ((moveToPosition - (Vector2)transform.position).x > 0)
        {
            directionHandler.priorityHandler.SetPriority("MovementHandler", 1, 1);
        }
    }
    void Deactivate()
    {
        active = false;
        animator.SetBool("Running", false);
    }
    public void MoveTo(Vector2 position)
    {
        if (blockMoveTo) return;
        moveToPosition = position;
        Activate();
    }
    public void StopMovement()
    {
        if (blockMoveTo) return;
        rigidBody.linearVelocity = Vector2.zero;
        moveToPosition = transform.position;
        Deactivate();
    }
    public void MoveInDirection(Vector2 direction)
    {
        MoveTo((Vector2)transform.position + direction.normalized * 100000);
    }
    public void TimedMoveTo(Vector2 position, float time)
    {
        float distance = (position - (Vector2)transform.position).magnitude;

        timedMoveSpeedMult = distance / moveSpeed / time;
        timedMoveToPosition = position;
        blockMoveTo = true;
        handleMovement = TimedMove;
    }
    public void TimedMoveToDistance(Vector2 position, float time, float desiredDistance)
    {
        Vector2 currentDistance = position - (Vector2)transform.position;
        Vector2 targetPosition = position - (currentDistance.normalized*desiredDistance);
        TimedMoveTo(targetPosition,time);
    }
}

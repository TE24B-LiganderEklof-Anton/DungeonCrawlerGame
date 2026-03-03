using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField]
    GameObject testingTarget;
    [SerializeField]
    float desiredDistance = 5;
    [SerializeField]
    float moveSpeed = 1;
    void FixedUpdate()
    {
        Vector2 positionOfTarget = testingTarget.transform.position;
        float distanceToTargetEnemy = (positionOfTarget - (Vector2)transform.position).magnitude;

        //adjusts the moveToPosition to always be directly right or left of the target by the desiredDistance
        Vector2 moveToPosition = positionOfTarget;
        if (transform.position.x <= positionOfTarget.x)
        {
            moveToPosition.x -= desiredDistance;
        }
        else
        {
            moveToPosition.x += desiredDistance;
        }

        //movement
        if (distanceToTargetEnemy > desiredDistance)
        {
            Vector2 moveVector = moveToPosition - (Vector2)transform.position;
            float moveMagnitude = moveVector.magnitude;

            moveVector = moveVector.normalized * moveSpeed;

            //directly sets the position instead of using velocity if moveToPosition will be reached within one FixedUpdate to prevent overshooting.
            if (moveMagnitude < (moveVector * Time.fixedDeltaTime).magnitude)
            {
                transform.position = moveToPosition;
                GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            }
            else
            {
                GetComponent<Rigidbody2D>().linearVelocity = moveVector;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}

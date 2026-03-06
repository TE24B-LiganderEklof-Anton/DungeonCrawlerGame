using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField]
    GameObject testingTarget;
    [SerializeField]
    float desiredDistance = 5;
    [SerializeField]
    float moveSpeed = 1;
    [SerializeField]
    float maxAngle = 45;

    void FixedUpdate()
    {
        Vector2 positionOfTarget = testingTarget.transform.position;
        Vector2 distanceToTargetEnemy = positionOfTarget - (Vector2)transform.position;

        Vector2 moveToPosition = positionOfTarget;
        // print(distanceToTargetEnemy.normalized.y);

        float currentAngle = Mathf.Tan(distanceToTargetEnemy.y/distanceToTargetEnemy.x);
        currentAngle = Mathf.Abs(currentAngle)*180/Mathf.PI;//convert from radians to positive degrees

        bool isWithinAcceptableAngle = currentAngle < maxAngle;
        print(currentAngle);
        print(isWithinAcceptableAngle);

        //moves if distance is too great or the angle beetween the entity and the target is too great.
        if (distanceToTargetEnemy.magnitude > desiredDistance || !isWithinAcceptableAngle)
        {
            //adjusts the moveToPosition to always be directly right or left of the target up to desiredRange
            float xDistance = positionOfTarget.x - transform.position.x;
            moveToPosition.x -= Mathf.Clamp(xDistance, -desiredDistance, desiredDistance);

            //movement
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

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
    float maxAngle = 45;
    MovementHandler movementHandler;
    AttackHandler attackHandler;
    void Start()
    {
        movementHandler = GetComponent<MovementHandler>();
        attackHandler = GetComponent<AttackHandler>();
    }

    void FixedUpdate()
    {
        Vector2 positionOfTarget = testingTarget.transform.position;
        Vector2 moveToPosition = positionOfTarget;

        Vector2 distanceToTargetEnemy = positionOfTarget - (Vector2)transform.position;
        bool isWithinDesiredDistance = distanceToTargetEnemy.magnitude < desiredDistance;

        float currentAngle = Mathf.Tan(distanceToTargetEnemy.y/distanceToTargetEnemy.x);
        currentAngle = Mathf.Abs(currentAngle)*180/Mathf.PI;//convert from radians to positive degrees
        bool isWithinAcceptableAngle = currentAngle < maxAngle;

        //moves if distance is too great or the angle beetween the entity and the target is too great.
        if (!isWithinDesiredDistance || !isWithinAcceptableAngle)
        {
            //adjusts the moveToPosition to always be directly right or left of the target up to desiredRange
            float xDistance = positionOfTarget.x - transform.position.x;
            moveToPosition.x -= Mathf.Clamp(xDistance, -desiredDistance, desiredDistance);

            movementHandler.MoveTo(moveToPosition);
        }
        else
        {
            movementHandler.StopMovement();
        }
        //attacking
        if (isWithinDesiredDistance)
        {
            attackHandler.BeginAttacking();
        }
        else
        {
            attackHandler.StopAttacking();
        }
    }
}

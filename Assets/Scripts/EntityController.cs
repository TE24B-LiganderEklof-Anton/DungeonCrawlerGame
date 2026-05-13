using UnityEngine;

public class EntityController : MonoBehaviour// handles movement and attacking for non player entities
{
    [SerializeField]
    float desiredDistance = 1;
    [SerializeField]
    float maxAngle = 45;
    MovementHandler movementHandler;
    AttackHandler attackHandler;
    string targetTag;
    void Start()
    {
        movementHandler = GetComponent<MovementHandler>();
        attackHandler = GetComponent<AttackHandler>();
        targetTag = Toolbox.GetEnemyTag(this.tag);
    }

    void FixedUpdate()
    {
        //acquire target
        GameObject targetEntity = Toolbox.FindClosestWithTag(transform.position, targetTag);

        //position
        Vector2 positionOfTarget = targetEntity.transform.position;
        Vector2 moveToPosition = positionOfTarget;

        //distance
        Vector2 distanceToTargetEnemy = positionOfTarget - (Vector2)transform.position;
        bool isWithinDesiredDistance = distanceToTargetEnemy.magnitude <= desiredDistance;

        //angles
        float currentAngle = Mathf.Tan(distanceToTargetEnemy.y / distanceToTargetEnemy.x);
        currentAngle = Mathf.Abs(currentAngle) * 180 / Mathf.PI;//convert from radians to positive degrees
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

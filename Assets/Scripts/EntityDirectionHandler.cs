using Unity.Mathematics;
using UnityEngine;


public class EntityDirectionHandler : MonoBehaviour// handles looking left and right for entities
{
    Canvas canvas;
    float defaultRotation; //should always be +/- 1
    public PriorityHandler<int> priorityHandler;


    void Start()
    {
        if (transform.localScale.x < 0) defaultRotation = -1;
        else defaultRotation = 1;

        canvas = GetComponentInChildren<Canvas>();

        priorityHandler = new(SetRotation, 1);
    }

    public void LookAtPosition(Vector2 pos, string key, float priority) //looks towards the given point
    {
        int dir;
        //checks wheather to look right or left
        if (pos.x > transform.position.x)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        priorityHandler.SetPriority(key, priority, dir);
    }

    //sets the localscale.x to the given "rotation"
    void SetRotation(int rotation)
    {
        //uses absolute value to make it not always mirror when set to -1, has the downside of only working if the default X is positive
        float absoluteX = Mathf.Abs(transform.localScale.x);

        transform.localScale = new(
            defaultRotation * rotation * absoluteX,
            transform.localScale.y,
            transform.localScale.z
        );

        //mirrors the healthbar as well to keep it the same
        canvas.gameObject.transform.localScale = new(
            math.abs(canvas.gameObject.transform.localScale.x) * rotation,
            canvas.gameObject.transform.localScale.y,
            canvas.gameObject.transform.localScale.z
        );

    }
}

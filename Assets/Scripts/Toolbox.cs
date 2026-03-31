using System;
using Unity.Mathematics;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static String GetEnemyTag(string tag)
    {
        string enemyTag = null;
        if (tag == "PlayerEntity") enemyTag = "EnemyEntity";
        else enemyTag = "PlayerEntity";

        return enemyTag;
    }
    public static GameObject FindClosestWithTag(Vector2 position, string tag)
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag(tag);

        GameObject selected = null;
        float selectedDistance = math.INFINITY;

        foreach (GameObject gameObject in array)
        {
            float distance = ((Vector2)gameObject.transform.position - position).magnitude;
            if (distance < selectedDistance)
            {
                selected = gameObject;
                selectedDistance = distance;
            }
        }
        return selected;
    }
}
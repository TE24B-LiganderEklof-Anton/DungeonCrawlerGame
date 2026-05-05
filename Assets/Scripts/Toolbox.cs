using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.WSA;

public class Toolbox : MonoBehaviour
{
    [SerializeField]
    GameObject manaHandlerObject;
    public static ManaHandler manaHandler;
    [SerializeField]
    Folder ElementIconsFolder;
    public static Dictionary<Elements,GameObject> ElementIconsPrefabDict;
    [SerializeField]
    GameObject FireIconPrefab;
    [SerializeField]
    GameObject WaterIconPrefab;
    [SerializeField]
    GameObject LightningIconPrefab;
    [SerializeField]
    GameObject NatureIconPrefab;
    void Awake()
    {
        manaHandler = manaHandlerObject.GetComponent<ManaHandler>();

        ElementIconsPrefabDict = new()
        {
            {Elements.fire,FireIconPrefab},
            {Elements.water,WaterIconPrefab},
            {Elements.lightning,FireIconPrefab},
            {Elements.nature,NatureIconPrefab}
        };
    }
    public static String GetEnemyTag(string tag)
    {
        return tag == "PlayerEntity" ? "EnemyEntity" : "PlayerEntity";

        // string enemyTag = null;
        // if (tag == "PlayerEntity") enemyTag = "EnemyEntity";
        // else enemyTag = "PlayerEntity";

        // return enemyTag;
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
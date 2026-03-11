using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EntityDirectionHandler : MonoBehaviour
{
    float defaultXScale;
    void Start()
    {
        defaultXScale = transform.localScale.x;
    }
    public void SetRotation(int rotation)
    {
        transform.localScale = new(
            defaultXScale*rotation,
            transform.localScale.y,
            transform.localScale.z
        );
    }
}

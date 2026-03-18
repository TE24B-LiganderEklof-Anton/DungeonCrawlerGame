using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EntityDirectionHandler : MonoBehaviour
{
    Canvas canvas;
    float defaultXScale;
    void Start()
    {
        defaultXScale = transform.localScale.x;
        canvas = GetComponentInChildren<Canvas>();
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

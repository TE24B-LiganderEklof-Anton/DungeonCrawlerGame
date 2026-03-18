using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EntityDirectionHandler : MonoBehaviour
{
    Canvas canvas;
    float defaultRotation; //should always be +/- 1
    void Start()
    {
        if (transform.localScale.x < 0) defaultRotation = -1;
        else defaultRotation = 1;

        canvas = GetComponentInChildren<Canvas>();
    }
    public void SetRotation(int rotation)
    {
        float absoluteX = Mathf.Abs(transform.localScale.x);
        
        transform.localScale = new(
            defaultRotation*rotation*absoluteX,
            transform.localScale.y,
            transform.localScale.z
        );

        canvas.gameObject.transform.localScale = new(
            math.abs(canvas.gameObject.transform.localScale.x)*rotation,
            canvas.gameObject.transform.localScale.y,
            canvas.gameObject.transform.localScale.z
        );

    }
}

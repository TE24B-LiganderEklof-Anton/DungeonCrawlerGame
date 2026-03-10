using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EntityDirectionHandler : MonoBehaviour
{
    Dictionary<Transform, float> defaultZPos = new();//contains all the transforms original position z value.
    float defaultYRot;
    void Start()
    {
        foreach (Transform transf in this.GetComponentsInChildren<Transform>())
        {
            defaultZPos.Add(transf, transf.position.z);
        }

        defaultYRot = transform.rotation.y;
    }

    public void SetRotation(int rotation)
    {
        foreach (Transform transf in this.GetComponentsInChildren<Transform>())
        {
            Vector3 newPos = new(
                transf.position.x,
                transf.position.y,
                defaultZPos[transf] * rotation
                );
            transf.position = newPos;
            print(transf.gameObject.name);
            print(defaultZPos[transf]);
            print(rotation);

            quaternion newRot = new(
                transform.rotation.x, 
                defaultYRot + (90-(90*rotation)),
                transform.rotation.z,
                transform.rotation.w);
            transform.rotation = newRot;
        }
    }
}

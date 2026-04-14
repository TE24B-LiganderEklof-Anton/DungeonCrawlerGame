using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBoxHandler : MonoBehaviour
{
    
    List<Collider2D> collidersInTrigger = new();
    List<Action<Collider2D>> callbacks = new();

    public void Bind(Action<Collider2D> callback)
    {
        callbacks.Add(callback);
        FireCollisions(callback);
    }
    public void Unbind(Action<Collider2D> callback)
    {
        callbacks.Remove(callback);
    }
    public void FireCollisions(Action<Collider2D> callback) //calls the given callback for all colliders currently in trigger
    {
        foreach (Collider2D collision in collidersInTrigger)
        {
            callback(collision);
        }
    }
    void FireCallbacks(Collider2D collision) //calls all callbacks with the given collider as parameter
    {
        foreach (Action<Collider2D> callback in callbacks)
        {
            callback(collision);
        } 
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        collidersInTrigger.Add(collider);
        FireCallbacks(collider);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        collidersInTrigger.Remove(collision);
    }
}

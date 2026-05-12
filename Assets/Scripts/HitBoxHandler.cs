using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBoxHandler : MonoBehaviour
{
    
    List<Collider2D> collidersInTrigger = new();// is a list since the amount of object that will exist inside the trigger at a given time is unknown and dynamic length is thereby required
    List<Action<Collider2D>> callbacks = new();// is a list since it allows any number of callbacks to be bound

    //binds a given action to be called when a collision occurs, also immedietely calls for all colliders currently in trigger
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
            Hit(callback,collision);
        }
    }
    void FireCallbacks(Collider2D collision) //calls all callbacks with the given collider as parameter
    {        
        foreach (Action<Collider2D> callback in callbacks)
        {
            Hit(callback,collision);
        } 
    }
    void Hit(Action<Collider2D> callback, Collider2D collision)
    {
        FireWasHitEvent(collision);
        callback(collision);
    }
    void FireWasHitEvent(Collider2D collision)
    {
        GameObject hitGameObject = collision.gameObject;
        EventHandler eventhandler = hitGameObject.GetComponent<EventHandler>();
        if (eventhandler == null) return;
        eventhandler.wasHit.Fire(this.gameObject);
    }
    //called via MoneoBehavior:
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

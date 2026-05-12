using System;
using System.Collections.Generic;
using UnityEngine;
public class EventHandler : MonoBehaviour
{
    public Event<GameObject> wasHit = new(); //parameter should be the attacking entity

}

//is used for binding a method to be called when a certain event occurs 
public class Event<T>
{
    List<Action<T>> callbacks = new();//uses a list to allow any number of callbacks to be bound
    List<Action<T>> toBeUnbound = new();
    public void Bind(Action<T> callback)
    {
        callbacks.Add(callback);
    }
    public void UnBind(Action<T> callback)
    {
        callbacks.Remove(callback);
    }
    public void UnBindAfterFiring(Action<T> callback)//sets a action to be unbound as soon as the current firing loop ends, is used to avoid moidfying the listy whilst looping thourgh it.
    {
        toBeUnbound.Add(callback);
    }
    public void Fire(T parameter){
        if (callbacks.Count < 1) return;
        foreach (Action<T> callback in callbacks)
        {
            callback(parameter);
        }

        foreach (Action<T> callback in toBeUnbound)
        {
            UnBind(callback);
        }
        toBeUnbound.Clear();
    }
}
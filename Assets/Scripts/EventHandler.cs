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
    public void Bind(Action<T> callback)
    {
        callbacks.Add(callback);
    }
    public void UnBind(Action<T> callback)
    {
        callbacks.Remove(callback);
    }
    public void Fire(T parameter){
        foreach (Action<T> callback in callbacks)
        {
            callback(parameter);
        }
    }
}
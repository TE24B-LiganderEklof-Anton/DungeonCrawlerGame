using System;
using System.Collections.Generic;
using UnityEngine;
public class EventHandler : MonoBehaviour //generall system for binding methods to certain events. 
{
    public Event<GameObject> wasHit = new(); //parameter should be the attacking entity

}

//is used for binding a method to be called when a certain event occurs 
public class Event<T>
{
    List<Action<T>> callbacks = new();//uses a list to allow any number of callbacks to be bound
    List<Action<T>> toBeUnbound = new();
    bool firing = false;
    public void Bind(Action<T> callback)
    {
        callbacks.Add(callback);
    }
    public void UnBind(Action<T> callback)
    {
        //if the event is currently firing, modifying the list would cause an exception since if would involve modifying a list that is currently being loop through, therefore the method is stored in a list to be removed later
        if (firing)
        {
            toBeUnbound.Add(callback);
        }
        else
        {
            callbacks.Remove(callback);
        }
    }
    public void Fire(T parameter)
    {
        firing = true;
        //call methods currently bound
        foreach (Action<T> callback in callbacks)
        {
            callback(parameter);
        }

        firing = false;
        //unbind methods that were called to be unbound whilst firing
        foreach (Action<T> callback in toBeUnbound)
        {
            UnBind(callback);
        }
        toBeUnbound.Clear();
    }
}
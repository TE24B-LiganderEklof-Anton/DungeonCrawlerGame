using System;
using System.Collections.Generic;
using UnityEngine;
public class ValueAdder : MonoBehaviour
{
    Dictionary<String,float> values = new();
    Action<float> onValueChange;
    public float currentValue = 0;
    void Calculate()//adds together all value in dictionary and updates currentValue
    {
        float newValue = 0;
        foreach (float value in values.Values)
        {
            newValue += value;
        }
        //call onchange method if value actually changed
        if (newValue != currentValue)
        {
            onValueChange(newValue);
        }
        currentValue = newValue;
    }
    public ValueAdder(Action<float> onValueChangeMethod)
    {
        onValueChange = onValueChangeMethod;
    }
    public void SetKey(string key, float value)
    {
        values[key] = value;
        Calculate();
    }
}
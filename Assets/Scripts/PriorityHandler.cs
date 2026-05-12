using System;
using System.Collections.Generic;

public class PriorityHandler<T>
{
    Dictionary<string,(float,T)> priorities = new();
    float currentPriority = 0;
    T defaultValue = default;
    T currentValue;
    
    Action<T> onValueChange;

    public PriorityHandler(Action<T> onValueChangeFunc, T default_)
    {
        onValueChange = onValueChangeFunc;
        defaultValue = default_;
        currentValue = defaultValue;
    }

    (float, T) FindHighest()
    {
        float highestPriority = 0;
        T highestPriorityValue = defaultValue;
        foreach ((float priority, T value) in priorities.Values)
        {
            if (priority > highestPriority)
            {
                highestPriority = priority;
                highestPriorityValue = value;
            }
        }
        return (highestPriority,highestPriorityValue);
    }

    void UpdateCurrent()
    {
        (float newPriority,T newValue) = FindHighest();
        if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
        {
            onValueChange(newValue);
        }
        currentPriority = newPriority;
        currentValue = newValue;
    }
    public void SetPriority(string key, float priority, T value)
    {
        priorities[key] = (priority, value);
        UpdateCurrent();
    }
}
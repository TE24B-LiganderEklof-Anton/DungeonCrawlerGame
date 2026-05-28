using UnityEditor.AnimatedValues;
using UnityEngine;
public class StatsHandler: MonoBehaviour {
    public Stat damageTaken = new(1);
}
public class Stat
{
    public float value = 0;
    public ValueAdder additive;
    public ValueAdder multiplicative;
    public void onChange(float _)
    {
        value = additive.currentValue * multiplicative.currentValue;
    }
    public Stat(float baseValue)
    {
        additive = new(onChange);
        additive.SetKey("base", baseValue);
        multiplicative = new(onChange);
    }
}
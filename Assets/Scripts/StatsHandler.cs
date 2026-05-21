using UnityEngine;
public class StatsHandler: MonoBehaviour {
    
}
class Stat
{
    public float value = 0;
    public ValueAdder additive;
    public ValueAdder multiplicative;
    public void onChange(float _)
    {
        value = additive.currentValue * multiplicative.currentValue;
    }
    public Stat()
    {
        additive = new(onChange);
        multiplicative = new(onChange);
    }
}
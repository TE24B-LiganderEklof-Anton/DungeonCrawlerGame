using UnityEngine;

public class StatusEffectHandler : MonoBehaviour{

}

public class StatusEffct
{
    public float duration;
    public float remainingDuration;

    public virtual void OnApplication()
    {
        
    }
    public virtual void OnRemoval()
    {
        
    }
}
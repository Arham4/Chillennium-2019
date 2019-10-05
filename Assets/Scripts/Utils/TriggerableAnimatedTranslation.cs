using UnityEngine;

public class TriggerableAnimatedAnimatedTranslation : AnimatedTranslation
{
    private bool _trigger;

    public TriggerableAnimatedAnimatedTranslation(GameObject obj, Transform to, float speed, Vector3 offset = default) : base(obj, to, speed, offset) { }
    
    public void Trigger()
    {
        _trigger = true;
    }

    public bool isTrigger()
    {
        return _trigger;
    }

    public void ResetTrigger()
    {
        _trigger = false;
    }

    public override void Execute(Then then = null)
    {
        if (_trigger)
        {
            _execute(then);
        }
    }

    public override void Reset()
    {
        ResetTrigger();
        _reset();
    }
}
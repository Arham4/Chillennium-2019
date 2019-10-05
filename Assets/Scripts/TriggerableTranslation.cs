using UnityEngine;

public class TriggerableTranslation : Translation
{
    private bool _trigger;

    public TriggerableTranslation(GameObject obj, Vector3 to, float speed) : base(obj, to, speed) { }
    
    public void Trigger()
    {
        _trigger = true;
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
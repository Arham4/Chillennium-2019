using System;
using Game;
using UnityEngine;

public delegate void Then();

public class Translation
{
    private readonly GameObject _object;
    private readonly Vector3 _to;
    private readonly float _speed;
    private bool _completed;

    public Translation(GameObject obj, Vector3 to, float speed)
    {
        _object = obj;
        _to = to;
        _speed = speed;
    }

    public void _reset()
    {
        _completed = false;
    }

    public bool isFinished()
    {
        return _completed;
    }

    protected void _execute(Then then)
    {
        if (!_completed)
        {
            GameSingleton.Instance.cameraDisruption = true;
            _object.transform.position = Vector3.MoveTowards(_object.transform.position,
                _to, _speed * Time.deltaTime);
            if (_object.transform.position.Equals(_to))
            {
                GameSingleton.Instance.cameraDisruption = false;
                _completed = true;
                then?.Invoke();
            }
        }
    }

    public virtual void Execute(Then then = null)
    {
        _execute(then);
    }

    public virtual void Reset()
    {
        _reset();
    }
}
using System;
using Game;
using UnityEngine;
using UnityEngine.UIElements;

public delegate void Then();

public class Translation
{
    private readonly GameObject _object;
    private readonly Transform _to;
    private readonly float _speed;
    private bool _completed;
    private Vector3 _offset;

    public Translation(GameObject obj, Transform to, float speed, Vector3 offset = default)
    {
        _object = obj;
        _to = to;
        _speed = speed;
        _offset = offset;
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
                _to.position + _offset, _speed * Time.deltaTime);
            if (_object.transform.position.Equals(_to.position + _offset))
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
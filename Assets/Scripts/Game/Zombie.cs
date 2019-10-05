using System.Collections;
using System.Collections.Generic;
using Game;
using Game.Gun;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour, IEnemy
{
    private int _health;
    private GameObject _car;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _car = GameObject.Find("Car");
        _health = Random.Range(2, 4);
    }

    void Update()
    {
        _navMeshAgent.destination = _car.transform.position;
    }

    public void OnHit(IBullet bullet)
    {
        _health -= bullet.GetDamage();
        if (_health <= 0)
        {
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        if (_navMeshAgent.isOnNavMesh)
        {
            _navMeshAgent.destination = _car.transform.position;
        }

        if (transform.position.z > 55)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnHit(IGun gun)
    {
        _health -= gun.GetDamage();
        Debug.Log("Zombie health now " + _health);
        if (_health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroy zombie");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Game;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour, IEnemy
{
    private GameObject _car;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _car = GameObject.Find("Car");
    }

    void Update()
    {
        _navMeshAgent.destination = _car.transform.position;

        if (transform.position.z > 55)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

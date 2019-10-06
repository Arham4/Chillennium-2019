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
    private float _defaultNavSpeed;

    void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _car = GameObject.Find("Car");
        _health = Random.Range(2, 4);
        _defaultNavSpeed = _navMeshAgent.speed;
    }

    void Update()
    {
        if (_navMeshAgent.isOnNavMesh)
        {
            _navMeshAgent.destination = _car.transform.position;
            if (GameSingleton.Instance.currentSongType == Radio.SongType.Chill)
            {
                _navMeshAgent.speed = (float) (_defaultNavSpeed * 0.6);
            }
            else
            {
                _navMeshAgent.speed = _defaultNavSpeed;
            }
        }

        if (transform.position.z > 55)
        {
            GameSingleton.Instance.deathReason = "A zombie got to you.";
            SceneManager.LoadScene("GameOver");
            SceneManager.UnloadSceneAsync("Game");
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

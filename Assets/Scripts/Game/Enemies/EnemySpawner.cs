using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private int spawnDelay;

        private float _countdown;
        private IList<IEnemy> _enemies;

        void Start()
        {
            _enemies = new List<IEnemy>();
            _countdown = spawnDelay;
        }

        private void LateUpdate()
        {
            _countdown -= Time.deltaTime;
            if (_countdown <= 0)
            {
                _countdown = spawnDelay;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            IEnemy enemy = Instantiate(this.enemy, transform.position + new Vector3(Random.Range(-45, 45), 0, 0),
                Quaternion.identity).GetComponent<IEnemy>();
            _enemies.Add(enemy);
        }
    }
}
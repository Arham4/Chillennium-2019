using System;
using UnityEngine;

namespace Game.Gun
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float speed = 2f;
        private bool _fire;
        private Vector3 _endLocation;
        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            if (_rigidBody == null)
            {
                Debug.LogError("Rigit body is null!");
                return;
            }
        }

        private void Update()
        {
            if (_fire)
            {
                transform.LookAt(_endLocation);
                _rigidBody.AddForce(Vector3.forward * speed);
            }
        }

        public void Fire(Vector3 endLocation)
        {
            _endLocation = endLocation;
            _fire = true;
        }

        public int GetDamage()
        {
            return 1;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Zombie"))
            {
                IEnemy enemy = other.collider.GetComponent<IEnemy>();
                enemy.OnHit(this);
            }
        }
    }
}
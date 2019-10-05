using System;
using UnityEngine;

namespace Game.Gun
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float speed;
        private AnimatedTranslation _bulletMotion;
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
            _bulletMotion?.Execute();
        }

        public void Fire(Vector3 endLocation)
        {
            transform.LookAt(endLocation);
            _rigidBody.AddForce(Vector3.forward * speed);
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
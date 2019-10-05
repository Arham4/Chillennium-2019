using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UIElements;

namespace Game.Gun
{
    
    public class Gun : MonoBehaviour, IGun
    {
        [SerializeField]
        private GameObject bullet;
        private GameObject _reticle;
        private GameObject _backseat;

        private void Start()
        {
            _reticle = GameObject.Find("Reticle");
            if (_reticle == null)
            {
                Debug.LogError("Reticle is null!");
                return;
            }

            _backseat = GameObject.Find("Backseat");
            if (_backseat == null)
            {
                Debug.LogError("Backseat is null!");
                return;
            }
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Backseat)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 reticleLocation = _reticle.transform.position;
                Vector3 bulletStartPosition = new Vector3(reticleLocation.x, reticleLocation.y, _backseat.transform.position.z);
                IBullet iBullet = Instantiate(bullet, bulletStartPosition, Quaternion.identity).GetComponent<IBullet>();
                iBullet.Fire(reticleLocation);
            }
        }
    }
}
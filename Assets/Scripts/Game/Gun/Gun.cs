using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Game.Gun
{
    public class Gun : MonoBehaviour, IGun
    {
        private GameObject _reticle;
        private GameObject _backseat;
        private AudioSource _audioSource;
        private AudioClip _gunShot1;
        private AudioClip _gunShot2;

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

            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                Debug.LogError("Audio source is null!");
                return;
            }
            _gunShot1 = Resources.Load<AudioClip>("Sounds/gunshot_1");
            if (_gunShot1 == null)
            {
                Debug.LogError("Gun shot 1 is null!");
                return;
            }
            _gunShot2 = Resources.Load<AudioClip>("Sounds/gunshot_2");
            if (_gunShot2 == null)
            {
                Debug.LogError("Gun shot 2 is null!");
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
                AudioClip clip = Random.Range(1, 2) == 1 ? _gunShot1 : _gunShot2;
                _audioSource.PlayOneShot(clip);

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenToWorldPoint(_reticle.transform.position),
                    -_reticle.transform.forward, out hit))
                {
                    IEnemy iEnemy = hit.transform.GetComponent<IEnemy>();
                    if (iEnemy != null)
                    {
                        iEnemy.OnHit(this);
                    }
                }
            }
        }

        public int GetDamage()
        {
            return 1;
        }
    }
}
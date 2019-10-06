using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UIElements;

namespace Game.Gun
{
    public class Gun : MonoBehaviour, IGun
    {
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
                RaycastHit hit;
                Debug.Log("Shot");
                Debug.DrawRay(Camera.main.transform.position, -_reticle.transform.forward, Color.red);
                if (Physics.Raycast(Camera.main.transform.position,
                    -_reticle.transform.forward, out hit))
                {
                    Debug.Log("Hit " + hit.transform.name);
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
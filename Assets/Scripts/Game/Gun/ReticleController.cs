using System;
using UnityEngine;

namespace Game.Gun
{
    public class ReticleController : MonoBehaviour
    {
        private GameObject _reticle;

        private void Start()
        {
            _reticle = GameObject.Find("Reticle");
        }

        private void Update()
        {
            _reticle.SetActive(GameSingleton.Instance.currentView == View.Backseat);
        }
    }
}
using System;
using UnityEngine;

namespace Game.Gun
{
    public class Reticle : MonoBehaviour
    {
        private void Update()
        {
            if (GameSingleton.Instance.currentView == View.Backseat)
            {
                transform.position = Input.mousePosition;
            }
        }
    }
}
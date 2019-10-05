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
                Cursor.visible = true;
                transform.position = Input.mousePosition;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }
}
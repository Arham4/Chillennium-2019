using UnityEngine;

namespace Game.Environment
{
    public class RadioVisibility : MonoBehaviour
    {
        private GameObject _radioCanvas;
    
        private void Start()
        {
            _radioCanvas = GameObject.Find("RadioCanvas");
        }

        void Update()
        {
            if (GameSingleton.Instance.currentView != View.Shotgun)
            {
                _radioCanvas.SetActive(false);
            }
            else
            {
                _radioCanvas.SetActive(true);
            }
        }
    }
}
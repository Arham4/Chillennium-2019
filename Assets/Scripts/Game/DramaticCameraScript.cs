using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game
{
    public class DramaticCameraScript : MonoBehaviour
    {
        private Translation _translation;

        private void Start()
        {
            var driverTransform = GameObject.Find("Driver").transform;
            var cameraObject = gameObject;
            _translation = new Translation(cameraObject,
                driverTransform.position + new Vector3(0, driverTransform.lossyScale.y * 0.65f, -5), 40);
        }

        private void Update()
        {
            _translation.Execute(then: () =>
            {
                GameSingleton.Instance.currentView = View.Driver;
                Debug.Log("current view is now Driver");
            });
        }
    }
}
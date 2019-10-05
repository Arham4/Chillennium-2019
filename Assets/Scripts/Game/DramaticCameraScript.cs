using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game
{
    public class DramaticCameraScript : MonoBehaviour
    {
        private AnimatedTranslation _animatedTranslation;
        private GameObject _driver;
        public static bool done;

        private void Start()
        {
            _driver = GameObject.Find("Driver");
            if (_driver == null)
            {
                Debug.LogError("Driver is null!");
                return;
            }

            var driverTransform = _driver.transform;
            var cameraObject = gameObject;
            _animatedTranslation = new AnimatedTranslation(cameraObject,
                driverTransform, 20, offset: new Vector3(0, driverTransform.lossyScale.y * 0.65f, -5));
        }

        private void Update()
        {
            _animatedTranslation.Execute(then: () =>
            {
                if (GameSingleton.Instance == null)
                {
                    Debug.LogError("Game singleton is null!");
                    return;
                }

                done = true;
                GameSingleton.Instance.UpdateGame(View.Driver, _driver);
                Debug.Log("current view is now Driver (drama)");
            });
        }
    }
}
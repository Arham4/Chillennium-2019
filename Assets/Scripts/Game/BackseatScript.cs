﻿using UnityEngine;

namespace Game
{
    public class BackseatScript : MonoBehaviour
    {
        private TriggerableTranslation _backseatTranslation;
        private GameObject _driver;

        private void Start()
        {
            _driver = GameObject.Find("Driver");
            if (_driver == null)
            {
                Debug.LogError("Driver is null!");
                return;
            }
            var backseatTransform = _driver.transform;
            if (Camera.main == null)
            {
                Debug.LogError("Main camera is null! (Backseat)");
                return;
            }
            _backseatTranslation = new TriggerableTranslation(Camera.main.gameObject, 
                backseatTransform.position + new Vector3(0, backseatTransform.lossyScale.y * 0.65f, -5), 25);
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Backseat)
            {
                return;
            }
            if (Input.GetKeyDown("space"))
            {
                _backseatTranslation.Trigger();
            }
            _backseatTranslation.Execute(then: () =>
            {
                _backseatTranslation.Reset();
                GameSingleton.Instance.UpdateGame(View.Driver, _driver);
                Debug.Log("current view is now Driver (backseat)");
            });
        }
    }
}
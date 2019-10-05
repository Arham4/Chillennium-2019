using UnityEngine;

namespace Game
{
    public class BackseatScript : MonoBehaviour
    {
        private TriggerableTranslation _driverTranslation;

        private void Start()
        {
            var driverTransform = GameObject.Find("Driver").transform;
            _driverTranslation = new TriggerableTranslation(Camera.main.gameObject, 
                driverTransform.position + new Vector3(0, driverTransform.lossyScale.y * 0.65f, -5), 25);
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Backseat)
            {
                return;
            }
            if (Input.GetKeyDown("space"))
            {
                _driverTranslation.Trigger();
            }
            _driverTranslation.Execute(then: () =>
            {
                _driverTranslation.Reset();
                GameSingleton.Instance.currentView = View.Driver;
                Debug.Log("current view is now Driver");
            });
        }
    }
}
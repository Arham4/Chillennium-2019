using UnityEngine;

namespace Game
{
    public class DriverScript : MonoBehaviour
    {
        private TriggerableTranslation _shotgunTranslation;

        private void Start()
        {
            var shotgunTransform = GameObject.Find("Shotgun").transform;
            _shotgunTranslation = new TriggerableTranslation(Camera.main.gameObject, 
                shotgunTransform.position + new Vector3(0, shotgunTransform.lossyScale.y * 0.65f, -5), 25);
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Driver)
            {
                return;
            }
            if (Input.GetKeyDown("space"))
            {
                _shotgunTranslation.Trigger();
            }
            _shotgunTranslation.Execute(then: () =>
            {
                _shotgunTranslation.Reset();
                
                GameSingleton.Instance.currentView = View.Shotgun;
                Debug.Log("current view is now Shotgun");
            });
        }
    }
}
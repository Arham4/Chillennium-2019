using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Game
{
    public class BackseatScript : MonoBehaviour
    {
        private TriggerableAnimatedAnimatedTranslation _backseatAnimatedAnimatedTranslation;
        private GameObject _driver;
        private Camera _camera;
        private GameObject _zombies;

        private void Start()
        {
            _driver = GameObject.Find("Driver");
            if (_driver == null)
            {
                Debug.LogError("Driver is null!");
                return;
            }

            _zombies = GameObject.Find("Zombies");
            if (_zombies == null)
            {
                Debug.LogError("Zombies are null!");
                return;
            }

            var backseatTransform = _driver.transform;
            if (Camera.main == null)
            {
                Debug.LogError("Main camera is null! (Backseat)");
                return;
            }

            _camera = Camera.main;
            _backseatAnimatedAnimatedTranslation = new TriggerableAnimatedAnimatedTranslation(Camera.main.gameObject,
                backseatTransform, 25, offset: new Vector3(0, backseatTransform.lossyScale.y * 0.65f));
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Backseat)
            {
                return;
            }
            
            if (Input.GetKeyDown("space"))
            {
                _backseatAnimatedAnimatedTranslation.Trigger();
            }
            if (_backseatAnimatedAnimatedTranslation.isTrigger())
            {
                _camera.transform.rotation =
                    Quaternion.RotateTowards(_camera.transform.rotation, new Quaternion(0, 0, 0, 1), 180 * Time.deltaTime);
            }
            else
            {
                Quaternion rotateDirection =
                    Quaternion.LookRotation(
                        _zombies.transform.position - _camera.transform.position + new Vector3(0, 10, 0));
                _camera.transform.rotation =
                    Quaternion.RotateTowards(_camera.transform.rotation, rotateDirection, 180 * Time.deltaTime);
            }

            _backseatAnimatedAnimatedTranslation.Execute(then: () =>
            {
                _backseatAnimatedAnimatedTranslation.Reset();
                GameSingleton.Instance.UpdateGame(View.Driver, _driver);
                Debug.Log("current view is now Driver (backseat)");
            });
        }
    }
}
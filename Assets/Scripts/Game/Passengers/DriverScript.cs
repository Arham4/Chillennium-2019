using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class DriverScript : MonoBehaviour
    {
        [SerializeField] private const float TurningSpeed = 5f;
        private TriggerableAnimatedAnimatedTranslation _shotgunAnimatedAnimatedTranslation;
        private TriggerableAnimatedAnimatedTranslation _movementAnimatedAnimatedTranslation;
        private GameObject _car;
        private GameObject _shotgun;
        private Camera _camera;
        private float _actualSpeed;

        private void Start()
        {
            _shotgun = GameObject.Find("Shotgun");
            if (_shotgun == null)
            {
                Debug.LogError("Shotgun is null!");
                return;
            }

            var shotgunTransform = _shotgun.transform;
            if (Camera.main == null)
            {
                Debug.LogError("Main camera is null! (Driver)");
                return;
            }

            _camera = Camera.main;
            _shotgunAnimatedAnimatedTranslation = new TriggerableAnimatedAnimatedTranslation(Camera.main.gameObject,
                shotgunTransform, 25, offset: new Vector3(0, shotgunTransform.lossyScale.y * 0.65f));
            _car = GameObject.Find("Car");
            if (_car == null)
            {
                Debug.LogError("Car is null!");
                return;
            }

            _actualSpeed = TurningSpeed;
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Driver)
            {
                return;
            }
            
            if (GameSingleton.Instance.currentSongType == Radio.SongType.Pump)
            {
                _actualSpeed = TurningSpeed * 3f;
            }
            else
            {
                _actualSpeed = TurningSpeed;
            }

            UpdateMovement();
            UpdatePassengerSwitching();

            if(transform.position.x >= 843f || transform.position.x <= 219f)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        private void UpdateMovement()
        {
            if (GameSingleton.Instance.cameraDisruption)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _camera.transform.Translate(-_actualSpeed, 0, 0);
                _car.transform.Translate(-_actualSpeed, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _camera.transform.Translate(_actualSpeed, 0, 0);
                _car.transform.Translate(_actualSpeed, 0, 0);
            }
        }

        private void UpdatePassengerSwitching()
        {
            if (Input.GetKeyDown("space"))
            {
                _shotgunAnimatedAnimatedTranslation.Trigger();
            }

            _shotgunAnimatedAnimatedTranslation.Execute(then: () =>
            {
                _shotgunAnimatedAnimatedTranslation.Reset();
                GameSingleton.Instance.UpdateGame(View.Shotgun, _shotgun);
                Debug.Log("current view is now Shotgun");
            });
        }
    }
}
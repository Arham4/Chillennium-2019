using UnityEngine;

namespace Game
{
    public class ShotgunScript : MonoBehaviour
    {
        private GameObject _backseat;
        private TriggerableAnimatedAnimatedTranslation _backseatAnimatedAnimatedTranslation;
        private GameObject _zombies;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _backseat = GameObject.Find("Backseat");
            if (_backseat == null)
            {
                Debug.LogError("Backseat is null!");
                return;
            }

            _zombies = GameObject.Find("Zombies");
            if (_zombies == null)
            {
                Debug.LogError("Zombies are null!");
                return;
            }

            var backseatTransform = _backseat.transform;
            if (Camera.main == null)
            {
                Debug.LogError("Main camera is null! (Shotgun)");
                return;
            }

            _backseatAnimatedAnimatedTranslation = new TriggerableAnimatedAnimatedTranslation(Camera.main.gameObject,
                backseatTransform, 25, offset: new Vector3(0, backseatTransform.lossyScale.y * 0.65f));
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Shotgun)
            {
                return;
            }

            if (Input.GetKeyDown("space"))
            {
                _backseatAnimatedAnimatedTranslation.Trigger();
            }

            if (_backseatAnimatedAnimatedTranslation.isTrigger() && !_backseatAnimatedAnimatedTranslation.isFinished())
            {
                Quaternion rotateDirection =
                    Quaternion.LookRotation(_zombies.transform.position - _camera.transform.position +
                                            new Vector3(-40, 0, 0));
                _camera.transform.rotation =
                    Quaternion.RotateTowards(_camera.transform.rotation, rotateDirection, 180 * Time.deltaTime);
            }

            _backseatAnimatedAnimatedTranslation.Execute(then: () =>
            {
                _backseatAnimatedAnimatedTranslation.Reset();
                GameSingleton.Instance.UpdateGame(View.Backseat, _backseat);
                Debug.Log("current view is now Backseat");
            });
        }
    }
}
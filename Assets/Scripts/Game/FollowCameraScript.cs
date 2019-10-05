using UnityEngine;

namespace Game
{
    public class FollowCameraScript : MonoBehaviour
    {
        [SerializeField] private const int StabilizationSpeed = 20;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentGameObject == null || GameSingleton.Instance.cameraDisruption)
            {
                return;
            }

            var transform = GameSingleton.Instance.currentGameObject.transform;
            _camera.transform.position = transform.position + new Vector3(0, transform.lossyScale.y * 0.65f, -5);
        }
    }
}
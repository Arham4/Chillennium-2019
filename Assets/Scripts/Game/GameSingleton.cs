using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class GameSingleton : Singleton<GameSingleton>
    {
        public View? currentView = null;
        [CanBeNull] public GameObject currentGameObject = null;
        public bool cameraDisruption;

        public void UpdateGame(View view, GameObject gameObject)
        {
            currentView = view;
            currentGameObject = gameObject;
        }
    }

    public enum View
    {
        Driver,
        Shotgun,
        Backseat
    }
}
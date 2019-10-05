using UnityEngine.Serialization;

namespace Game
{
    public class GameSingleton : Singleton<GameSingleton>
    {
        public View? currentView = null;
    }

    public enum View
    {
        Driver,
        Shotgun,
        Backseat
    }
}
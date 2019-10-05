using UnityEngine;

namespace Game.Gun
{
    public interface IBullet
    {
        void Fire(Vector3 endLocation);
        int GetDamage();
    }
}
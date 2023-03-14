using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "BulletSO", menuName ="ScriptableObjects/NewBullet")]
    public class BulletSO : ScriptableObject
    {
        public BulletType bulletType;
        public float damage;
        public float speed;
    }
}

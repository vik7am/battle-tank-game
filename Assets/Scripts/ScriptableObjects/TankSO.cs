using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankSO", menuName ="ScriptableObjects/NewTank")]
    public class TankSO : ScriptableObject
    {
        public TankType tankType;
        public BulletType bulletType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public Material material;
    }
}

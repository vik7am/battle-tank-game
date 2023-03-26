using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "EnemyTankSO", menuName ="ScriptableObjects/EnemyTank")]
    public class EnemyTankSO : ScriptableObject
    {
        public TankType tankType;
        public BulletType bulletType;
        public float health;
        public float movementSpeed;
        public float rotationSpeed;
        public Material material;
        public float chaseRange;
        public float attackRange;
    }
}

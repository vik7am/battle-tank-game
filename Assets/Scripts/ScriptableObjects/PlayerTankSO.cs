using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "PlayerTankSO", menuName = "ScriptableObjects/PlayerTank")]
    public class PlayerTankSO : ScriptableObject
    {
        public TankType tankType;
        public BulletType bulletType;
        public float health;
        public float movementSpeed;
        public float rotationSpeed;
        public Material material;
        public int penaltyScore;
    }
}

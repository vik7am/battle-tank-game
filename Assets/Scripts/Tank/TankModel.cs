using UnityEngine;
namespace BattleTank
{
    public struct TankModel
    {
        public TankType tankType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public Material material;

        public TankModel(TankSO tankSO){
            tankType = tankSO.tankType;
            health = tankSO.health;
            damage = tankSO.damage;
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            material = tankSO.material;
        }
    }
}

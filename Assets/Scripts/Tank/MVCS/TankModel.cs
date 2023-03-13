using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {
        public TankType tankType;
        public BulletType bulletType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public Material material;

        public TankModel(TankSO tankSO){
            tankType = tankSO.tankType;
            bulletType = tankSO.bulletType;
            health = tankSO.health;
            damage = tankSO.damage;
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            material = tankSO.material;
        }
    }
}

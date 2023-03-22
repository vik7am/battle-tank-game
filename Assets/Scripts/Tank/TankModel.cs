using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {
        public TankType tankType {get;}
        public BulletType bulletType {get;}
        public float health {get;}
        public float damage {get;}
        public float movementSpeed {get;}
        public float rotationSpeed {get;}
        public Material material {get;}

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

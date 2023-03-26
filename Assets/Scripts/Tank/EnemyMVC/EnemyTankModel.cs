using UnityEngine;

namespace BattleTank
{
    public class EnemyTankModel
    {
        public TankType tankType {get;}
        public BulletType bulletType {get;}
        public float health {get;}
        public float movementSpeed {get;}
        public float rotationSpeed {get;}
        public Material material {get;}
        public float chaseRange {get;}
        public float attackRange {get;}

        public EnemyTankModel(EnemyTankSO enemyTankSO){
            tankType = enemyTankSO.tankType;
            bulletType = enemyTankSO.bulletType;
            health = enemyTankSO.health;
            movementSpeed = enemyTankSO.movementSpeed;
            rotationSpeed = enemyTankSO.rotationSpeed;
            material = enemyTankSO.material;
            chaseRange = enemyTankSO.chaseRange;
            attackRange = enemyTankSO.attackRange;
        }
    }
}

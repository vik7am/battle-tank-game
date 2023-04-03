using UnityEngine;

namespace BattleTank
{
    public class EnemyTankModel
    {
        public TankType tankType {get;}
        public BulletType bulletType {get;}
        public float maxHealth {get;}
        public float movementSpeed {get;}
        public float rotationSpeed {get;}
        public Material material {get;}
        public float chaseRange {get;}
        public float attackRange {get;}
        public float currentHealth {get; private set;}
        public bool isAlive {get; private set;}

        public EnemyTankModel(EnemyTankSO enemyTankSO){
            tankType = enemyTankSO.tankType;
            bulletType = enemyTankSO.bulletType;
            maxHealth = enemyTankSO.health;
            movementSpeed = enemyTankSO.movementSpeed;
            rotationSpeed = enemyTankSO.rotationSpeed;
            material = enemyTankSO.material;
            chaseRange = enemyTankSO.chaseRange;
            attackRange = enemyTankSO.attackRange;
            currentHealth = maxHealth;
            isAlive = true;
        }

        public void SetCurrentHealth(float health){
            currentHealth = Mathf.Clamp(health, 0, maxHealth);
            SetIsAlive();
        }

        public void SetIsAlive(){
            isAlive = currentHealth != 0;
        }
    }
}

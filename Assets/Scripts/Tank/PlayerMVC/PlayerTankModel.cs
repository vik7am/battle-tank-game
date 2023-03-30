using UnityEngine;

namespace BattleTank
{
    public class PlayerTankModel
    {
        public TankType tankType {get;}
        public BulletType bulletType {get;}
        public float maxHealth {get;}
        public float movementSpeed {get;}
        public float rotationSpeed {get;}
        public Material material {get;}
        public float currentHealth {get; private set;}
        public bool isAlive {get; private set;}

        public PlayerTankModel(PlayerTankSO playerTankSO){
            tankType = playerTankSO.tankType;
            bulletType = playerTankSO.bulletType;
            maxHealth = playerTankSO.health;
            movementSpeed = playerTankSO.movementSpeed;
            rotationSpeed = playerTankSO.rotationSpeed;
            material = playerTankSO.material;
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

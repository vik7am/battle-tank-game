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
        public float penaltyScore {get;}
        public float currentHealth {get; private set;}
        public float score {get; private set;}
        public bool isAlive {get; private set;}

        public PlayerTankModel(PlayerTankSO playerTankSO){
            tankType = playerTankSO.tankType;
            bulletType = playerTankSO.bulletType;
            maxHealth = playerTankSO.health;
            movementSpeed = playerTankSO.movementSpeed;
            rotationSpeed = playerTankSO.rotationSpeed;
            material = playerTankSO.material;
            penaltyScore = playerTankSO.penaltyScore;
            currentHealth = maxHealth;
            score = 0;
            isAlive = true;
        }

        public void UpdateScore(float score){
            this.score += score;
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

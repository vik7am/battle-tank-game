using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        private TankModel tankModel;
        private float currentHealth;
        private PlayerTankView playerTankView;
        private PlayerInput playerInput;

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView, Vector3 spawnPoistion, PlayerInput playerInput){
            this.tankModel = tankModel;
            currentHealth = tankModel.health;
            this.playerTankView = playerTankView;
            this.playerInput = playerInput;
            Initialize(spawnPoistion);
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);
            PlayerTankSpawner.Instance.SetCameraToFollowPlayer(playerTankView.transform);
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
        }

        public void FireBullet(){
            Vector3 bulletSPos = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletQ = playerTankView.bulletSpawPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSPos, bulletQ, tankModel.bulletType);
        }

        public Vector3 GetMovementVelocity(){
            return playerInput.GetPlayerVI() * tankModel.movementSpeed * playerTankView.transform.forward;
        }

        public float GetRotationAngle(){
            return playerInput.GetPlayerHI() * tankModel.rotationSpeed;
        }
    }
}

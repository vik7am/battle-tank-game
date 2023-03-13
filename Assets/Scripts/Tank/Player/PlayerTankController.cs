using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        protected TankModel tankModel;
        protected float currentHealth;
        protected PlayerTankView playerTankView;

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView, Vector3 spawnPoistion){
            this.tankModel = tankModel;
            currentHealth = tankModel.health;
            this.playerTankView = playerTankView;
            Initialize(spawnPoistion);
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(playerTankView.transform);
        }

        public void FireBullet(){
            Vector3 bulletSPos = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletQ = playerTankView.bulletSpawPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSPos, bulletQ, tankModel.bulletType);
        }

        public Vector3 GetMovementVelocity(){
            return TankService.Instance.GetPlayerVI() * tankModel.movementSpeed * playerTankView.transform.forward;
        }

        public float GetRotationAngle(){
            return TankService.Instance.GetPlayerHI() * tankModel.rotationSpeed;
        }
    }
}

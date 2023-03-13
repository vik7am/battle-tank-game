using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        private TankModel tankModel;
        private TankHealth tankHealth;
        private PlayerTankView playerTankView;
        private FixedJoystick Joystick;

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView, Vector3 spawnPoistion, FixedJoystick joystick){
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            this.playerTankView = playerTankView;
            this.Joystick = joystick;
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
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsAlive())
                return;
            playerTankView.DestroyTank();
        }

        public void FireBullet(){
            Vector3 bulletSPos = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletQ = playerTankView.bulletSpawPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSPos, bulletQ, tankModel.bulletType);
        }

        public Vector3 GetMovementVelocity(){
            return Joystick.Vertical * tankModel.movementSpeed * playerTankView.transform.forward;
        }

        public float GetRotationAngle(){
            return Joystick.Horizontal * tankModel.rotationSpeed;
        }

        public void CheckForPlayerInput(){
            if(Input.GetKeyDown(KeyCode.Space))
                FireBullet();
        }
    }
}

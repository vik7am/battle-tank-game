using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        private PlayerTankModel playerTankModel;
        private TankHealth tankHealth;
        private FixedJoystick Joystick;
        public PlayerTankView playerTankView {get; private set;}

        public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView, Vector3 spawnPosition){
            this.playerTankModel = playerTankModel;
            tankHealth = new TankHealth(playerTankModel.health);
            this.playerTankView = playerTankView;
            this.Joystick = TankService.Instance.GetFixedJoystick();
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);
            CameraService.Instance.StartFollowingPlayer(playerTankView.transform);
        }

        public Material GetMaterial(){
            return playerTankModel.material;
        }

        public void ReduceHealth(float damage){
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsDead())
                DestroyTank();
        }

        public void FireBullet(){
            Vector3 bulletSpawnPoint = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletRotation = playerTankView.bulletSpawPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSpawnPoint, bulletRotation, playerTankModel.bulletType);
        }
        public Vector3 GetMovementVelocity(){
            return Input.GetAxisRaw("VerticalUI") * playerTankModel.movementSpeed * playerTankView.transform.forward; //Keyboard Input code
            //return Joystick.Vertical * tankModel.movementSpeed * playerTankView.transform.forward; //Joystick Input code
        }

        public float GetRotationAngle(){
            return Input.GetAxisRaw("HorizontalUI") * playerTankModel.rotationSpeed; //Keyboard Input code
            //return Joystick.Horizontal * tankModel.rotationSpeed; //Joystick Input code
        }

        public void CheckForPlayerInput(){
            if(Input.GetKeyDown(KeyCode.Space))
                FireBullet();
        }

        public bool IsTankAlive(){
            return !tankHealth.IsDead();
        }

        private void DestroyTank(){
            CameraService.Instance.StopFollowingPlayer();
            playerTankView.ShowEffectAndDestroy();
            DestructionService.Instance.DestroyEverything();
        }

        public Vector3 GetTankPosition(){
            return playerTankView.transform.position;
        }
    }
}

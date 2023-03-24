using UnityEngine;
namespace BattleTank
{
    public class PlayerTankController
    {
        private TankHealth tankHealth;
        private FixedJoystick Joystick;
        public PlayerTankModel playerTankModel {get;}
        public PlayerTankView playerTankView {get; private set;}

        public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView, Vector3 spawnPosition){
            this.playerTankModel = playerTankModel;
            tankHealth = new TankHealth(playerTankModel.health);
            this.playerTankView = playerTankView;
            this.Joystick = UIService.Instance.GetFixedJoystick();
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);
            CameraService.Instance.StartFollowingPlayer(playerTankView.transform);
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

        public void FireBullet(){
            Vector3 bulletSpawnPoint = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletRotation = playerTankView.bulletSpawPoint.transform.rotation;
            BulletController bulletController = BulletService.Instance.SpawnBullet(bulletSpawnPoint, bulletRotation, playerTankModel.bulletType);
            bulletController.FireBullet(TankName.PLAYER_TANK);
            EventService.Instance.BulletFired(TankName.PLAYER_TANK);
        }

        public void TakeDmage(TankName shooter, float damage){
            if(tankHealth.IsDead())
                return;
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsDead()){
                EventService.Instance.TankDestroyed(shooter, TankName.PLAYER_TANK);
                DestroyTank();
            }
        }

        private void DestroyTank(){
            CameraService.Instance.StopFollowingPlayer();
            playerTankView.ShowEffectAndDestroy();
        }

        public bool IsTankAlive(){
            return !tankHealth.IsDead();
        }

        public Vector3 GetTankPosition(){
            return playerTankView.transform.position;
        }
    }
}

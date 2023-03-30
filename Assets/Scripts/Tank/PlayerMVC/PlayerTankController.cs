using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        private TankHealth tankHealth;
        private FixedJoystick Joystick;
        public PlayerTankModel playerTankModel {get;}
        public PlayerTankView playerTankView {get; private set;}
        private PlayerInput playerInput;

        public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView, Vector3 spawnPosition){
            this.playerTankModel = playerTankModel;
            tankHealth = new TankHealth(playerTankModel.health);
            this.playerTankView = playerTankView;
            this.Joystick = UIService.Instance.GetFixedJoystick();
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerInput = playerTankView.GetComponent<PlayerInput>();
            playerTankView.SetTankMaterial(playerTankModel.material);
            playerTankView.SetTankController(this);
            playerInput.SetPlayerTankController(this);
            CameraService.Instance.StartFollowingPlayer(playerTankView.transform);
        }

        public void FireBullet(){
            Vector3 bulletSpawnPoint = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletRotation = playerTankView.bulletSpawPoint.transform.rotation;
            BulletController bulletController = BulletService.Instance.SpawnBullet(playerTankModel.bulletType);
            bulletController.SetBulletTransform(bulletSpawnPoint, bulletRotation);
            bulletController.FireBullet(TankName.PLAYER_TANK);
        }

        public void TakeDmage(TankName shooter, float damage){
            if(tankHealth.IsDead())
                return;
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsDead()){
                EventService.Instance.OnTankDestroyed(shooter, TankName.PLAYER_TANK);
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

using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        public PlayerTankModel playerTankModel {get;}
        public PlayerTankView playerTankView {get; private set;}
        private PlayerInput playerInput;
        public static event System.Action<TankId> onTankDestroyed;
        public static event System.Action<float, float> onPlayerStatsUpdate;

        public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView, Vector3 spawnPosition){
            this.playerTankModel = playerTankModel;
            this.playerTankView = playerTankView;
            BulletController.onBulletHit += UpdatePlayerScore;
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition){
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView, spawnPosition, Quaternion.identity);
            playerInput = playerTankView.GetComponent<PlayerInput>();
            playerTankView.SetTankMaterial(playerTankModel.material);
            playerTankView.SetTankController(this);
            playerInput.SetPlayerTankController(this);
            CameraService.Instance.StartFollowingPlayer(playerTankView.transform);
            onPlayerStatsUpdate?.Invoke(playerTankModel.currentHealth, playerTankModel.score);
        }

        public void FireBullet(){
            Vector3 bulletSpawnPoint = playerTankView.bulletSpawPoint.transform.position;
            Quaternion bulletRotation = playerTankView.bulletSpawPoint.transform.rotation;
            BulletController bulletController = BulletService.Instance.SpawnBullet(playerTankModel.bulletType);
            bulletController.SetBulletTransform(bulletSpawnPoint, bulletRotation);
            bulletController.FireBullet(TankId.PLAYER);
        }

        public void TakeDmage(TankId shooter, float damage){
            if(playerTankModel.isAlive == false)
                return;
            playerTankModel.SetCurrentHealth(playerTankModel.currentHealth - damage);
            onPlayerStatsUpdate?.Invoke(playerTankModel.currentHealth, playerTankModel.score);
            if(playerTankModel.isAlive == false){
                onTankDestroyed?.Invoke(shooter);
                DestroyTank();
            }
        }

        private void DestroyTank(){
            CameraService.Instance.StopFollowingPlayer();
            playerTankView.ShowEffectAndDestroy();
        }

        private void UpdatePlayerScore(TankId shooter, TankId reciever, float damage){
            if(shooter == TankId.PLAYER){
                float score = (reciever == TankId.ENEMY)? damage: -playerTankModel.penaltyScore;
                playerTankModel.UpdateScore(score);
                onPlayerStatsUpdate?.Invoke(playerTankModel.currentHealth, playerTankModel.score);
            }
        }
    }
}

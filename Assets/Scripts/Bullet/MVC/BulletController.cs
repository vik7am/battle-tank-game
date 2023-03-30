using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        public BulletModel bulletModel {get;}
        public BulletView bulletView {get; private set;}
        public TankName tankName {get; private set;}

        public BulletController(BulletModel bulletModel, BulletView bulletView){
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            Instantiate();
        }

        public void Instantiate(){
            bulletView = ObjectPoolService.Instance.bulletPool.GetItem();
            bulletView.SetBulletController(this);
        }

        public void SetBulletTransform(Vector3 spawnPoint, Quaternion rotation){
            bulletView.transform.position = spawnPoint;
            bulletView.transform.rotation = rotation;
            bulletView.gameObject.SetActive(true);
        }

        public void FireBullet(TankName tankName){
            this.tankName = tankName;
            bulletView.SetVelocity(bulletModel.speed);
            EventService.Instance.OnBulletFired(tankName);
        }
    }
}

using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        public BulletModel bulletModel {get;}
        public BulletView bulletView {get; private set;}
        public TankName tankName {get; private set;}

        public BulletController(BulletModel bulletModel, BulletView bulletView, Vector3 spawnPoint, Quaternion rotation){
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            Instantiate(spawnPoint, rotation);
        }

        public void Instantiate(Vector3 spawnPoint, Quaternion rotation){
            bulletView = GameObject.Instantiate<BulletView>(bulletView, spawnPoint, rotation);
            bulletView.SetBulletController(this);
        }

        public void FireBullet(TankName tankName){
            this.tankName = tankName;
            bulletView.SetVelocity(bulletModel.speed);
        }
    }
}

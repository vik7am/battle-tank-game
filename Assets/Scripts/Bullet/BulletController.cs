using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;

        public BulletController(BulletModel bulletModel, BulletView bulletView, Vector3 spawnPoint, Quaternion rotation){
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            Instantiate(spawnPoint, rotation);
        }

        public void Instantiate(Vector3 spawnPoint, Quaternion rotation){
            bulletView = GameObject.Instantiate<BulletView>(bulletView, spawnPoint, rotation);
            bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed(){
            return bulletModel.speed;
        }

        public float GetBulletDamage(){
            return bulletModel.damage;
        }
    }
}

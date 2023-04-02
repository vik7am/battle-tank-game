using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        public BulletModel bulletModel {get;}
        public BulletView bulletView {get; private set;}
        public TankId tankId {get; private set;}
        public static event System.Action<TankId> onBulletFired;
        public static event System.Action<TankId, TankId, float> onBulletHit;

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

        public void FireBullet(TankId tankId){
            this.tankId = tankId;
            bulletView.SetVelocity(bulletModel.speed * bulletView.transform.forward);
            onBulletFired?.Invoke(tankId);
        }

        public void BulletCollision(Collider other){
            if(other.GetComponent<IDamageable>() != null){
                IDamageable damagableObject = other.GetComponent<IDamageable>();
                damagableObject.Damage(tankId, bulletModel.damage);
                onBulletHit?.Invoke(tankId, damagableObject.GetTankId(), bulletModel.damage);
            }
            else{
                onBulletHit?.Invoke(tankId, TankId.NONE, 0);
            }
            ParticleEffectService.Instance.ShowParticleEffect(bulletView.transform.position, ParticleEffectType.BULLET_EXPLOSION);
            ObjectPoolService.Instance.bulletPool.ReturnItem(bulletView);
        }
    }
}

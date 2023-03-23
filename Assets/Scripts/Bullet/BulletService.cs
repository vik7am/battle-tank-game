using UnityEngine;

namespace BattleTank
{
    public class BulletService : GenericSingleton<BulletService>
    {
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletListSO bulletListSO;

        public BulletController SpawnBullet(Vector3 spawnPoint, Quaternion rotation, BulletType bulletType){
            for(int i=0; i<bulletListSO.bulletSO.Length; i++)
                if(bulletListSO.bulletSO[i].bulletType == bulletType)
                    bulletModel = new BulletModel(bulletListSO.bulletSO[i]);
            return new BulletController(bulletModel, bulletView, spawnPoint, rotation);
        }
    }
}

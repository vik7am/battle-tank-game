using UnityEngine;

namespace BattleTank
{
    public class BulletService : GenericSingleton<BulletService>
    {
        private BulletController bulletController;
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletListSO bulletListSO;

        public void SpawnBullet(Vector3 spawnPoint, Quaternion rotation, BulletType bulletType){
            for(int i=0; i<bulletListSO.bulletSO.Length; i++)
                if(bulletListSO.bulletSO[i].bulletType == bulletType)
                    bulletModel = new BulletModel(bulletListSO.bulletSO[i]);
            bulletController = new BulletController(bulletModel, bulletView, spawnPoint, rotation);
        }
    }
}

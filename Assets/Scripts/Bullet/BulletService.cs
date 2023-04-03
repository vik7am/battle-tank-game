using UnityEngine;

namespace BattleTank
{
    public class BulletService : GenericMonoSingleton<BulletService>
    {
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletListSO bulletListSO;

        public BulletController GetBulletController(BulletType bulletType){
            for(int i=0; i<bulletListSO.bulletSO.Length; i++){
                if(bulletListSO.bulletSO[i].bulletType == bulletType){
                    bulletModel = new BulletModel(bulletListSO.bulletSO[i]);
                }
            }
            return new BulletController(bulletModel, bulletView);
        }
    }
}

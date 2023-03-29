using UnityEngine;

namespace BattleTank
{
    public class BulletPoolService : GenericObjectPool<BulletView>
    {
        [SerializeField] private BulletView prefab;
        [SerializeField] private int poolSize;

        protected override void SetPrefab(){
            itemPrefab =  prefab;
        }

        protected override void SetInitialPoolSize(){
            initialPoolSize = poolSize;
        }
    }
}

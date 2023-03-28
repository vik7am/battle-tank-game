using UnityEngine;

namespace BattleTank
{
    public class BulletPoolService : GenericObjectPool<BulletView>
    {
        [SerializeField] private BulletView prefab;

        protected override void SetPrefab(){
            itemPrefab =  prefab;
        }
    }
}

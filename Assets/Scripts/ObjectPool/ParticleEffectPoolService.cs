using UnityEngine;

namespace BattleTank
{
    public class ParticleEffectPoolService : GenericObjectPool<ParticleSystem>
    {
        [SerializeField] private ParticleSystem prefab;
        [SerializeField] private int poolSize;
        
        protected override void SetPrefab(){
            itemPrefab =  prefab;
        }

        protected override void SetInitialPoolSize(){
            initialPoolSize = poolSize;
        }
    }
}

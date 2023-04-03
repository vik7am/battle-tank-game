using UnityEngine;

namespace BattleTank
{
    public class ObjectPoolService : GenericMonoSingleton<ObjectPoolService>
    {
        public GenericObjectPool<BulletView> bulletPool {get; private set;}
        public GenericObjectPool<ParticleEffectView> particlePool {get; private set;}
        public GenericObjectPool<EnemyTankView> enemyTankPool {get; private set;}
        [SerializeField] private BulletView bulletPrefab;
        [SerializeField] private ParticleEffectView particlePrefab;
        [SerializeField] private EnemyTankView enemyTankPrefab;
        [SerializeField] private int bulletPoolSize;
        [SerializeField] private int particlePoolSize;
        [SerializeField] private int enemyTankPoolSize;

        private void Start() {
            bulletPool = new GenericObjectPool<BulletView>(bulletPrefab, bulletPoolSize);
            particlePool = new GenericObjectPool<ParticleEffectView>(particlePrefab, particlePoolSize);
            enemyTankPool = new GenericObjectPool<EnemyTankView>(enemyTankPrefab, enemyTankPoolSize);
        }
    }
}

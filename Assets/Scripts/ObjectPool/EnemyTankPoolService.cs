using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyTankPoolService : GenericObjectPool<EnemyTankView>
    {
        [SerializeField] private EnemyTankView prefab;
        [SerializeField] private int poolSize;
        
        protected override void SetPrefab(){
            itemPrefab =  prefab;
        }

        protected override void SetInitialPoolSize(){
            initialPoolSize = poolSize;
        }
    }
}

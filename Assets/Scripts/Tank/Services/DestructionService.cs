using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class DestructionService : GenericSingleton<DestructionService>
    {
        private List<EnemyTankController> enemyTanks;
        [SerializeField] private Transform environment;
        [SerializeField] private float delay;
        private Coroutine destructionCoroutine;

        public void DestroyEverything(){
            if(destructionCoroutine != null)
                return;
            CameraService.Instance.SetCameraZoomOut(true);
            enemyTanks = EnemyTankSpawner.Instance.GetEnemyTankControllerList();
            destructionCoroutine = StartCoroutine(StartDestruction());
        }

        IEnumerator StartDestruction(){
            yield return StartCoroutine(DestroyEnemies());
            yield return StartCoroutine(DestroyEnvironment());
        }

        IEnumerator DestroyEnemies(){
            int n = enemyTanks.Count;
            yield return new WaitForSeconds(delay);
            for(int i=0; i<n; i++){
                if(enemyTanks[i].IsTankAlive() == false)
                    continue;
                enemyTanks[i].KillTank();
                yield return new WaitForSeconds(delay);
            }
        }

        IEnumerator DestroyEnvironment(){
            int n = environment.childCount;
            for(int i=n-1; i>=0; i--){
                yield return new WaitForSeconds(delay);
                Destroy(environment.GetChild(i).gameObject);
            }
            CameraService.Instance.SetCameraZoomOut(false);
        }
    }
}

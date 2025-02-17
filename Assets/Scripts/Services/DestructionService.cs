using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class DestructionService : GenericMonoSingleton<DestructionService>
    {
        private List<EnemyTankController> enemyTanks;
        [SerializeField] private Transform environment;
        [SerializeField] private float delay;
        private Coroutine destructionCoroutine;
        public static System.Action onDestructionStart;
        public static System.Action onDestructionEnd;

        private void Start(){
            PlayerTankController.onTankDestroyed += PlayerTankDestroyed;
        }

        public void PlayerTankDestroyed(TankId shooter){
            DestroyEverything();
        }

        public void DestroyEverything(){
            if(destructionCoroutine != null) // don't do anything is destruction is already in progress.
                return;
            onDestructionStart?.Invoke();    
            enemyTanks = TankService.Instance.enemyTCList;
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
                if(enemyTanks[i].enemyTankModel.isAlive == false){
                    continue;
                }
                enemyTanks[i].DestroyTank();
                yield return new WaitForSeconds(delay);
            }
        }

        IEnumerator DestroyEnvironment(){
            int n = environment.childCount;
            for(int i=n-1; i>=0; i--){
                yield return new WaitForSeconds(delay);
                environment.GetChild(i).gameObject.SetActive(false);
            }
            onDestructionEnd?.Invoke();
        }
    }
}

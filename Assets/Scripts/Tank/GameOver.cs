using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class GameOver : GenericSingleton<GameOver>
    {
        private List<EnemyTankController> enemyTanks;
        [SerializeField] private Transform environment;
        [SerializeField] private float delay;
        private bool moveCamera;
        private float cameraSize;

        private void Start() {
            moveCamera = false;
            cameraSize = 10;
        }

        public void DestroyEverything(){
            moveCamera = true;
            StartCoroutine(StartDestruction());
        }

        IEnumerator StartDestruction(){
            yield return StartCoroutine(DestroyEnemies());
            yield return StartCoroutine(DestroyEnvironment());
        }

        IEnumerator DestroyEnemies(){
            enemyTanks = EnemyTankSpawner.Instance.GetEnemyTankControllerList();
            int n = enemyTanks.Count;
            for(int i=0; i<n; i++){
                if(enemyTanks[i].DestroyTank() == false)
                    continue;
                yield return new WaitForSeconds(delay);
            }
        }

        IEnumerator DestroyEnvironment(){
            int n = environment.childCount;
            for(int i=n-1; i>0; i--){
                Destroy(environment.GetChild(i).gameObject);
                yield return new WaitForSeconds(delay);
            }
        }

        private void Update() {
            if(moveCamera){
                cameraSize += 1.0f * Time.deltaTime;
                Camera.main.orthographicSize = cameraSize;
            }
        }
    }
}

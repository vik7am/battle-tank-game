using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        private EnemyTankController enemyTankController;
        private Coroutine destroyCoroutine;

        public void SetTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
        }

        private void UpdateTankColor(){
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = enemyTankController.tankModel.material;
        }

        public void Damage(float damage){
            if(enemyTankController.tankHealth.IsDead())
                return;
            enemyTankController.tankHealth.ReduceHealth(damage);
            if(enemyTankController.tankHealth.IsDead())
                enemyTankController.DestroyTank();
        }
    }
}

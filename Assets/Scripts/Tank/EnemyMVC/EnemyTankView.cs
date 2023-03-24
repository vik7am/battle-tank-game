using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private EnemyTankController enemyTankController;
        private Coroutine destroyCoroutine;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;

        public void SetTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
        }

        private void UpdateTankColor(){
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = enemyTankController.enemyTankModel.material;
        }

        public void Damage(TankName shooter, float damage){
            enemyTankController.TakeDamage(shooter, damage);
        }

        public TankName GetTankName(){
            return TankName.ENEMY_TANK;
        }
    }
}

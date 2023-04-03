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
        }

        public void SetTankMaterial(Material material){
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }

        public void Damage(TankId shooter, float damage){
            enemyTankController.TakeDamage(shooter, damage);
        }

        public TankId GetTankId(){
            return TankId.ENEMY;
        }
    }
}

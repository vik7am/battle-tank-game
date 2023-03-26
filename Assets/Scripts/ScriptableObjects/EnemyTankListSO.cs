using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "EnemyTankListSO", menuName ="ScriptableObjects/EnemyTankList")]
    public class EnemyTankListSO : ScriptableObject
    {
        public EnemyTankSO[] enemyTankSO;
    }
}

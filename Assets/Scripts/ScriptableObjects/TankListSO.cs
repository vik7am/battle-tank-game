using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankListSO", menuName ="ScriptableObjects/TankList")]
    public class TankListSO : ScriptableObject
    {
        public TankSO[] tankSO;
    }
}

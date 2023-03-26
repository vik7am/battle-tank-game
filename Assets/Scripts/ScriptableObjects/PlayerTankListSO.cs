using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "PlayerTankListSO", menuName ="ScriptableObjects/PlayerTankList")]
    public class PlayerTankListSO : ScriptableObject
    {
        public PlayerTankSO[] playerTankSO;
    }
}

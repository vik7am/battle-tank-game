using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankPatrolPathListSO", menuName ="ScriptableObjects/TankPatrolPathList")]
    public class TankPatrolPathListSO : ScriptableObject
    {
        public TankPatrolPathSO[] patrolPathList;
    }
}

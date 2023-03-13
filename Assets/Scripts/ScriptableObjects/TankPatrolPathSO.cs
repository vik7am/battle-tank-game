using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankPatrolPathSO", menuName ="ScriptableObjects/TankPatrolPath")]
    public class TankPatrolPathSO : ScriptableObject
    {
        public Vector3[] patrolPath;
    }
}

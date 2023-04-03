using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public static class Utility
    {
        public static bool FindRandomPositionInRange(out Vector3 result, Vector3 center, float range){
            NavMeshHit hit;
            Vector3 randomPoint = center + range * Random.insideUnitSphere;
            if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas)){
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }

        public static void SetYAxisToZero(this Vector3 position){
            position = new Vector3(position.x, 0, position.z);
        }
    }
}

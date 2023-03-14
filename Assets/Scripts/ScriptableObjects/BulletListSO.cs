using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "BulletListSO", menuName ="ScriptableObjects/BulletList")]
    public class BulletListSO : ScriptableObject
    {
        public BulletSO[] bulletSO;
    }
}

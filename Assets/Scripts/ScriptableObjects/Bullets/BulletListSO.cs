using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "BulletListSO", menuName ="ScriptableObjects/BulletList")]
    public class BulletListSO : ScriptableObject
    {
        public BulletSO[] bulletSO;
    }
}

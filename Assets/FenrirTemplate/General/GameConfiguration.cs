using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fenrir.Resources
{

    [CreateAssetMenu(fileName = "Game Configuration", menuName = "Fenrir/Game Confugiration")]
    public class GameConfiguration : ScriptableObject
    {
        public float FullSwipeAngle;
        public float RotationSpeed;
        public float ThresholdScreenDivider;
    }
}
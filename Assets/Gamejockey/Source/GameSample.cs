using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [CreateAssetMenu(fileName = "track", menuName = "GameJockey/Game Track", order = 1)]
    [System.Serializable]
    public class GameSample : ScriptableObject
    {
        // Settings
        public new string name = "My Game Track";
        public int BPM = 90;

        // Assets
        public GameObject[] assets;

        // Scenarios
        public Scenario[] scenarios;
    }
}
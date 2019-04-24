using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [CreateAssetMenu(fileName = "track", menuName = "GameJockey/Game Sample", order = 1)]
    [System.Serializable]
    public class GameSample : ScriptableObject
    {
        [Header("Sample Datas")]
        public new string name = "My Game Sample";
        public string author = "Alineaire";
        public int BPM = 90;
        public int duration = 300; // in seconds

        [Header("Assets")]
        // Assets
        public GameObject[] assets;

        [Header("Global scenario settings")]
        // Players
        public string[] players;
        public string camera;
        public string light;

        [Header("Scenarios")]
        // Scenarios
        public Scenario[] scenarios;
    }
}
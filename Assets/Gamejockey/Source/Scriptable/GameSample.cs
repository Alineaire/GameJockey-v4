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
        public PlayerSampleParams[] defaultPlayers;
        public string camera;
        public string light;

        [Header("Scenarios")]
        // Scenarios
        public SampleScenario[] scenarios;
    }

    [System.Serializable]
    public class PlayerSampleParams
    {
        public string playerAsset;
        public int inputIndex;
        //public Vector3 defaultPosition;
    }

    [System.Serializable]
    public class SampleScenario
    {
        public string name;
        public bool useDefaultPlayers = true;
        public PlayerSampleParams[] newPlayers;
        public string[] objects;
        public string environment;
    }
}
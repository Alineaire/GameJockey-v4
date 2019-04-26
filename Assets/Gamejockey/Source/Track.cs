using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class Track
    {
        public string name;
        public GameObject sceneGameObject;
        public GameObject[] players;
        public TrackGameComponent camera;
        public TrackGameComponent light;
        public List<TrackScenario> scenarios;

        public Track()
        {
            camera = new TrackGameComponent();
            light = new TrackGameComponent();
            scenarios = new List<TrackScenario>();
        }
    }

    [System.Serializable]
    public class TrackGameComponent
    {
        public bool isActive = false;
        public GameObject current;
    }

    [System.Serializable]
    public class TrackScenario : TrackGameComponent
    {
        public TrackGameComponent objects;
        public TrackGameComponent environment;

        public TrackScenario()
        {
            objects = new TrackGameComponent();
            environment = new TrackGameComponent();
        }
    }
}
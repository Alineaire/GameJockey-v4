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

        public void SetActiveTrack(bool _b)
        {
            sceneGameObject.SetActive(_b);
        }

        public void SetActivePlayers(bool _b)
        {
            foreach(GameObject player in players)
            {
                player.SetActive(_b);
            }
        }

        public void SetActiveCamera(bool _b)
        {
            camera.current.SetActive(_b);
        }

        public void SetActiveLight(bool _b)
        {
            light.current.SetActive(_b);
        }

        public void SetActiveEnvironment(bool _b)
        {
            foreach(TrackScenario scenario in scenarios)
            {
                scenario.environment.current.SetActive(_b);
            }
        }

        public void SetActiveObject(bool _b)
        {
            foreach (TrackScenario scenario in scenarios)
            {
                scenario.objects.current.SetActive(_b);
            }
        }

        public void SetActiveScenario(int _index, bool _b)
        {
            if (_index < 0
                || _index > scenarios.Count
                || scenarios[_index] == null)
                return;

            scenarios[_index].current.SetActive(_b);
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
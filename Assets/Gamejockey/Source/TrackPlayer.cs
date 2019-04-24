using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class TrackPlayer : MonoBehaviour
    {
        public string trackName = "Track";
        public GameSample referenceSample;
        public TrackUI trackUI;

        // Scene Structure
        public GameObject[] players;
        public GameObject trackGameObject;

        void CreateTrackContent(GameSample _sample)
        {
            GameObject _camera;
            GameObject _light;
            GameObject _players;
            GameObject _road;
            GameObject _obstacle;

            // reset Game Object Track
            if (trackGameObject != null)
                Destroy(trackGameObject);

            trackGameObject = new GameObject(trackName + " - " + referenceSample.name);

            // Create new GameObject track
            _camera = CreateGameObjectByName(referenceSample.camera);
            _light = CreateGameObjectByName(referenceSample.light);

            foreach(var _scenario in referenceSample.scenarios)
            {
                GameObject _scenarioGameObject = CreateGameObjectGroup("Scenario - (name)", trackGameObject.transform);
                CreateGameObjectGroup("Players", _scenarioGameObject.transform);
                CreateGameObjectGroup("Road", _scenarioGameObject.transform);
                CreateGameObjectGroup("Obstacle", _scenarioGameObject.transform);
            }

            // Reset Track UI
            trackUI.SetTrackName(referenceSample.name);
            trackUI.SetBPM(referenceSample.BPM.ToString());
            trackUI.SetAuthor(referenceSample.author);
            trackUI.SetDuration(referenceSample.duration.ToString());
        }

        GameObject CreateGameObjectGroup(string _name, Transform _parent)
        {
            GameObject _tempGameObject = new GameObject(_name);

            _tempGameObject.transform.parent = _parent;

            return _tempGameObject;
        }

        GameObject CreateGameObjectByName(string _assetName)
        {
            GameObject _tempGameObject = Instantiate(
                JockeyUtilities.FindAssetByName(
                    referenceSample.assets, 
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = trackGameObject.transform;
            return _tempGameObject;
        }

        public void PlayTrack()
        {

        }

        public void LoadSample(GameSample _sample)
        {
            referenceSample = _sample;
            CreateTrackContent(referenceSample);
        }
    }
}

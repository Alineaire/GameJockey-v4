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
        public GameObject currentCamera, currentLight, currentAvatars, currentObstacle, currentEnvironment;

        public enum TrackComponentEnum
        {
            camera,
            light,
            avatars,
            obstacle,
            environment
        };

        void CreateTrackContent(GameSample _sample)
        {
            GameObject _camera;
            GameObject _light;

            // reset Game Object Track
            if (trackGameObject != null)
                Destroy(trackGameObject);

            trackGameObject = new GameObject(trackName + " - " + referenceSample.name);

            // Create new GameObject track
            _camera = CreateGameObjectByName(referenceSample.camera);
            _light = CreateGameObjectByName(referenceSample.light);

            foreach(var _scenario in referenceSample.scenarios)
            {
                GameObject _scenarioGameObject;
                GameObject _playerGroup;
                GameObject _environmentGroup;
                GameObject _obstacleGroup;

                // Create scenario
                _scenarioGameObject = CreateGroup("Scenario - (name)", trackGameObject.transform);

                // Create uniform-game-sample groups
                _playerGroup = CreateGroup("Players", _scenarioGameObject.transform);
                _environmentGroup = CreateGameObjectByName(_scenario.environment, _scenarioGameObject.transform);
                _obstacleGroup = CreateGameObjectByName(_scenario.obstacle, _scenarioGameObject.transform);

                // Create Players
                for(int _playerIndex=0; _playerIndex < referenceSample.players.Length; _playerIndex++)
                {
                    GameObject _playerInstance = CreateGameObjectByName(referenceSample.players[_playerIndex].playerAsset, _playerGroup.transform);
                    _playerInstance.transform.position = referenceSample.players[_playerIndex].defaultPosition;
                }

                currentAvatars = _playerGroup;
                currentEnvironment = _environmentGroup;
                currentObstacle = _obstacleGroup;
            }

            // Set Global current GameObject
            currentCamera = _camera;
            currentLight = _light;

            // Reset Track UI
            trackUI.SetTrackName(referenceSample.name);
            trackUI.SetBPM(referenceSample.BPM.ToString());
            trackUI.SetAuthor(referenceSample.author);
            trackUI.SetDuration(referenceSample.duration.ToString());
        }

        GameObject CreateGroup(string _name, Transform _parent)
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

        GameObject CreateGameObjectByName(string _assetName, Transform _parent)
        {
            GameObject _tempGameObject = Instantiate(
                JockeyUtilities.FindAssetByName(
                    referenceSample.assets,
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = _parent;
            return _tempGameObject;
        }

        public void SetTrackComponentVisibility(TrackComponentEnum _component, bool _visbility)
        {
            // if no referenceSample loaded, it shouldnt find GameObject to Active
            if (referenceSample == null)
                return;

            switch(_component)
            {
                case TrackComponentEnum.camera:
                    currentCamera.SetActive(_visbility);
                    break;
                case TrackComponentEnum.light:
                    currentLight.SetActive(_visbility);
                    break;
                case TrackComponentEnum.avatars:
                    currentAvatars.SetActive(_visbility);
                    break;
                case TrackComponentEnum.obstacle:
                    currentObstacle.SetActive(_visbility);
                    break;
                case TrackComponentEnum.environment:
                    currentEnvironment.SetActive(_visbility);
                    break;
            }
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

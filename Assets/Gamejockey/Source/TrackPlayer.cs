using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class TrackPlayer : MonoBehaviour
    {
        public string trackName = "Track";
        public GameSample sample;
        public TrackUI trackUI;

        // Scene Structure
        public GameObject[] players;
        public GameObject trackSceneGameObject;
        //public TrackGameComponent trackCamera, trackLight, trackObject, trackEnvironment;

        public Track trackInstance;

        public enum TrackComponentEnum
        {
            camera,
            light,
            avatars,
            obstacle,
            environment
        };

        // User -> choose Sample
        // Called by UI to load new sample on track
        public void LoadSample(GameSample _sample)
        {
            sample = _sample;
            CreateTrack();
            CreateTrackContent();
            RefreshUI();
            RefreshEditableTrack();
            // TODO n'activer que le Track sur lequel on se trouve dans la Timeline
        }

        // Sample -> Track
        void CreateTrack()
        {
            if (sample == null)
                return;

            if (trackSceneGameObject != null)
                Destroy(trackSceneGameObject);

            trackInstance = new Track();

        }

        // Track -> Scene Content
        void CreateTrackContent()
        {
            if (trackInstance == null)
                return;

            trackSceneGameObject = new GameObject(trackName + " - " + sample.name);

            // Create new GameObject track
            trackInstance.camera.current    = CreateGameObjectByName(sample.camera);
            trackInstance.light.current     = CreateGameObjectByName(sample.light);

            trackInstance.scenarios = new List<TrackScenario>();

            foreach (SampleScenario _scenario in sample.scenarios)
            {
                // Init temp variables
                TrackScenario       _trackScenario = new TrackScenario();
                GameObject          _scenarioGroup;
                GameObject          _objectGroup;
                GameObject          _environment;
                GameObject          _playersGroup;
                List<GameObject>    _objectList;

                // Create Groups
                _scenarioGroup  = CreateGroup("Scenario " + _scenario.name, trackSceneGameObject.transform);
                _playersGroup = CreateGroup("Players", _scenarioGroup.transform);
                _objectGroup    = CreateGroup("Objects", _scenarioGroup.transform);

                // Create Players
                if(_scenario.useDefaultPlayers)
                {
                    foreach(PlayerSampleParams _player in sample.defaultPlayers)
                    {
                        CreateGameObjectByName(_player.playerAsset, _objectGroup.transform);
                    }
                }
                else
                {
                    foreach (PlayerSampleParams _player in _scenario.newPlayers)
                    {
                        CreateGameObjectByName(_player.playerAsset, _objectGroup.transform);
                    }
                }

                // Create Objects
                _objectList = new List<GameObject>();
                foreach(string _object in _scenario.objects)
                {
                    GameObject o = CreateGameObjectByName(_object, _objectGroup.transform);
                }

                // Create Environment
                _environment = CreateGameObjectByName(_scenario.environment, _scenarioGroup.transform);

                // Finalise Scenario Track
                _trackScenario.current              = _scenarioGroup;
                _trackScenario.objects.current      = _objectGroup;
                _trackScenario.environment.current  = _environment;

                trackInstance.scenarios.Add(_trackScenario);
            }
        }

        void RefreshUI()
        {
            // Reset Track UI
            trackUI.SetTrackName(sample.name);
            trackUI.SetBPM(sample.BPM.ToString());
            trackUI.SetAuthor(sample.author);
            trackUI.SetDuration(sample.duration.ToString());
        }

        void RefreshEditableTrack()
        {
            GameJockey.setup.RefreshMixers();
        }

        // ---------------------------------------------------------------------------------
        // TOOLS

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
                    sample.assets, 
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = trackSceneGameObject.transform;
            return _tempGameObject;
        }

        GameObject CreateGameObjectByName(string _assetName, Transform _parent)
        {
            GameObject _tempGameObject = Instantiate(
                JockeyUtilities.FindAssetByName(
                    sample.assets,
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = _parent;
            return _tempGameObject;
        }

        public void SetTrackComponentVisibility(bool _visibility)
        {
            if (trackInstance == null
                || trackInstance.camera.current == null)
                return;

            trackInstance.camera.current.SetActive(_visibility);
            trackInstance.light.current.SetActive(_visibility);
            foreach(TrackScenario _scenario in trackInstance.scenarios)
            {
                _scenario.current.SetActive(_visibility);
            }
        }

        public void SetSpecificTrackComponentVisibility(TrackComponentEnum _component, bool _visbility)
        {
            // if no referenceSample loaded, it shouldnt find GameObject to Active
            if (trackInstance == null)
                return;

            /*switch(_component)
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
            }*/
        }

        public void PlayTrack()
        {

        }

        
    }
}

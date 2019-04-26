using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class TrackPlayer : MonoBehaviour
    {
        public TrackUI trackUI;
        public List<Track> tracks;

        public enum TrackComponentEnum
        {
            camera,
            light,
            avatars,
            obstacle,
            environment
        };

        public void InitTrackPlayer(int _trackCount)
        {
            tracks = new List<Track>(_trackCount);
        }

        // User -> choose Sample
        // Called by UI to load new sample on track
        public void LoadSample(GameSample _sample, int _trackIndex)
        {
            if (_sample == null
                || _trackIndex < 0
                || _trackIndex >= tracks.Count)
                return;

            InitTrack(_sample, _trackIndex);
            CreateTrackContent(_sample, _trackIndex);
            RefreshUI(_sample, _trackIndex);
        }

        // Sample -> Track
        void InitTrack(GameSample _sample, int _trackIndex)
        {
            if(tracks[_trackIndex].sceneGameObject != null)
                Destroy(tracks[_trackIndex].sceneGameObject);

            tracks[_trackIndex] = new Track();
        }

        // Track -> Scene Content
        void CreateTrackContent(GameSample _sample, int _trackIndex)
        {
            tracks[_trackIndex].sceneGameObject = new GameObject("Track " + _trackIndex + _sample.name);

            // Create new GameObject track
            tracks[_trackIndex].camera.current    = CreateGameObjectByName(_sample, _trackIndex, _sample.camera);
            tracks[_trackIndex].light.current     = CreateGameObjectByName(_sample, _trackIndex, _sample.light);

            tracks[_trackIndex].scenarios = new List<TrackScenario>();

            foreach (SampleScenario _scenario in _sample.scenarios)
            {
                // Init temp variables
                TrackScenario       _trackScenario = new TrackScenario();
                GameObject          _scenarioGroup;
                GameObject          _objectGroup;
                GameObject          _environment;
                GameObject          _playersGroup;
                List<GameObject>    _objectList;

                // Create Groups
                _scenarioGroup  = CreateGroup("Scenario " + _scenario.name, tracks[_trackIndex].sceneGameObject.transform);
                _playersGroup = CreateGroup("Players", _scenarioGroup.transform);
                _objectGroup    = CreateGroup("Objects", _scenarioGroup.transform);

                // Create Players
                if(_scenario.useDefaultPlayers)
                {
                    foreach(PlayerSampleParams _player in _sample.defaultPlayers)
                    {
                        CreateGameObjectByName(_sample, _trackIndex, _player.playerAsset, _objectGroup.transform);
                    }
                }
                else
                {
                    foreach (PlayerSampleParams _player in _scenario.newPlayers)
                    {
                        CreateGameObjectByName(_sample, _trackIndex, _player.playerAsset, _objectGroup.transform);
                    }
                }

                // Create Objects
                _objectList = new List<GameObject>();
                foreach(string _object in _scenario.objects)
                {
                    GameObject o = CreateGameObjectByName(_sample, _trackIndex, _object, _objectGroup.transform);
                }

                // Create Environment
                _environment = CreateGameObjectByName(_sample, _trackIndex, _scenario.environment, _scenarioGroup.transform);

                // Finalise Scenario Track
                _trackScenario.current              = _scenarioGroup;
                _trackScenario.objects.current      = _objectGroup;
                _trackScenario.environment.current  = _environment;

                tracks[_trackIndex].scenarios.Add(_trackScenario);
            }
        }

        void RefreshUI(GameSample _sample, int _trackIndex)
        {
            // Reset Track UI
            UIManager.setup.RefreshTrackUIInfos(
                _trackIndex,
                _sample.name,
                _sample.BPM.ToString(),
                _sample.author,
                _sample.duration.ToString()
                );
        }

        // ---------------------------------------------------------------------------------
        // TOOLS

        GameObject CreateGroup(string _name, Transform _parent)
        {
            GameObject _tempGameObject = new GameObject(_name);

            _tempGameObject.transform.parent = _parent;

            return _tempGameObject;
        }

        GameObject CreateGameObjectByName(GameSample _sample, int _trackIndex, string _assetName)
        {
            GameObject _tempGameObject = Instantiate(
                JockeyUtilities.FindAssetByName(
                    _sample.assets, 
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = tracks[_trackIndex].sceneGameObject.transform;
            return _tempGameObject;
        }

        GameObject CreateGameObjectByName(GameSample _sample, int _trackIndex, string _assetName, Transform _parent)
        {
            GameObject _tempGameObject = Instantiate(
                JockeyUtilities.FindAssetByName(
                    _sample.assets,
                    _assetName
                    )
                    );

            _tempGameObject.transform.parent = _parent;
            return _tempGameObject;
        }

        public void PlayTrack()
        {
            // Call Filter
        }

        
    }
}

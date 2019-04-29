using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    // define User interactions with other classes
    public class GameJockey : MonoBehaviour
    {
        // Singleton
        public static GameJockey setup = null;

        // Parameters
        [Header("Session setup")]
        public TrackPlayer trackPlayer;
        public GameSample[] samples; // replace it with AssetBundle with zip(Assets+XML) in GameJockey_v4.1
        public int trackNumber = 2; // for 4.0 version, should always stay equal 2

        // Players
        [Header("Players setup")]
        public bool detectPlayerInputs = true;


        // Methods
        private void Awake()
        {
            if (setup == null)
                setup = this;
            else if (setup != this)
                Destroy(gameObject);

            /*trackPlayers = new List<TrackPlayer>();
            TrackPlayer[] _tracks = GetComponentsInChildren<TrackPlayer>();
            foreach (TrackPlayer _track in _tracks)
            {
                trackPlayers.Add(_track);
            }*/
        }

        private void Start()
        {
            trackPlayer.InitTrackPlayer(trackNumber);
        }

        // Create a track with selected sample by creating all assets and behaviour during time
        public void LoadSample(int _sampleIndex, int _trackPlayerIndex)
        {
            if (_sampleIndex > samples.Length
                || _sampleIndex < 0
                //|| _trackPlayerIndex > trackPlayers.Count
                || _trackPlayerIndex < 0)
                return;

            //trackPlayers[_trackPlayerIndex].LoadSample(samples[_sampleIndex]);
        }

        // Function for UI functions
        public void LoadSampleToTrackA(int _sampleIndex)
        {
            LoadSample(_sampleIndex, 0);
        }

        // Function for UI functions
        public void LoadSampleToTrackB(int _sampleIndex)
        {
            LoadSample(_sampleIndex, 1);
        }

        public void Play(int _trackNumber)
        {
            if(_trackNumber == 0)
            {
                //trackPlayers[0].PlayTrack();
            }
            else
            {
               // trackPlayers[1].PlayTrack();
            }
        }

        public void RefreshSampleList()
        {
            UIManager.setup.RefreshUISampleList(samples);
        }
    }
}
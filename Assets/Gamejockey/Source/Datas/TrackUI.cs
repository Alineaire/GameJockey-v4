using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    [System.Serializable]
    public class TrackUI
    {
        public Text trackName;
        public Text bpm;
        public Text author;
        public Text duration;

        // TODO visualiseur

        public void SetTrackName(string _trackName)
        {
            trackName.text = _trackName;
        }

        public void SetBPM(string _bpm)
        {
            bpm.text = _bpm;
        }

        public void SetAuthor(string _author)
        {
            author.text = _author;
        }

        public void SetDuration(string _duration)
        {
            duration.text = _duration;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    public class UIManager : MonoBehaviour
    {
        // c'est toi le singleton
        public static UIManager setup = null;
        public TrackInfos[] tracksInfo;

        public GameObject sampleListParentGameObject;

        private void Awake()
        {
            if (setup == null)
                setup = this;
            else if (setup != this)
                Destroy(gameObject);
        }

        public void RefreshTrackUIInfos(int _trackIndex, string _name, string _bpm, string _author, string _duration)
        {
            tracksInfo[_trackIndex].name.text = _name;
            tracksInfo[_trackIndex].name.text = _bpm;
            tracksInfo[_trackIndex].name.text = _author;
            tracksInfo[_trackIndex].name.text = _duration;
        }

        // SAMPLE LIST
        public void RefreshUISampleList(GameSample[] _samples)
        {
            if (sampleListParentGameObject == null)
                return;

            // TODO create new list
        }
    }

    [System.Serializable]
    public class TrackInfos
    {
        public Text name, author, bpm, duration;
    }
}
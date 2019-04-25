using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public class TrackMixer : MonoBehaviour
    {
        public enum TrackModificationEnum
        {
            Left,
            Right,
            Both
        };

        // limit to two
        public TrackPlayer[] tracksToMix;

        public AnimationCurve trackMixerCurve;
        public TrackModificationEnum trackModification = TrackModificationEnum.Left;

        private void Start()
        {
            RefreshEditableTracks();
        }

        public void DefineEditableTrack(float _v)
        {
            float _state = trackMixerCurve.Evaluate(_v);

            if (_state <= 0.25f)
            {
                trackModification = TrackModificationEnum.Left;
            }
            else if (_state >= 0.75f)
            {
                trackModification = TrackModificationEnum.Right;
            }
            else
            {
                trackModification = TrackModificationEnum.Both;
            }

            RefreshEditableTracks();
        }

        void RefreshEditableTracks()
        {
            Debug.Log(tracksToMix.Length);

            if (tracksToMix.Length != 2
                || tracksToMix[0] == null
                || tracksToMix[1] == null)
                return;

            switch(trackModification)
            {
                case TrackModificationEnum.Left:
                    tracksToMix[0].SetTrackComponentVisibility(true);
                    tracksToMix[0].SetTrackComponentVisibility(false);
                    break;
                case TrackModificationEnum.Right:
                    tracksToMix[0].SetTrackComponentVisibility(false);
                    tracksToMix[0].SetTrackComponentVisibility(true);
                    break;
                case TrackModificationEnum.Both:
                    // ca depend de sa mere
                    break;
            }
        }
    }
}

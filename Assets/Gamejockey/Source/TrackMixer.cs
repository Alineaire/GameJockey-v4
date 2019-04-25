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

        public void RefreshEditableTracks()
        {

            if (tracksToMix.Length != 2
                || tracksToMix[0] == null
                || tracksToMix[1] == null)
                return;

            switch(trackModification)
            {
                case TrackModificationEnum.Left:
                    tracksToMix[0].SetTrackComponentVisibility(true);
                    tracksToMix[1].SetTrackComponentVisibility(false);
                    UIManager.setup.SetMixerToggleInteractable(0, true);
                    UIManager.setup.SetMixerToggleInteractable(1, false);
                    UIManager.setup.SetMixerToggleisOn(0, true);
                    UIManager.setup.SetMixerToggleisOn(1, false);
                    break;
                case TrackModificationEnum.Right:
                    tracksToMix[0].SetTrackComponentVisibility(false);
                    tracksToMix[1].SetTrackComponentVisibility(true);
                    UIManager.setup.SetMixerToggleInteractable(0, false);
                    UIManager.setup.SetMixerToggleInteractable(1, true);
                    UIManager.setup.SetMixerToggleisOn(0, false);
                    UIManager.setup.SetMixerToggleisOn(1, true);
                    break;
                case TrackModificationEnum.Both:
                    // ca depend de sa mere
                    UIManager.setup.SetMixerToggleInteractable(0, true);
                    UIManager.setup.SetMixerToggleInteractable(1, true);
                    break;
            }
        }

        public bool CanInvertComponent(int _mixerTarget)
        {
            bool _b = false;

            if (tracksToMix.Length != 2
                || tracksToMix[0] == null
                || tracksToMix[1] == null)
                return _b;

            switch (trackModification)
            {
                case TrackModificationEnum.Left:
                    if (_mixerTarget == 0) _b = true;
                    break;
                case TrackModificationEnum.Right:
                    if (_mixerTarget == 1) _b = true;
                    break;
                case TrackModificationEnum.Both:
                    _b = true;
                    break;
            }

            return _b;
        }
    }
}

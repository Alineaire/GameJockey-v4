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

        public GameObject sampleListParentGameObject;

        public TrackComponentToggles[] trackComponentToggles;

        private void Awake()
        {
            if (setup == null)
                setup = this;
            else if (setup != this)
                Destroy(gameObject);
        }

        // SAMPLE LIST
        public void RefreshUISampleList(GameSample[] _samples)
        {
            if (sampleListParentGameObject == null)
                return;

            /*foreach(Transform _sample in sampleListParentGameObject.transform)
            {
                DestroyImmediate(_sample.gameObject);
            }*/

            // TODO create new list
        }

        public void PushGameComponentButton(Toggle _sourceToggle, int _track)
        {
            if(GameJockey.setup.TryInvertComponent(_track))
            {
                //InvertTogglesState(_sourceToggle);
            }
        }

        public void SetToggleTransition(int _track, bool _active)
        {
            trackComponentToggles[_track].SetTransition(_active);
        }

        public void SetMixerToggleInteractable(int _track, bool _interactible)
        {
            trackComponentToggles[_track].SetInteractable(_interactible);
        }

        public void SetMixerToggleisOn(int _track, bool _isOn)
        {
            trackComponentToggles[_track].SetIsOn(_isOn);
        }

        public void InvertTogglesState(int _track, TrackPlayer.TrackComponentEnum _component)
        {
            int _componentIndex = _component.GetHashCode();

            int _trackTarget = _track;

            if (_trackTarget == 0)
                _trackTarget = 1;
            else if(_trackTarget == 1)
                _trackTarget = 0;

            trackComponentToggles[_trackTarget].Invert(_componentIndex);
        }

        public void InvertButtonsState(int _track, TrackPlayer.TrackComponentEnum _component)
        {
            int _componentIndex = _component.GetHashCode();

            int _trackTarget = _track;

            if (_trackTarget == 0)
                _trackTarget = 1;
            else if (_trackTarget == 1)
                _trackTarget = 0;

            trackComponentToggles[_trackTarget].Invert(_componentIndex);
        }
    }


    [System.Serializable]
    public class TrackComponentToggles
    {
        public Color activeColor, inactiveColor, selectColor;
        public Button[] components;

        public void Invert(int _index)
        {
            //components[_index].isOn = !components[_index].isOn;
        }

        public void SetInteractable(bool _b)
        {
            /*foreach(Button component in components)
            {
                component.interactable = _b;
            }*/
        }

        public void SetIsOn(bool _b)
        {
            /*foreach (Toggle component in components)
            {
                component.isOn = _b;
            }*/
        }

        public void SetTransition(bool _b)
        {
            /*Toggle.Transition _transition = Selectable.Transition.ColorTint;

            if (!_b)
                _transition = Selectable.Transition.None;

            foreach (Toggle component in components)
            {
                component.transition = _transition;
            }*/
        }
    }
}
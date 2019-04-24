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

        public GameComponentButtons trackAGameComponents, trackBGameComponents;

        private void Awake()
        {
            if (setup == null)
                setup = this;
            else if (setup != this)
                Destroy(gameObject);
        }

        public void ChangeTrackMixerState(float _value)
        {
            if (_value <= 0.25f)
            {
                GameJockey.setup.trackModification = GameJockey.TrackModificationEnum.Left;
                ChangeGameComponentAccess(true, false);
            }
            else if (_value >= 0.75f)
            {
                GameJockey.setup.trackModification = GameJockey.TrackModificationEnum.Right;
                ChangeGameComponentAccess(false, true);
            }
            else
            {
                GameJockey.setup.trackModification = GameJockey.TrackModificationEnum.Both;
                ChangeGameComponentAccess(true, true);
            }
        }

        public void ChangeGameComponentAccess(bool _trackA, bool _trackB)
        {
            if(_trackA && !_trackB)
            {
                ChangeTrackToggleStateInteractible(trackAGameComponents, true);
                ChangeTrackToggleStateInteractible(trackBGameComponents, false);
                ForceChangeTrackStateIsOn(trackAGameComponents, true);
                ForceChangeTrackStateIsOn(trackBGameComponents, false);
            }
            else if (!_trackA && _trackB)
            {
                ChangeTrackToggleStateInteractible(trackAGameComponents, false);
                ChangeTrackToggleStateInteractible(trackBGameComponents, true);
                ForceChangeTrackStateIsOn(trackAGameComponents, false);
                ForceChangeTrackStateIsOn(trackBGameComponents, true);
            }
            else
            {
                ChangeTrackToggleStateInteractible(trackAGameComponents, true);
                ChangeTrackToggleStateInteractible(trackBGameComponents, true);
            }
            
        }

        void ChangeTrackToggleStateInteractible(GameComponentButtons _toggle, bool _interactable)
        {
            _toggle.camera.interactable = _interactable;
            _toggle.light.interactable = _interactable;
            _toggle.avatars.interactable = _interactable;
            _toggle.obstacle.interactable = _interactable;
            _toggle.environment.interactable = _interactable;
        }

        void ForceChangeTrackStateIsOn(GameComponentButtons _toggle, bool _isOn)
        {
            _toggle.camera.isOn = _isOn;
            _toggle.light.isOn = _isOn;
            _toggle.avatars.isOn = _isOn;
            _toggle.obstacle.isOn = _isOn;
            _toggle.environment.isOn = _isOn;
        }
    }

    [System.Serializable]
    public class GameComponentButtons
    {
        public Toggle camera, light, avatars, obstacle, environment;
    }
}
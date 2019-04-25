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

        public GameComponentButtons[] gameComponentTracks;

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
                InvertComponentToggle(_sourceToggle);
            }
        }

        public void SetMixerToggleInteractable(int _track, bool _interactible)
        {
            gameComponentTracks[_track].camera.interactable = _interactible;
            gameComponentTracks[_track].light.interactable = _interactible;
            gameComponentTracks[_track].players.interactable = _interactible;
            gameComponentTracks[_track].objects.interactable = _interactible;
            gameComponentTracks[_track].environment.interactable = _interactible;
        }

        public void SetMixerToggleisOn(int _track, bool _isOn)
        {
            gameComponentTracks[_track].camera.isOn = _isOn;
            gameComponentTracks[_track].light.isOn = _isOn;
            gameComponentTracks[_track].players.isOn = _isOn;
            gameComponentTracks[_track].objects.isOn = _isOn;
            gameComponentTracks[_track].environment.isOn = _isOn;
        }

        public void InvertComponentToggle(Toggle _sourceToggle)
        {
            Debug.Log("inversion des Toggle");
        }
    }


    [System.Serializable]
    public class GameComponentButtons
    {
        public Toggle camera, light, players, objects, environment;
    }
}
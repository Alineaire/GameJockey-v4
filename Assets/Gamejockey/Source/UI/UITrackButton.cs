using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    [RequireComponent(typeof(Button))]
    public class UITrackButton : MonoBehaviour
    {
        public enum UIToggleEnum
        {
            selected,
            unselected
        }
        public TrackPlayer.TrackComponentEnum trackComponentType;
        public int track = 0;
        public TrackMixer mixer;
        public UIToggleEnum toggleState = UIToggleEnum.selected;
        Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.onClick.AddListener(delegate { Click(); });
        }

        void Click()
        {
            if (button.interactable)
                mixer.TryInvertComponents(track, trackComponentType);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    [RequireComponent(typeof(Toggle))]
    public class UITrackToggle : MonoBehaviour
    {
        public TrackPlayer.TrackComponentEnum trackComponentType;
        public int track = 0;
        Toggle toggle;

        private void Awake()
        {
            toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            toggle.onValueChanged.AddListener(delegate { ValueToggleChange(); });
        }

        void ValueToggleChange()
        {
            GameJockey.setup.ChangeTrackComponentsVisibility(trackComponentType, track, toggle.isOn);
        }
    }
}
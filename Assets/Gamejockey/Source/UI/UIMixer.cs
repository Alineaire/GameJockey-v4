using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameJockey_v4
{
    public class UIMixer : MonoBehaviour
    {
        public Slider mixerSlider;
        public TrackMixer trackMixer;

        private void Start()
        {
            mixerSlider.onValueChanged.AddListener(delegate { ValueMixerChange(); });
        }

        public void ValueMixerChange()
        {
            trackMixer.DefineEditableTrack(mixerSlider.value);
        }
    }
}
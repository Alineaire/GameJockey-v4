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
        public AnimationCurve trackMixerCurve;
        public float mixerMappedValue;
        public Image leftVisualizer, rightVisualizer;
        public Color visualizerColor = Color.blue;

        private void Start()
        {
            mixerSlider.onValueChanged.AddListener(delegate { ValueMixerChange(); });
        }

        public void ValueMixerChange()
        {
            mixerMappedValue = trackMixerCurve.Evaluate(mixerSlider.value);

            if (mixerMappedValue <= 0.25f)
            {
                leftVisualizer.color = visualizerColor;
                rightVisualizer.color = Color.white;
            }
            else if (mixerMappedValue >= 0.75f)
            {
                leftVisualizer.color = Color.white;
                rightVisualizer.color = visualizerColor;
            }
            else
            {
                leftVisualizer.color = visualizerColor;
                rightVisualizer.color = visualizerColor;
            }

            UIManager.setup.ChangeTrackMixerState(mixerMappedValue);
        }
    }
}
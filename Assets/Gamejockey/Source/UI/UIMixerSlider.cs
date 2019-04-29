using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{

    public class UIMixerSlider : MonoBehaviour
    {
        public Slider slider;
        public FilterMixer mixer;
        public AnimationCurve sliderFilter;

        private void Awake()
        {
            slider.onValueChanged.AddListener(delegate { ChangeMixerEffect(); });
        }

        public void ChangeMixerEffect()
        {
            FilterMixer.FilterMixerEnum _filter = FilterMixer.FilterMixerEnum.OnlyLeft;

            if(slider.value >= 0.25f && slider.value <= 0.75f)
            {
                _filter = FilterMixer.FilterMixerEnum.Editable;
            }
            else if(slider.value > 0.75f)
            {
                _filter = FilterMixer.FilterMixerEnum.OnlyRight;
            }

            mixer.SetFilterMixer(_filter);
        }
    }
}
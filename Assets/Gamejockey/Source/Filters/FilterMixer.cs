using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* FILTER MIXER
 * Permet de choisir quel track est joué
 * Permet de choisir quel composant d'un track est joué
 * */

namespace GameJockey_v4
{
    public class FilterMixer : TrackFilter
    {
        public enum FilterMixerEnum
        {
            OnlyLeft,
            OnlyRight,
            Editable
        };

        public enum FilterComponentMixerEnum
        {
            Left,
            Right
        };

        //[HideInInspector]
        public FilterMixerEnum filterMixer = FilterMixerEnum.OnlyLeft;

        //[HideInInspector]
        public FilterComponentMixerEnum filterCamera, filterLight, filterAvatars, filterObjects, filterEnvironment;

        public override void FilterTwoTrack(Track _inputTrack1, Track _inputTrack2, ref Track _output1, ref Track _output2)
        {
            _output1 = new Track();
            _output2 = new Track();

            if (filterMixer == FilterMixerEnum.OnlyLeft)
            {
                _output1.SetActiveTrack(true);
                _output2.SetActiveTrack(false);
            }
            else if (filterMixer == FilterMixerEnum.OnlyRight)
            {
                _output1.SetActiveTrack(false);
                _output2.SetActiveTrack(true);
            }
            else if (filterMixer == FilterMixerEnum.Editable)
            {
                _output1.SetActiveTrack(true);
                _output2.SetActiveTrack(true);
            }
        }

        public void SetFilterMixer(FilterMixerEnum _mixer)
        {
            filterMixer = _mixer;

            if (_mixer == FilterMixerEnum.OnlyLeft)
            {
                filterCamera = FilterComponentMixerEnum.Left;
                filterLight = FilterComponentMixerEnum.Left;
                filterAvatars = FilterComponentMixerEnum.Left;
                filterObjects = FilterComponentMixerEnum.Left;
                filterEnvironment = FilterComponentMixerEnum.Left;
            }
            else if (_mixer == FilterMixerEnum.OnlyRight)
            {
                filterCamera = FilterComponentMixerEnum.Right;
                filterLight = FilterComponentMixerEnum.Right;
                filterAvatars = FilterComponentMixerEnum.Right;
                filterObjects = FilterComponentMixerEnum.Right;
                filterEnvironment = FilterComponentMixerEnum.Right;
            }
        }

        public void SetCameraFilter(FilterComponentMixerEnum _filter)
        {
            if (!CanEditComponent())
                return;

            filterCamera = _filter;
        }

        public void SetLightFilter(FilterComponentMixerEnum _filter)
        {
            if (!CanEditComponent())
                return;

            filterLight = _filter;
        }

        public void SetAvatarsFilter(FilterComponentMixerEnum _filter)
        {
            if (!CanEditComponent())
                return;

            filterAvatars = _filter;
        }

        public void SetObjectsFilter(FilterComponentMixerEnum _filter)
        {
            if (!CanEditComponent())
                return;

            filterObjects = _filter;
        }

        public void SetEnvironmentFilter(FilterComponentMixerEnum _filter)
        {
            if (!CanEditComponent())
                return;

            filterEnvironment = _filter;
        }

        bool CanEditComponent()
        {
            if (filterMixer == FilterMixerEnum.Editable)
                return true;
            else
                return false;
        }
    }
}
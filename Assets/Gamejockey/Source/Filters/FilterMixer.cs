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

        public enum FilterComponentEnum
        {
          Camera,
          Light,
          Avatars,
          Objects,
          Environment
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

        public void SetComponentFilter(FilterComponentEnum _component, FilterComponentMixerEnum _filter)
        {

          if (!CanEditComponent())
              return;

          switch(_component)
          {
            case FilterComponentEnum.Camera:
              filterCamera = _filter;
              break;
            case FilterComponentEnum.Light:
              filterLight = _filter;
              break;
            case FilterComponentEnum.Avatars:
              filterAvatars = _filter;
              break;
            case FilterComponentEnum.Objects:
              filterObjects = _filter;
              break;
            case FilterComponentEnum.Environment:
              filterEnvironment = _filter;
              break;
          }
        }

        protected bool CanEditComponent()
        {
            if (filterMixer == FilterMixerEnum.Editable)
                return true;
            else
                return false;
        }
    }
}

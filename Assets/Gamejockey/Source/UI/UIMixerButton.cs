using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
  public class UIMixerButton : MonoBehaviour
  {
      public enum  MixerButtonStateEnum
      {
        selected,
        unselected,
        inactive
      };

      Button button;
      Image image;
      public FilterMixer mixer;
      public FilterMixer.FilterComponentEnum component;
      public FilterMixer.FilterComponentMixerEnum mix;

      void Awake()
      {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(delegate { OnButtonClic(); });
      }

      void OnButtonClic()
      {
          mixer.SetComponentFilter(component, mix);
          UIManager.setup.RefreshFilterUI();
      }

      public void SetButtonState(MixerButtonStateEnum _state)
      {
        if(_state == MixerButtonStateEnum.selected)
        {
          image.color = UIManager.setup.selectedColor;
        }
        else if(_state == MixerButtonStateEnum.unselected)
        {
          image.color = UIManager.setup.unselectedColor;
        }
        else if(_state == MixerButtonStateEnum.inactive)
        {
          image.color = UIManager.setup.inactiveColor;
        }
      }
  }
}

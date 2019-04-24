using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [CreateAssetMenu(fileName = "track", menuName = "GameJockey/Device/Keyboard", order = 1)]
    public class KeyboardDevice : Device
    {
        public KeyCode[] keyboardMapping;

        public override bool GetInputDown(int _inputIndex)
        {
            bool _input = false;

            if (Input.GetKeyDown(keyboardMapping[_inputIndex]))
                _input = true;

            return _input;
        }

        public override bool GetInputUp(int _inputIndex)
        {
            bool _input = false;

            if (Input.GetKeyUp(keyboardMapping[_inputIndex]))
                _input = true;

            return _input;
        }

        public override bool GetInputStay(int _inputIndex)
        {
            bool _input = false;

            if (Input.GetKey(keyboardMapping[_inputIndex]))
                _input = true;

            return _input;
        }
    }
}
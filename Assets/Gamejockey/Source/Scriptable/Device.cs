using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public class Device : ScriptableObject
    {
        public virtual bool GetInputDown(int _inputIndex)
        {
            bool _input = false;

            return _input;
        }

        public virtual bool GetInputUp(int _inputIndex)
        {
            bool _input = false;

            return _input;
        }

        public virtual bool GetInputStay(int _inputIndex)
        {
            bool _input = false;

            return _input;
        }
    }
}

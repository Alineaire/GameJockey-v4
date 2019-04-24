using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{

    [System.Serializable]
    public class Action
    {
        // type d'input
        public InputType inputType;

        // comportement d'action
        public ActionBehaviour behaviour;
    }
}

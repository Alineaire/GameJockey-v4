using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class Scenario
    {
        public Action[] actions;
        public string obstacle;
        public string environment;
    }
}
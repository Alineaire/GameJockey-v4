using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public static class JockeyUtilities
    {
        public static int GetBPMdeltaTime(int _bpm)
        {
            return Mathf.RoundToInt(_bpm * Time.deltaTime * 60f);
        }
    }
}

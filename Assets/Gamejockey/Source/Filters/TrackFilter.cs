using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public class TrackFilter : MonoBehaviour
    {
        public virtual Track FilterTrack(Track _inputTrack)
        {
            Track _outputTrack = new Track();

            return _outputTrack;
        }

        public virtual void FilterTwoTrack(Track _inputTrack1, Track _inputTrack2, ref Track _output1, ref Track _output2)
        {

        }
    }
}
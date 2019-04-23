using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    public class JockeyUI : MonoBehaviour
    {
        public GameObject samplesContent;

        public void RefreshSampleList(GameSample[] _newList)
        {
            // destroy all children
            foreach(Transform child in samplesContent.transform)
            {
                Destroy(child.gameObject);
            }

            // create new list

        }
    }
}

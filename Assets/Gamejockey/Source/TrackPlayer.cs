using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    [System.Serializable]
    public class TrackPlayer : MonoBehaviour
    {
        public GameSample referenceSample;

        // Scene Structure
        public GameObject sceneTarget;
        public GameObject[] players;
        // TODO obstacle

        void CreateTrackContent(GameSample _sample)
        {
            /*if(tracks[_index] == null)
            {
                tracks[_index] = new GameTrack();
                tracks[_index].sceneTarget = new GameObject();
                tracks[_index].sceneTarget.name = "TRACK "+ _index;
                CreateTrackContent(tracks[_index]);
            }
            else
            {
                DestroyImmediate(tracks[_index].sceneTarget);
                tracks[_index] = null;
            }*/

            // player creation
            /*for(int i=0; i<activePlayers; i++)
            {
                List<GameObject> _players;
            }*/
        }

        public void PlayTrack()
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public class GameJockey : MonoBehaviour
    {
        public GameSample[] samples;
        public GameTrack trackA, trackB;

        // Péripherique

        // Players
        public int activePlayers = 4; // issue if we change active player in live + issue if we load track A or B with other player number

        // Methods
        // Create a track with selected sample by creating all assets and behaviour during time
        public void LoadTrack(int _index)
        {
            if(_index == 0)
            {
                if(trackA.sceneTarget == null)
                {
                    trackA.sceneTarget = new GameObject();
                    trackA.sceneTarget.name = "TRACK A";
                    CreateTrackContent(trackA);
                }
                else
                {
                    DestroyImmediate(trackA.sceneTarget);
                    trackA.sceneTarget = null;
                }
            }
            else
            {
                if (trackB.sceneTarget == null)
                {
                    trackB.sceneTarget = new GameObject();
                    trackB.sceneTarget.name = "TRACK B";
                    CreateTrackContent(trackB);
                }
                else
                {
                    DestroyImmediate(trackB.sceneTarget);
                    trackB.sceneTarget = null;
                }
                
            }
        }

        void CreateTrackContent(GameTrack _track)
        {
            // player creation
            /*for(int i=0; i<activePlayers; i++)
            {
                List<GameObject> _players;
            }*/
        }

        public void UnloadTrack(int _pistIndex)
        {

        }
    }

    [System.Serializable]
    public class GameTrack
    {
        public GameSample sample;
        public GameObject sceneTarget;
        public GameObject[] players;
    }
}
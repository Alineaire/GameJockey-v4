using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJockey_v4
{
    public class UIManager : MonoBehaviour
    {
        // c'est toi le singleton
        public static UIManager setup = null;

        public GameObject sampleListParentGameObject;

        public GameComponentButtons[] gameComponentTracks;

        private void Awake()
        {
            if (setup == null)
                setup = this;
            else if (setup != this)
                Destroy(gameObject);
        }

        // SAMPLE LIST
        public void RefreshUISampleList(GameSample[] _samples)
        {
            if (sampleListParentGameObject == null)
                return;

            /*foreach(Transform _sample in sampleListParentGameObject.transform)
            {
                DestroyImmediate(_sample.gameObject);
            }*/

            // TODO create new list
        }
    }


    [System.Serializable]
    public class GameComponentButtons
    {
        public Toggle camera, light, avatars, obstacle, environment;
    }
}
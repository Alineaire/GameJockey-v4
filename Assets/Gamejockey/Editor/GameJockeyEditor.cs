using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJockey_v4
{
    
    [CustomEditor(typeof(GameJockey))]
    public class GameJockeyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameJockey jockey = (GameJockey)target;

            GUILayout.Space(5);

            // play left track A
            if (GUILayout.Button("Refresh Sample List"))
            {
                jockey.RefreshSampleList();
            }
        }
    }
}

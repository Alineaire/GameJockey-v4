using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJockey_v4
{
    /*
    [CustomEditor(typeof(GameJockey))]
    public class GameJockeyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameJockey jockey = (GameJockey)target;

            GUILayout.Space(5);
            GUILayout.BeginHorizontal();

            GUILayout.Label("Track A");
            GUILayout.Label("Track B");

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            // play left track A
            if (GUILayout.Button("Play"))
            {
                jockey.LoadTrack(0);
            }

            // play left track B
            if (GUILayout.Button("Play"))
            {
                jockey.LoadTrack(1);
            }

            GUILayout.EndHorizontal();
        }
    }*/
}

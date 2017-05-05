using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapManager))]
public class MapManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Reassign tiles"))
        {
            ReassignTilesInEditor();
        }
        if (GUILayout.Button("Update all tiles"))
        {
            UpdateTilesInEditor();
        }

    }

    private void UpdateTilesInEditor()
    {
        MapManager man = (MapManager)target;
        man.UpdateTiles();
    }

    private void ReassignTilesInEditor()
    {
        MapManager man = (MapManager)target;
        man.ReassignTiles();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tile))]
[CanEditMultipleObjects]
public class TileEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Update Tile"))
        {
            UpdateTileInEditor();
        }

    }

    private void UpdateTileInEditor()
    {
        Tile tile = (Tile)target;
        tile.UpdateTile();
    }
}

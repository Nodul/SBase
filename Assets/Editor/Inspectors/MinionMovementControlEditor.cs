using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(MinionMovementControl))]
public class MinionMovementControlEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Find nearest node"))
        {
            FindNearestNodeInEditor();
        }

    }

    private void FindNearestNodeInEditor()
    {
        MinionMovementControl man = (MinionMovementControl)target;
        man.GetClosestNode();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(MinionManager))]
public class MinionManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Find all minions"))
        {
            FindAllMinionsInEditor();
        }
        if(GUILayout.Button("Update all minions"))
        {
            UpdateMinionsInEditor();
        }

    }

    private void UpdateMinionsInEditor()
    {
        MinionManager man = (MinionManager)target;
        man.UpdateMinions();
    }

    private void FindAllMinionsInEditor()
    {
        MinionManager man = (MinionManager)target;
        man.FindAllMinions();
    }
}

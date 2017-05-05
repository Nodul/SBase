using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Minion))]
[CanEditMultipleObjects]
public class MinionEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Force move"))
        {
            GiveMoveOrderInEditor();
        }
        if(GUILayout.Button("Update minion"))
        {
            UpdateMinionInEditor();
        }
        
    }

    private void GiveMoveOrderInEditor()
    {
        Minion m = (Minion)target;
        m.GiveMoveOrder();
    }

    private void UpdateMinionInEditor()
    {
        Minion m = (Minion)target;
        m.UpdateMinion();
    }

}

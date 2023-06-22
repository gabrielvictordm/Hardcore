using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
        
[CustomEditor(typeof(BattleSystem))]
public class EndBattle : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BattleSystem bt = (BattleSystem)target;
        if (GUILayout.Button("EndBattle"))
        {
            bt.WinBattle();
        }
    }
}

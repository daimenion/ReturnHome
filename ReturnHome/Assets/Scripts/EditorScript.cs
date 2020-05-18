using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(ViewCircle))]
public class EditorScript : Editor
{
    
    void OnSceneGUI() {
        ViewCircle view = (ViewCircle)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(view.transform.position, Vector3.up, Vector3.forward, 360, view.viewRadius);
        Vector3 ViewAngleA = view.DirFromAngle(-view.viewAngle / 2, false);
        Vector3 ViewAngleB = view.DirFromAngle(view.viewAngle / 2, false);

        Handles.DrawLine(view.transform.position, view.transform.position + ViewAngleA * view.viewRadius);
        Handles.DrawLine(view.transform.position, view.transform.position + ViewAngleB * view.viewRadius);
    }
}

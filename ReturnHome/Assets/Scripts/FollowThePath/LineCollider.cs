using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LineCollider : MonoBehaviour
{
    LineRenderer line;
    MeshCollider meshCollider;
    public void Start()
    {
        line = GetComponent<LineRenderer>();
        meshCollider = new GameObject("Line Mesh").AddComponent<MeshCollider>();
        meshCollider.transform.parent = line.transform.parent;
        meshCollider.transform.position = line.transform.position;
        FollowThePath path = meshCollider.gameObject.AddComponent<FollowThePath>();
        path.myLine = line;
        path.myCollider = meshCollider;
        line.startWidth = 0.5f;
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, true);
        meshCollider.sharedMesh = mesh;
        transform.GetChild(0).transform.parent = meshCollider.transform;

    }
}
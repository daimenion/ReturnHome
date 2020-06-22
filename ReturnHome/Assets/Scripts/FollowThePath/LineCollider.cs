using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LineCollider : MonoBehaviour
{
    LineRenderer line;
    MeshCollider meshCollider;
    GameObject lineMesh;
    public void Start()
    {
        line = GetComponent<LineRenderer>();
        lineMesh = transform.parent.Find("Line Mesh").gameObject;
        meshCollider =lineMesh.AddComponent<MeshCollider>();
        //meshCollider.transform.parent = line.transform.parent;
        lineMesh.transform.position = line.transform.position;

        //transform.GetChild(0).transform.parent = meshCollider.transform;
        //transform.GetChild(0).transform.parent = meshCollider.transform;
        FollowThePath path = lineMesh.GetComponent<FollowThePath>();
        transform.Find("LocatorSprite").GetComponent<FollowSelector>().followScript = path;


        path.myLine = line;
        path.myCollider = meshCollider;
        StartCoroutine(Create());
        
    }
    private IEnumerator Create()
    {
        yield return new WaitForEndOfFrame();
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, Camera.allCameras[0],true);
        meshCollider.sharedMesh = mesh;
    }
}
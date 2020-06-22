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

        //transform.GetChild(0).transform.parent = meshCollider.transform;
        //transform.GetChild(0).transform.parent = meshCollider.transform;
        FollowThePath path = meshCollider.gameObject.AddComponent<FollowThePath>();
        transform.Find("LocatorSprite").GetComponent<FollowSelector>().followScript = path;


        path.myLine = line;
        path.myCollider = meshCollider;
        StartCoroutine(Create());
        
    }
    private IEnumerator Create()
    {
        yield return new WaitForEndOfFrame();
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, Camera.allCameras[0],true);//SPAGHETTI
        meshCollider.sharedMesh = mesh;
    }
}
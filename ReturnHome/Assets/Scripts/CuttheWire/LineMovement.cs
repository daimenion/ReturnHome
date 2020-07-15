using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineMovement : MonoBehaviour
{
    LineRenderer line;
    GameObject lineStart;
    GameObject lineEnd;
    Vector3 endPosition;
    void Start()
    {
        lineStart = transform.Find("WireStart").gameObject;
        lineEnd = transform.Find("WireEnd").gameObject;
        line = GetComponent<LineRenderer>();
        Vector3 startPosition = new Vector3(lineStart.transform.localPosition.x, lineStart.transform.localPosition.y, 0);
        line.SetPosition(0, startPosition);
        endPosition = new Vector3(lineEnd.transform.localPosition.x, lineEnd.transform.localPosition.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        endPosition.x = lineEnd.transform.localPosition.x;
        endPosition.y = lineEnd.transform.localPosition.y;
        line.SetPosition(1, endPosition);
    }
}

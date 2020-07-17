using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Canvas))]
public class GetActiveCamera : MonoBehaviour
{
    private Canvas myCanvas;
    void Start()
    {
        myCanvas = GetComponent<Canvas>();
        myCanvas.worldCamera = Camera.allCameras[0];
        myCanvas.planeDistance = 1f;
        myCanvas.renderMode = RenderMode.WorldSpace;
    }
}

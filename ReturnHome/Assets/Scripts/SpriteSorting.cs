using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSorting : MonoBehaviour
{
    private Transform player;
    public Vector3 sortpoint = Vector3.zero;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Background";
        sortpoint = sortpoint + transform.position;
    }
    void Update()
    {
        if (player.position.x > sortpoint.x|| player.position.z > sortpoint.z) spriteRenderer.sortingLayerName = "Foreground";
        else spriteRenderer.sortingLayerName = "Background";
    }
}

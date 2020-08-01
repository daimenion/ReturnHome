using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSorting : MonoBehaviour
{
    private Transform player;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Background";
    }
    void Update()
    {
        if (player.position.x > transform.position.x || player.position.z > transform.position.z) spriteRenderer.sortingLayerName = "Foreground";
        else spriteRenderer.sortingLayerName = "Background";
    }
}

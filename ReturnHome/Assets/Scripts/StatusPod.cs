using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPod : MonoBehaviour
{
    public Sprite emptyPod;
    public int podNumber;
    SpriteRenderer spriteRenderer;
    private int deaths;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        deaths = PlayerPrefs.GetInt("PlayerDeath");
        if (podNumber <= deaths) spriteRenderer.sprite = emptyPod;
    }
}

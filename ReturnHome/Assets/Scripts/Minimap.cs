using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Collider))]

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    public Image roomsprite;
    Color baseColor;
    public Color accentColor;
    void Start()
    {
        if (roomsprite == null) print(gameObject.name);
        baseColor = roomsprite.color;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            roomsprite.color = Color.Lerp(baseColor, accentColor, Mathf.PingPong(Time.time, 1));
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            roomsprite.color = baseColor;
        }
    }
}

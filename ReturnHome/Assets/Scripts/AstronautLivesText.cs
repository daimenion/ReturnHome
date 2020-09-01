using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstronautLivesText : MonoBehaviour
{
    int deaths;
    public Text text;
    void Start()
    {
        deaths = PlayerPrefs.GetInt("PlayerDeath");
        int inStasis = 4 - deaths;
        if (deaths >= 0)
        {
            text.text = inStasis.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

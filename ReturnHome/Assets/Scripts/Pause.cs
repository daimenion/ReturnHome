using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = System.Convert.ToSingle(pauseMenu.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
        }
    }
}

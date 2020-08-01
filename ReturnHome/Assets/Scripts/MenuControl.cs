using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.DeleteAll();
    }
    public void Continue()
    {
        UnityEngine.UI.Text mytext = GameObject.Find("Flavor").GetComponent<UnityEngine.UI.Text>();
        mytext.text = "What did I just say?";
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

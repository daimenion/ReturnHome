using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    bool introText = false;//do NOT touch this outside of the menu scene
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.DeleteAll();
    }
    public void Continue()
    {
        UnityEngine.UI.Text mytext = GameObject.Find("Flavor").GetComponent<UnityEngine.UI.Text>();
        mytext.text = "What did I just say?";
        if(PlayerPrefs.HasKey("PlayerDeath")|| PlayerPrefs.HasKey("HowPlayerDie") || PlayerPrefs.HasKey("PlayerLastLocation"))
        SceneManager.LoadScene("SampleScene");
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void StartIntro()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.Play("Intro");
    }
    public void hasStarted()
    {
        introText = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && introText)
        {
            print("xyz");
            Outro();
        }
    }
    public void Outro()
    {
        Animator anim = GetComponentInChildren<Animator>();
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Outro"))
        {
            anim.Play("Outro");
        }
    }
}

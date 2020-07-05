using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomGameManager : MonoBehaviour
{
    int once;
    int playerDeaths;
    PlayerController player;
    public GameObject[] ghosts;
    int HowPlayerDie;
    public bool reset;
    // Start is called before the first frame update
    void Start()
    {
        if(reset)
            PlayerPrefs.DeleteAll();
        player = FindObjectOfType<PlayerController>();
        playerDeaths = PlayerPrefs.GetInt("PlayerDeath");
        if (playerDeaths > 0)
        {
            HowPlayerDie = PlayerPrefs.GetInt("HowPlayerDie");
            Instantiate(ghosts[HowPlayerDie],StringToVector3(PlayerPrefs.GetString("LastLocation")), ghosts[HowPlayerDie].transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0 && once == 0) {
            player.gameObject.transform.Rotate(0,0,90);
            playerDeaths++;
            SaveData();
            StartCoroutine(ResetScene());
            once = 1;
        }
    }
    IEnumerator ResetScene() {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");

    }
    void SaveData() {
        PlayerPrefs.SetInt("PlayerDeath", playerDeaths);
        PlayerPrefs.SetString("LastLocation", player.gameObject.transform.position.ToString());
        PlayerPrefs.SetInt("HowPlayerDie", HowPlayerDie);
        PlayerPrefs.Save();
    }

    void CheckEverything() { 
    
    }

    public static Vector3 StringToVector3(string sVector)
    {
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        string[] sArray = sVector.Split(',');

        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
}

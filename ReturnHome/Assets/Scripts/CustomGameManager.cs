using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomGameManager : MonoBehaviour
{
    int once;
    int playerDeaths;
    PlayerController player;
    public GameObject[] ghosts;

    int HowPlayerDie;
    int[] Deaths;
    public bool reset;

    //
    GameObject[] ItemSpawnPoints;
    public GameObject Box;
    // Start is called before the first frame update
    void Start()
    {
        Deaths = new int[5];

        if(reset)
            PlayerPrefs.DeleteAll();
        player = FindObjectOfType<PlayerController>();
        playerDeaths = PlayerPrefs.GetInt("PlayerDeath");
        if (playerDeaths > 0)
        {
            Deaths = GetIntPref();
            for(int i = 0; i < playerDeaths; i++)
            {
                Instantiate(ghosts[Deaths[i]], StringToVector3(PlayerPrefs.GetString("LastLocation")), ghosts[Deaths[i]].transform.rotation);
            }
           

        }
        ItemSpawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
        for (int i = 0; i < ItemSpawnPoints.Length - 1; i++) {
            Instantiate(Box, ItemSpawnPoints[i].transform.position, ItemSpawnPoints[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0 && once == 0) {
            CheckEverything(); 
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
        SetIntPrefArray();
        PlayerPrefs.Save();
    }

    void CheckEverything() {
        switch (player.AttackType) {
            case "None":
                HowPlayerDie = 1;
                break;
            case "Fire":
                HowPlayerDie = 2;
                break;

            case "Ghost":
                HowPlayerDie = 3;
                break;

            case "Bee":
                HowPlayerDie = 4;
                break;

            case "FoodPoisoning":
                HowPlayerDie = 5;
                break;

            case "Oxygen":
                HowPlayerDie = 6;
                break;

            case "Electricity":
                HowPlayerDie = 7;
                break;

            case "SuckIntoSpace":
                HowPlayerDie = 8;
                break;

        }
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

    void SetIntPrefArray() {
        for (int i = 0; i < playerDeaths; i++) {
            if (Deaths[i] == 0) {
                Deaths[i] = HowPlayerDie;
                PlayerPrefs.SetInt("HowPlayerDie" + i, Deaths[i]);
            }
        }
    }

    int[] GetIntPref() {
        int[] temp = new int[5];
        for (int i = 0; i < Deaths.Length; i++)
        {
            temp[i] = PlayerPrefs.GetInt("HowPlayerDie" + i);
        }
        return temp;

    }
}

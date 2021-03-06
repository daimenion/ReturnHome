﻿//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomGameManager : MonoBehaviour
{
    int once;
    int playerDeaths;
    PlayerController player;
    public GameObject[] ghosts;

    int HowPlayerDie;
    int[] Deaths;
    string[] PlayerLastLocations;
    public bool reset;
    float ShipHealth;
    public float MaxShipHealth;
    //
    GameObject[] ItemSpawnPoints;
    public GameObject Box;
    public GameObject loosescreen;

    public Image HPBar;
    public GameObject[] UniqueItems;
    public GameObject UniqueSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Deaths = new int[5];
        PlayerLastLocations = new string[5];

        //ship health hp bar 
        ShipHealth = MaxShipHealth;
        ShipHealth = ShipHealth * 0.1f;
        ShipHealth = ShipHealth / MaxShipHealth;
        HPBar.fillAmount = ShipHealth;
        //reset playerpref
        if (reset)
            PlayerPrefs.DeleteAll();
        player = FindObjectOfType<PlayerController>();
        //if player dies spawns ai


        playerDeaths = PlayerPrefs.GetInt("PlayerDeath");
        if (playerDeaths > 0)
        {
            Deaths = GetIntPref();
            PlayerLastLocations = GetStringPref();
            for(int i = 0; i < playerDeaths; i++)
            {
                Instantiate(ghosts[Deaths[i]], StringToVector3(PlayerLastLocations[i]), ghosts[Deaths[i]].transform.rotation);
            }


        }
        SpawnUniqueItems();
        //make objects in rooms invisible 

        //spawns boxes
        ItemSpawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
        for (int i = 0; i < ItemSpawnPoints.Length - 1; i++) {
            Instantiate(Box, ItemSpawnPoints[i].transform.position, ItemSpawnPoints[i].transform.rotation);
        }
        MakeObjectInv();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = ShipHealth;
        if (player.health <= 0 && once == 0) {
            CheckEverything(); 
            //player.gameObject.transform.Rotate(0,0,90);
            playerDeaths++;
            SaveData();
            StartCoroutine(ResetScene());
            once = 1;
        }
        if (ShipHealth >= MaxShipHealth) {
            //Time.timeScale = 0; Moved funtionality to the Navigational Console
        }
        if (playerDeaths >= 5) {
            //Time.timeScale = 0;
            Instantiate(loosescreen);
        }
    }
    IEnumerator ResetScene() {
        player.DeathAnim();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");

    }
    void SaveData() {
        PlayerPrefs.SetInt("PlayerDeath", playerDeaths);
        SetStringPrefArray();
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

    void MakeObjectInv()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        Transform[] childs = new Transform[50];
        for (int i = 0; i < rooms.Length - 1; i++)
        {

            if (rooms[i].transform.Find("fog") != null)
            {
                rooms[i].transform.Find("fog").gameObject.SetActive(true);
            }
        }
    }

    void SpawnUniqueItems() {
        if (playerDeaths > 0) {
           Instantiate(UniqueItems[Random.Range(0, UniqueItems.Length)],new Vector3(UniqueSpawnPoint.transform.position.x, 1.1f, UniqueSpawnPoint.transform.position.z), new Quaternion(0, 45, 0, 0));
        }
    }
    #region get/set and +/- functions
    //playerpref functions
    int[] GetIntPref()
    {
        int[] temp = new int[5];
        for (int i = 0; i < Deaths.Length; i++)
        {
            temp[i] = PlayerPrefs.GetInt("HowPlayerDie" + i);
        }
        return temp;

    }
    void SetIntPrefArray()
    {
        for (int i = 0; i < playerDeaths; i++)
        {
            if (Deaths[i] == 0)
            {
                Deaths[i] = HowPlayerDie;
                PlayerPrefs.SetInt("HowPlayerDie" + i, Deaths[i]);
            }
        }
    }

    string[] GetStringPref()
    {
        string[] temp = new string[5];
        for (int i = 0; i < PlayerLastLocations.Length; i++)
        {
            temp[i] = PlayerPrefs.GetString("PlayerLastLocation" + i);
        }
        return temp;

    }
    void SetStringPrefArray()
    {
        for (int i = 0; i < playerDeaths; i++)
        {
            if (string.IsNullOrEmpty(PlayerLastLocations[i]))
            {
                PlayerLastLocations[i] = player.gameObject.transform.position.ToString();
                PlayerPrefs.SetString("PlayerLastLocation" + i, PlayerLastLocations[i]);
            }
        }
    }

    public float GetShipHealth() {return ShipHealth;}

    public void AdjustShipHealth( float x) { ShipHealth += x; }

    #endregion
}

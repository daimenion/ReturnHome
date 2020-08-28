using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foresight : AdAndDis
{
    public override void Start()
    {
        Advantage = true;
        base.Start();

    }
    void Update()
    {

    }
    public override void AdvantageEffect()
    {
        base.AdvantageEffect();
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        for (int i = 0; i < rooms.Length - 1; i++)
        {

            if (rooms[i].transform.Find("fog") != null)
            {
                rooms[i].transform.Find("fog").gameObject.SetActive(false);
            }
        }
    }
}

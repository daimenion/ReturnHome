using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussed : AdAndDis
{
    int move = 1;
    int timer;
    Vector3 dir;
    public override void Start()
    {
        base.Start();
        myname = "Concussed";
    }
    void Update() {
        StartCoroutine(MovementChange());
        if (timer != 600)
        {
            timer++;
        }
    }
    public override void DisAdvantageEffect()
    {
        base.DisAdvantageEffect();
        
    }
    IEnumerator MovementChange() {
        if (move == 1&& timer == 600)
        {
            move = 2;
            yield return new WaitForSeconds(5.0f);
            player.stop = true;
            dir = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));


        }
        if (move == 2 && player.stop) {
            player.gameObject.transform.Translate(dir * Time.deltaTime/3);
            StartCoroutine(stop());
        }
    }
    IEnumerator stop()
    {
        if (move == 2)
        {
            yield return new WaitForSeconds(2.0f);
            player.stop = false;
            move = 1;
            timer = 0;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygentSystem : MonoBehaviour
{
    int adjusting;
    public int OxygenLevel;
    PlayerController player;
    float Seconds;
    float Amount;
    public Text LevelText;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        adjusting = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOxygenLevel();
    }
    void CheckOxygenLevel() {
        switch (OxygenLevel) {
            case 0:
                Seconds = 0;
                Amount = 100;
                break;

            case 1:
                Seconds = 0.3f;
                Amount = 2;
                break;

            case 2:
                if (player.oxygen < 40)
                {
                    Seconds = 0.2f;
                    Amount = -0.5f;
                }
                else
                {
                    Seconds = 1;
                    Amount = 2f;
                }
                break;

            case 3:
                if (player.oxygen < 80)
                {
                    Seconds = 0.2f;
                    Amount = -1f;
                }
                else {
                    Seconds = 2;
                    Amount = 0.50f;
                }
                break;

            case 4:
                Seconds = 0.2f;
                Amount = -2f;
                break;

            default:
                break;

        }
    }
    IEnumerator AdjustOxygen() {
        adjusting = 1;
        player.oxygen = Mathf.Clamp(player.oxygen - Amount, 0, 100); 
        yield return new WaitForSeconds(Seconds);
        adjusting = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            LevelText.text = ""+OxygenLevel;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")&&adjusting == 0)
        {
            StartCoroutine(AdjustOxygen());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(AdjustOxygen());
        }
    }
}

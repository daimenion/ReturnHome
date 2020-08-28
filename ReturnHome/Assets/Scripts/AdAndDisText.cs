using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdAndDisText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Advantage;
    public Text Disadvantage;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(updatetext());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator updatetext() { 
        yield return new WaitForSeconds(1.0f);

        if (player.GetComponents<AdAndDis>()[0].Advantage)
            Advantage.text = player.GetComponents<AdAndDis>()[0].myname;



        if (!player.GetComponents<AdAndDis>()[1].Advantage)
            Disadvantage.text = player.GetComponents<AdAndDis>()[1].myname;

    }
}

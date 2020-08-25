using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdAndDis : MonoBehaviour
{
    public bool Advantage;
    public PlayerController player;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (Advantage) {
            AdvantageEffect();
        }
        else{
            DisAdvantageEffect();
        }
    }
    public virtual void AdvantageEffect() { 
        
    }
    public virtual void DisAdvantageEffect()
    {

    }
}

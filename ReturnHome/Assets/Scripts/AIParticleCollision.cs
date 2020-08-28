using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIParticleCollision : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided");
        if (other.CompareTag("PlayerHitBox"))
        {
            GetComponent<AI>().DecreaseHealth(1f);
        }


    }
}

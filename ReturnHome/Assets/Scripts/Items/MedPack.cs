using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : Item
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DecreaseHealth(-25.0f);
            Destroy(this.gameObject);
        }
    }

}

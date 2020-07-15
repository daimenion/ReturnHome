using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public GameObject[] SpawnList;

    public float spawnRate;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnItem();
        }
    }

    public void spawnItem()
    {
        GameObject item = Instantiate(SpawnList[Random.Range(0, SpawnList.Length - 1)], 
            transform.position, new Quaternion(0,45,0,1)) as GameObject;
        Debug.Log("Spawned in " + item.name);   
        Destroy(this.gameObject);
    }
}

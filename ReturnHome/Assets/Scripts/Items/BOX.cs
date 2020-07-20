using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public GameObject[] SpawnList;

    public float spawnRate;
    public Sprite openbox;
    public Sprite emptybox;

    int once = 0;
    GameObject item;
    void Update() {
        if (GetComponent<Interaction>().Interacted && once == 0) {
            once = 1;
            GetComponent<Interaction>().enabled = false;
            transform.GetComponentInChildren<SpriteRenderer>().sprite = openbox;
            transform.GetComponentInChildren<ParticleSystem>().Play();
            StartCoroutine(spawnItem());

        }
        if (once == 1)
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y + 1.5f * Time.deltaTime, item.transform.position.z);
    }

    IEnumerator spawnItem()
    {
        
       item = Instantiate(SpawnList[Random.Range(0, SpawnList.Length - 1)],
             transform.position, new Quaternion(0, 45, 0, 1)) as GameObject;
      
        yield return new WaitForSeconds(1);
      
        item.GetComponent<Interaction>().Interacted = true;
        Debug.Log("Spawned in " + item.name);
        transform.GetComponentInChildren<SpriteRenderer>().sprite = emptybox;
        transform.GetComponentInChildren<ParticleSystem>().Stop();
        once = 2;
        StopCoroutine(spawnItem());
    }
}

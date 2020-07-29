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
    InventorySystem inventory;

    int once = 0;
    GameObject item;
    void Start() {
        inventory = FindObjectOfType<InventorySystem>();
    }
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
        int rand = Random.Range(0, SpawnList.Length);
        if (rand != SpawnList.Length)
        {
            if (inventory.Inventory[inventory.Inventory.Length - 1] == null)
            {
                item = Instantiate(SpawnList[rand],
                      transform.position, new Quaternion(0, 45, 0, 1)) as GameObject;

                yield return new WaitForSeconds(1);

                item.GetComponent<Interaction>().Interacted = true;
                changeBox();

            }
            else
            {
                int x = 0;
                for (int i = 0; i < inventory.Inventory.Length - 1; i++)
                {
                    if (inventory.Inventory[i] == null)
                    {
                        item = Instantiate(SpawnList[rand],
                        transform.position, new Quaternion(0, 45, 0, 1)) as GameObject;

                        yield return new WaitForSeconds(1);

                        item.GetComponent<Interaction>().Interacted = true;
                        changeBox();
                        yield break;
                    }
                    else {
                        x++;
                    }
                }
                if (x == inventory.Inventory.Length - 1) {
                    once = 2;
                    item = Instantiate(SpawnList[rand],
                        transform.position + new Vector3(Random.Range(-2, -2.5f), 0, Random.Range(-2, -2.5f)), new Quaternion(0, 45, 0, 1)) as GameObject;

                        yield return new WaitForSeconds(1);

                        changeBox();
                        StopCoroutine(spawnItem());
                }

            }
        }
        else {
            FindObjectOfType<PlayerController>().PlayerDecreaseHealth(10, "None");
            yield return new WaitForSeconds(1);
            changeBox();
        }
        StopCoroutine(spawnItem());

    }

    void changeBox() {
        Debug.Log("Spawned in " + item.name);
        transform.GetComponentInChildren<SpriteRenderer>().sprite = emptybox;
        transform.GetComponentInChildren<ParticleSystem>().Stop();
        once = 2;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWireScript : MinigameScript
{
    public GameObject[] wires;
    public MoveWire[] wireScripts;
    // Start is called before the first frame update
    void Start()
    {
        wireScripts = new MoveWire[wires.Length];
        for (int i =0; i < wires.Length; i += 1)
        {
            wireScripts[i] = wires[i].GetComponentInChildren<MoveWire>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isComplete = true;
        for (int i = 0; i < wireScripts.Length; i += 1)
        {
            if (wireScripts[i].isBroken == 0)
            {
                isComplete = false;
                break;
            }
            else if (wireScripts[i].isBroken == -1)
            {
                StartCoroutine(SelfDestruct());
                isComplete = false;
                break;
            }
        }
        if (isComplete)
        {
            StartCoroutine(WinGame());
        }
    }
    protected IEnumerator SelfDestruct()
    {
        for (int i = 0; i < wireScripts.Length; i += 1)
        {
            wireScripts[i].isActive = false;
        }
        yield return new WaitForSeconds(1.5f);
        base.failure();
        Destroy(gameObject);
    }
    public IEnumerator WinGame()
    {
        print("Win");
        isBroken = false;
     
        yield return new WaitForSeconds(1.5f);
        base.success();
        Destroy(transform.gameObject);
    }
}

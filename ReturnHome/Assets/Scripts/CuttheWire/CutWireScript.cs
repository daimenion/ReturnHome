using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWireScript : MinigameScript
{
    public GameObject[] wires;
    public MoveWire[] wireScripts;
    private bool playable = true;
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
        if (playable)
        {
            bool isComplete = true;
            for (int i = 0; i < wireScripts.Length; i += 1)
            {
                if (wireScripts[i].isBroken == -1)
                {
                    StartCoroutine(SelfDestruct());
                    isComplete = false;
                    playable = false;
                    break;
                }
                else if (wireScripts[i].isBroken == 0)
                {
                    isComplete = false;
                }
            }
            if (isComplete)
            {
                StartCoroutine(WinGame());
                playable = false;
            }
        }
    }
    protected IEnumerator SelfDestruct()
    {
        for (int i = 0; i < wireScripts.Length; i += 1)
        {
            wireScripts[i].isActive = false;
        }
        audioPlayer.clip = failureClip;
        audioPlayer.Play();
        yield return new WaitForSeconds(2.5f);
        base.failure();
        Destroy(gameObject);
    }
    public IEnumerator WinGame()
    {
        isBroken = false;
        audioPlayer.clip = winClip;
        audioPlayer.Play();
        yield return new WaitForSeconds(1.5f);
        base.success();
        Destroy(transform.gameObject);
    }
}

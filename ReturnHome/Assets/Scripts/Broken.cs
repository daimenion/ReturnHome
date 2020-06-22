using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    int Repaired;
    public GameObject Event;

    // Start is called before the first frame update
    void Start()
    {
        Repaired = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        switch (Repaired) {

            //repair failed
            case 0:
                failedRepair();
                break;

               // still borken
            case 1:

                break;

                //reparied sucessfully
            case 2:
                SucessRepair();
                break;


            default:
                break;
        }
    }

    protected virtual void failedRepair() { 
        

    }

    protected virtual void SucessRepair() { 
    

    }

    int GetRepaired() {
        return Repaired;
    }

    void SetRepaired(int x) {
        Repaired = x;
    }
}

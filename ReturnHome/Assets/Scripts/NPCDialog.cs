using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DialogManager))]
public class NPCDialog : MonoBehaviour
{
    public Dialog[] dialogue;
    public bool start;
    public GameObject Dialogbox;
    float dialogBoxDisappearTimer;
    public float timer = 0;
    public DialogManager dialogManager;
    //while in reseting
    public bool reseting;
    public int number;
    public bool NoDisplayButton;
    void Start()
    {

        //player = ReInput.players.GetPlayer(0);
    }

    void Update()
    {
        if (dialogManager != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
               if (start )
               {
                    if (dialogManager.returnstarted() || (dialogue[dialogManager.returnPressedCount()] != null && !dialogue[dialogManager.returnPressedCount()].NoSkip) && !dialogManager.ReturnDelaying())
                    {
                        TriggerDialogue();
                        Debug.Log("called1");
                    }
                    //if (dialogue[dialogManager.returnPressedCount()] != null && !dialogue[dialogManager.returnPressedCount()].NoSkip)
                    //{
                    //    TriggerDialogue();
                    //    Debug.Log("called2");
                    //}
                    
               }
                if (dialogManager.returnPressedCount() < dialogManager.returnlength() + 1)
                {
                    if (!dialogManager.returnstarted() && !dialogue[dialogManager.returnPressedCount()].NoSkip)
                    {
                        dialogManager.AddSkip(1);
                    }
                }

               if (dialogManager.returnstarted() && dialogManager.returnPressedCount() < dialogManager.returnlength() + 1 && !dialogManager.returnchoosing() && !dialogManager.ReturnDelaying())
               {
                    StartCoroutine(dialogManager.DisplayNextSentence());
               }
                dialogManager.SetStarted(false);
                //GetComponent<Interaction>().Interacted = false;
            }
            if (dialogManager.returnPressedCount() > dialogManager.returnlength())
            {
                ResetFunc();
            }
        }

        if (reseting)
        {
            timer++;
            if (timer >= 10)
            {
                reseting = false;
                start = true;
                if(dialogManager!= null)
                    dialogManager.SetSkip(0);
                timer = 0;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogManager = GetComponent<DialogManager>();

            start = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogManager = null;

            start = false;
        }
    }



    public void TriggerDialogue()
    {
        dialogManager = GetComponent<DialogManager>();
        if (GameObject.FindObjectOfType<PlayerController>() != null)
            //GameObject.FindObjectOfType<PlayerController>().setStop(true);

        Dialogbox.SetActive(true);
        dialogManager.StartDialogue(dialogue);

    }

    public void NewTriggerDialogue()
    {
        dialogManager = GetComponent<DialogManager>();
        if(GameObject.FindObjectOfType<PlayerController>() !=null)
        //GameObject.FindObjectOfType<PlayerController>().setStop(true);
        start = true;

        Dialogbox.SetActive(true);
        dialogManager.StartDialogue(dialogue);

    }

    public void ResetFunc()
    {
        if (GameObject.FindObjectOfType<PlayerController>() != null)
           // GameObject.FindObjectOfType<PlayerController>().setStop(false);
        Dialogbox.SetActive(false);
        reseting = true;
        start = false;

        dialogBoxDisappearTimer = 0;
        dialogManager.setPressedCount(0, 0);
        number++;
    }
    //set and get number
    public int GetNumber() {
        return number;
    }
    public void SetNumber(int x) {
        number = x;
    }
    //set dialog
    public void SetDialogue(Dialog[] dialog) {
        dialogue = dialog;   
    }
}

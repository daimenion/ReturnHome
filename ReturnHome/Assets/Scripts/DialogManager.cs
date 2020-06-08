using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Text firstChoice;
    public Text secondChoice;
    public Text thirdChoice;

    public GameObject firstChoiceButton;
    public GameObject secondChoiceButton;
    public GameObject thirdChoiceButton;

    public string[] names;
    public string[] sentences;
    public int[] ids;
    public string[] choices;
    public int[] choicesid;
    public int count;

    public bool[] end;
    public bool[] delay;
    public float[] delayTime;
    public bool delaying;

    public bool started;

    string nam;
    string sentence;

    int length;
    Dialog[] dialog;

    bool choosing;
    bool chosed;

    int chosedid;
    int temp;
    int SelectedId;

    public int skip;

    float TexxtSpeed = 0.01f;
    //number increase when one set of dialog is done.
    //public int DialogNumber;
    void Start()
    {
        //sentences = new Queue<string>();
        //names = new Queue<string>();
        EventSystem es = EventSystem.current;
        es.SetSelectedGameObject(null); //Resetting the currently selected GO
        es.firstSelectedGameObject = firstChoiceButton;
        es.SetSelectedGameObject(firstChoiceButton);
    }
    void Update()
    {

    }

    //public void StartDialogue(Dialog dialogue)
    //{

    //    // nameText.text = dialogue.name;

    //    names.Clear();

    //    sentences.Clear();

    //    foreach (string sentence in dialogue.sentences)
    //    {
    //        sentences.Enqueue(sentence);
    //    }
    //    foreach (string name in dialogue.name)
    //    {
    //        names.Enqueue(name);
    //    }
    //    DisplayNextSentence();
    //}

    //public void DisplayNextSentence()
    //{
    //    started = false;
    //    count++;
    //    if (sentences.Count == 0)
    //    {
    //        return;
    //    }

    //    string sentence = sentences.Dequeue();
    //    string name = names.Dequeue();
    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(sentence));
    //    nameText.text = name;
    //}

    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";

    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //    }
    //    started = true;
    //}
    //public int returnPressedCount() {
    //    return count;
    //}
    //public void setPressedCount(int x) {
    //    count = x;
    //}
    //public bool returnstarted() {
    //    return started;
    //}
    public void StartDialogue(Dialog[] dialogue)
    {
        dialog = dialogue;
        Array.Clear(names, 0, names.Length);
        Array.Clear(sentences, 0, sentences.Length);
        Array.Clear(ids, 0, ids.Length);
        Array.Clear(end, 0, end.Length);


        end = new bool[dialogue.Length];
        delay = new bool[dialogue.Length];
        delayTime = new float[dialogue.Length];
        names = new string[dialogue.Length];
        sentences = new string[dialogue.Length];
        ids = new int[dialogue.Length];
        choices = new string[0];
        choicesid = new int[0];

        if (choices.Length == 0)
        {
            firstChoiceButton.SetActive(false);
            secondChoiceButton.SetActive(false);
            thirdChoiceButton.SetActive(false);
        }

        //nameText.text = dialogue[0].name;
        //nam = dialogue[0].name;

        //sentence = dialogue[0].sentences;
        //dialogueText.text = dialogue[0].sentences;
        length = dialogue.Length;
        for (int i = 0; i < dialogue.Length; i++)
        {
            names[i] = dialogue[i].name;
            sentences[i] = dialogue[i].sentences;
            ids[i] = dialogue[i].id;
            end[i] = dialogue[i].End;
            delay[i] = dialogue[i].Delay;
            delayTime[i] = dialogue[i].DelayTime;
        }
        StartCoroutine(DisplayNextSentence());
    }

    public IEnumerator DisplayNextSentence()
    {
        if (count == length)
        {
            count++;
            Debug.Log("over");
            //DialogNumber++;
        }
        else if (count != length)
        {
            if (delay[count])
            {
                delaying = true;
                yield return new WaitForSeconds(delayTime[count]);
                started = false;
                if (count == length)
                {
                    Debug.Log("over");
                    count++;
                    //DialogNumber++;
                }
                else
                {
                    nameText.text = names[ids[count]];
                    dialogueText.text = sentences[ids[count]];
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(sentences[ids[count]]));
                }
            }

            if (!delay[count])
            {
                if (count == length)
                {
                    Debug.Log("over");
                    count++;
                   
                    //DialogNumber++;
                }
                delaying = false;
                started = false;
                if (count == length)
                {
                    count++;
                    //DialogNumber++;
                }

                else
                {
                    nameText.text = names[ids[count]];
                    dialogueText.text = sentences[ids[count]];
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(sentences[ids[count]]));


                }
            }
        }
        //Debug.Log(names.Length);
    }
    IEnumerator TypeSentence(string sentence)
    {
        

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (skip >= 2)
            {

                //skip = 0;
            }
            else
            {
                yield return new WaitForSeconds(TexxtSpeed);
            }
        }
        choicesid = new int[0];
        if (count != length)
        {
            if (dialog[count].choices.Length > 0)
            {
                if (dialog[count].choices.Length > 0)
                {
                    choices = new string[dialog[count].choices.Length];
                    choicesid = new int[dialog[count].choiceid.Length];
                    for (int j = 0; j < dialog[count].choices.Length; j++)
                    {
                        choices[j] = dialog[count].choices[j];
                        choicesid[j] = dialog[count].choiceid[j];
                    }
                }
            }
            if (choices.Length > 0)
            {
                temp = choices.Length;
                choosing = true;
                if (choices[0] != null)
                {
                    firstChoiceButton.SetActive(true);
                    firstChoiceButton.GetComponent<Selectable>().Select();
                    firstChoice.text = choices[0];
                    firstChoiceButton.GetComponent<Button>().onClick.AddListener(delegate { setPressedCount(choicesid[0], 1); });
                }
                if (choices.Length > 1)
                {

                    if (choices[1] != null)
                    {
                        secondChoiceButton.SetActive(true);
                        secondChoice.text = choices[1];
                        secondChoiceButton.GetComponent<Button>().onClick.AddListener(delegate { setPressedCount(choicesid[1], 2); });
                    }
                }
                if (choices.Length > 2)
                {
                    if (choices[2] != null)
                    {
                        thirdChoiceButton.SetActive(true);
                        thirdChoice.text = choices[2];
                        thirdChoiceButton.GetComponent<Button>().onClick.AddListener(delegate { setPressedCount(choicesid[2], 3); });
                    }
                }
            }
            else
            {
                choices = new string[0];
            }
        }
        delaying = false;
        started = true;
        if (end[count])
        {
            count = length-1;
        }
        if (!chosed&&!delaying)
        {
            count++;
            //Debug.Log("over1");
        }
        else
        {
            if (!delaying)
            {
                if (temp == 3)
                    threechoices();
                else if (temp == 2)
                {

                    twochoices();
                }
                else
                {
                    //Debug.Log("over1");
                    count++;
                }
                Debug.Log("choices" + choices.Length);
            }

        }
        skip = 0;
    }

    public void setPressedCount(int x, int y)
    {
        count = x;
        chosedid = y;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        firstChoiceButton.SetActive(false);
        secondChoiceButton.SetActive(false);
        thirdChoiceButton.SetActive(false);
        if (choices.Length > 0)
            chosed = true;
        choosing = false;
        choices = new string[0];
        switch (y)
        {
            case 1:
                if(choicesid.Length>1)
                SelectedId = choicesid[1];
                break;
            case 2:
                if (choicesid.Length > 2)
                    SelectedId = choicesid[2];
                break;
        }
    }

    //if there is two choices 
    void twochoices()
    {
        if (chosedid == 1 && !delaying)
        {
            count++;
            //Debug.Log("over1");
            //setNewCount(2);
            if (count == SelectedId)
            {
                count = length;
                SetNew();
                SelectedId = 0;
            }
        }
        if (chosedid == 2 && !delaying)
        {
            count++;
            //Debug.Log("over1");
            SetNew();
            SelectedId = 0;

        }
    }
    //if there is three choices 
    void threechoices()
    {
        if (chosedid == 1 && !delaying)
        {
            count++;
            //Debug.Log("over1");
            //setNewCount(3);
            if (count == SelectedId)
            {
                count = length;
                SetNew();
                SelectedId = 0;

            }
        }
        if (chosedid == 2 && !delaying)
        {
            count++;
            //Debug.Log("over1");
            //setNewCount(2);
            if (count == SelectedId)
            {
                count = length;
                SetNew();
                SelectedId = 0;
            }
        }
        if (chosedid == 3 && !delaying)
        {
            count++;
            //Debug.Log("over1");
            SetNew();
            SelectedId = 0;
        }
    }
    #region get and set functions
    //for oldman script
    public void SetCount(int x)
    {
        count = x;
    }
    public int returnPressedCount()
    {
        return count;
    }
    public bool returnstarted()
    {
        return started;
    }
    public void SetStarted(bool x )
    {
        started = x ;
    }
    //return length of the array
    public int returnlength()
    {
        return length;
    }
    public bool returnchoosing()
    {
        return choosing;
    }
    //set count and reset count
    void setNewCount(int x)
    {
        chosed = false;
        count += x;
        chosedid = 0;
        temp = 0;
    }
    public int ReturnChoseId()
    {
        return chosedid;
    }

    void SetNew()
    {
        chosed = false;
        chosedid = 0;
        temp = 0;
    }
    //skip dialogue numbers 
    public void AddSkip(int x)
    {
        skip += x;
    }

    public void SetSkip(int x)
    {
        skip = x;
    }
    //return dialognumber 
    //public int ReturnDialogueNumber() {
    //    return DialogNumber;
    //}

    public bool ReturnDelaying() {
        return delaying;
    }
}
#endregion
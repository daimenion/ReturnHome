using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextColorChange : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Text text;
    bool select;
    public NPCDialog dialog;
    public DialogManager dialogManager;
    public bool third;
    // Start is called before the first frame update
    void Start()
    {
        //dialogManager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!select)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = Color.red;
            OnSelect(null);
        }
        if (dialog != null && !select && third)
        {
            if (dialog.GetNumber() == 3)
            {
                if (dialogManager.returnPressedCount() == 12)
                {
                    text.color = new Color(0.953f, 0.8184233f, 0.5707992f, 1);
                }
            }
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        select = true;
        //text.color = Color.red;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        select = false;
        //text.color = Color.black;
    }

}
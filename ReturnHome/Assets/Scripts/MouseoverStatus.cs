using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseoverStatus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public int slotNumber;
    StatusUI statusUI;
    void Start()
    {
        statusUI = FindObjectOfType<StatusUI>();
    }
    public void OnPointerEnter(PointerEventData eventData){
        statusUI.Tooltip(slotNumber);
    }

    public void OnPointerExit(PointerEventData eventData){
        statusUI.CloseTooltip();
    }
}

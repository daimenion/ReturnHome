using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] renderers;
    private string[] names;
    private string[] descriptions;
    int activeEffects = 0;

    public GameObject tooltip;
    public Text effectName;
    public Text effectDesription;
    private int toolNum = -1;
    void Start()
    {
        names = new string[renderers.Length];
        descriptions = new string[renderers.Length];
    }
    public void AddEffect(StatusEffect effect)
    {
        renderers[activeEffects].sprite = effect.sprite;
        renderers[activeEffects].color = Color.white;
        names[activeEffects] = effect.effectName;
        descriptions[activeEffects] = effect.effectDescription;
        activeEffects++;
    }
    public void RemoveEffect(StatusEffect effect)
    {
        for (int currentEffect = 0; currentEffect < activeEffects; currentEffect++)
        {
            if (names[currentEffect] == effect.effectName)
            {
                Replace(currentEffect);
                activeEffects--;
                break;
            }
        }
    }
    private void Replace(int i)
    {
        if (i < renderers.Length - 1)
        {
            renderers[i].sprite = renderers[i + 1].sprite;
            renderers[i].color = renderers[i + 1].color;
            names[i] = names[i + 1];
            descriptions[i] = descriptions[i + 1];
            Replace(i + 1);
        }
        else
        {
            renderers[i].sprite = null;
            renderers[i].color = Color.clear;
            names[i] = null;
            descriptions[i] = null;
            if (toolNum >= 0)
            {
                Tooltip(toolNum);
            }
        }
    }
    public void Tooltip(int number)
    {
        if (names[number] != null)
        {
            tooltip.SetActive(true);
            effectName.text = names[number];
            effectDesription.text = descriptions[number];
            toolNum = number;
        }
        else CloseTooltip();
    }
    public void CloseTooltip()
    {
        tooltip.SetActive(false);
        toolNum = -1;
    }
    void Update()
    {
        tooltip.transform.position = Input.mousePosition;
    }
}

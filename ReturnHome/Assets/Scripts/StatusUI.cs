using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] renderers;
    private string[] names;
    int activeEffects = 0;
    void Start()
    {
        names = new string[renderers.Length];
    }
    public void AddEffect(StatusEffect effect)
    {
        renderers[activeEffects].sprite = effect.sprite;
        renderers[activeEffects].color = Color.white;
        names[activeEffects] = effect.effectName;
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
            Replace(i + 1);
        }
        else
        {
            renderers[i].sprite = null;
            renderers[i].color = Color.clear;
            names[i] = null;
        }
    }
}

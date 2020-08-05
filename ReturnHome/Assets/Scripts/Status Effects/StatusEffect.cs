using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Actor))]
public class StatusEffect : MonoBehaviour
{
 
        public float duration; //-1 duration means forever
        public string effectName;
        public string effectDescription;
        public Sprite sprite;

    public StatusEffect()
    {
        duration = -1;
        effectName = "Noname";
        effectDescription = "Did you forget something?";
    }
   protected virtual void Update()
    {
        if (duration > 0)
        {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
        }
        if (duration == 0)
        {
            EndEffect();
        }
    }
    public void EndEffect()
    {
        FindObjectOfType<StatusUI>().RemoveEffect(this);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationInteraction : Interaction
{
    private CustomGameManager gameManager;
    private Animator anim;
    public Outline outline;
    private Color color;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<CustomGameManager>();
        anim = GetComponentInChildren<Animator>();
        color = outline.effectColor;
    }
    override protected void myInteraction()
    {
        float currentHealth = gameManager.GetShipHealth();
        if (currentHealth >= 1 && Interacted == false)
        {
            print("Congrats, you returned home.");
            anim.Play("Base Layer.Winscreen", 0, 0.25f);
            Interacted = true;
        }
        else StartCoroutine(FlashOutline());
    }
    private IEnumerator FlashOutline()
    {
        for (float i = 0; i < 3; i += Time.deltaTime)
        {
            var pingPong = Mathf.PingPong(Time.time, 1);
            outline.effectColor = Color.Lerp(color, Color.red, pingPong);
            yield return new WaitForEndOfFrame();
        }
        outline.effectColor = color;
    }
}

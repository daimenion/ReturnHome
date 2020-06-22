using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MinigameScript
{
    // Start is called before the first frame update
    public bool isActive = false;
    public MeshCollider myCollider;
    public LineRenderer myLine;

    // Update is called once per frame
    void Start()
    {
    }
    void OnMouseOver()
    {
    }
    void OnMouseExit()
    {
        if (isActive)
        {
                StartCoroutine(SelfDestruct());
                isActive = false;
        }
    }
    protected IEnumerator SelfDestruct()
    {
        myLine.startColor = Color.red;
        myLine.endColor = Color.red;
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Electrocute(100f);//Temp Value for Mike Test, to kill player
        
        Destroy(transform.parent.gameObject);
    }
    public IEnumerator WinGame()
    {
        isBroken = false;
        myLine.startColor = Color.green;
        myLine.endColor = Color.green;
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}

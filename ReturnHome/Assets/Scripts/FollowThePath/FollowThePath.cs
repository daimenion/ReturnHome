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
        isBroken = true;
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
        base.failure();
        
        Destroy(transform.parent.gameObject);
    }
    public IEnumerator WinGame()
    {
        myLine.startColor = Color.green;
        myLine.endColor = Color.green;
        base.success();
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}

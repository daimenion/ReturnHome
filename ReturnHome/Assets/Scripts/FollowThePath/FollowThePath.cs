using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MinigameScript
{
    // Start is called before the first frame update
    public bool isActive = false;
    public MeshCollider myCollider;
    public LineRenderer myLine;
    private SpriteRenderer sprite;

    // Update is called once per frame
    void Start()
    {
        isBroken = true;
        sprite = GetComponent<SpriteRenderer>();
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
        audioPlayer.clip = failureClip;
        audioPlayer.Play();
        yield return new WaitForSeconds(2.5f);
        base.failure();
        
        Destroy(transform.parent.gameObject);
    }
    public IEnumerator WinGame()
    {
        isActive = false;
        audioPlayer.clip = winClip;
        audioPlayer.Play();
        myLine.startColor = Color.green;
        myLine.endColor = Color.green;
        base.success();
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}

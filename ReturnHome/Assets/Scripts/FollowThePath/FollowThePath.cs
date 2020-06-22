using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActive = false;
    public MeshCollider myCollider;
    public LineRenderer myLine;
    GameObject goal;

    // Update is called once per frame
    void Start()
    {
        goal = transform.Find("Goal").gameObject;
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
    private IEnumerator SelfDestruct()
    {
        print("OH SHIT");
        myLine.startColor = Color.red;
        myLine.endColor = Color.red;
        yield return new WaitForSeconds(1.5f);
        
        Destroy(transform.parent.gameObject);
    }
    public IEnumerator WinGame()
    {

        myLine.startColor = Color.green;
        myLine.endColor = Color.green;
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}

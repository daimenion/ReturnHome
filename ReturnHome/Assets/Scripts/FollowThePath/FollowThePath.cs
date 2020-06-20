using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActive = false;
    public MeshCollider myCollider;
    public LineRenderer myLine;

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isActive = false;
        }
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
}

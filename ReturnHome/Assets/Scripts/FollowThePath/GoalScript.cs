using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public bool gamewon = false;

    // Update is called once per frame
    void OnMouseOver()
    {
        if (transform.parent.GetComponent<FollowThePath>() != null)
        {
            if (transform.parent.GetComponent<FollowThePath>().isActive)
            {
                gamewon = true;
            }
        }
    }
}

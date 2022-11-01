using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverDetection : MonoBehaviour
{
    public PlayerController pc;
    public BoxCollider2D bc;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (pc.crouch_state)
        {
            bc.isTrigger = true;
        }
        //Debug.Log("left cover");
        else
        {
            bc.isTrigger = false;
        }
    }
}

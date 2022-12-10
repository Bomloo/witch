using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    static GameObject self;

    private void Start()
    {
        if(self == null)
        {
            self = this.gameObject;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -20);
        //can put a collider with trigger that follows position with player, a central perimeter
    }
}

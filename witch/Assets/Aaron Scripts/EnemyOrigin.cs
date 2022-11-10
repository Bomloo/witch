using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrigin : MonoBehaviour
{
    public Transform player;
    public Vector2 coord;
    

    // Update is called once per frame
    void Update()
    {
        coord = player.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(coord.y, coord.x) * Mathf.Rad2Deg - 90f);
    }
}

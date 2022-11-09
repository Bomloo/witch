using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public Transform shootpt;
    public Vector2 coord;
    public Vector2 shoot;
    public float run_speed = 2f;
    public int range = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.position, shootpt.up, range);
        if (hit.transform.CompareTag("Player") == false)
        {
            coord = new Vector2(0, 0);
            Debug.Log("blind");
        }
        else {
            coord = player.position - transform.position;
            coord = coord.normalized;
            Debug.Log("spot");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(coord.x * run_speed, coord.y * run_speed);
    }
}

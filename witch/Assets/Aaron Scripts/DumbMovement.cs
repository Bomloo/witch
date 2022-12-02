using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public Transform shootpt;
    public LayerMask inquire;
    public Vector2 coord;
    public float run_speed = 2f;
    public int range = 10;

    public bool seeing = false;
    public bool rest_state = false;
    public bool moving = false;
    public bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.position, shootpt.up, range, inquire);
        if (hit.transform == null || hit.transform.CompareTag("Player") == false || touch)
        {
            coord = new Vector2(0, 0);
            seeing = false;
            //Debug.Log("blind");
        }
        else
        {
            coord = player.position - transform.position;
            coord = coord.normalized;
            seeing = true;
            //Debug.Log("spot");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(coord.x * run_speed, coord.y * run_speed);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            touch = true;
        }
        else
        {
            touch = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }
}

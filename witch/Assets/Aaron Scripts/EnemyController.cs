using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public Transform shootpt;
    public BoxCollider2D trig;
    public EnemyHealth self_health;
    public Vector2 coord;
    public Vector2 shoot;
    public float run_speed = 2f;
    public int range = 10;

    public bool ranged_z = true;
    public bool chase_z = false;

    public bool seeing = false;
    public bool rest_state = false;
    public bool moving = false;
    public bool touch = false;

    public int atk_range = 0;
    public float atk_timer = 0f;
    public float rest_timer = 0f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chase_z)
        {
            atk_range = 1;
            if (rest_state == false && touch == true)
            {
                rest_state = true;
                atk_timer = 0f;
                StartCoroutine(fire(atk_range, atk_timer));
            }
            else if (moving == true)
            {
                moving = false;
                rest_timer = 2f;
                StartCoroutine(buffer(rest_timer));
            }
        }

        if (ranged_z)
        {
            atk_range = 10;
            //Debug.Log("ranged");
            if (rest_state == false && (seeing == true || touch == true))
            {
                rest_state = true;
                atk_timer = (float)Random.Range(4, 6);
                StartCoroutine(fire(atk_range, atk_timer));
            }
            else if (moving == true)
            {
                moving = false;
                rest_timer = (float)Random.Range(2, 4);
                StartCoroutine(buffer(rest_timer));
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(shootpt.position, shootpt.up, range);
        if (hit.transform == null || hit.transform.CompareTag("Player") == false || touch)
        {
            coord = new Vector2(0, 0);
            seeing = false;
            //Debug.Log("blind");
        }
        else {
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

    public void attack(int atk_range)
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.position, shootpt.up, atk_range);
        if (hit.transform == null || hit.transform.CompareTag("Player") == false)
        {
            //Debug.Log("miss");
        }
        else
        {
            //Debug.Log("hit");
            hit.transform.GetComponent<PlayerController>().take_dmg(2, self_health);
        }
    }

    private IEnumerator fire(int atk_range, float atk_timer)
    {
        //Debug.Log("working");
        float start = 0f;
        while (start <= atk_timer)
        {
            coord = new Vector2(0, 0);
            start += Time.deltaTime;
            yield return null;
        }
        attack(atk_range);
        moving = true;
        Debug.Log("atk once");

    }

    private IEnumerator buffer(float rest_timer)
    {
        float start = 0f;
        while (start <= rest_timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
        //Debug.Log("rest");
        rest_state = false;
    }
}

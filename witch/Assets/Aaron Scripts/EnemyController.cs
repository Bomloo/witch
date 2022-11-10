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

    public bool ranged_z = false;
    public bool chase_z = true;

    public int atk_range = 0;
    public float atk_timer = 0f;
    public float rest_timer = 0f;

    private void Start()
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

    public void attack(int atk_range)
    {

    }

    private IEnumerator fire(int range, float atk_timer)
    {
        float start = 0f;
        while (start <= atk_timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
        attack(atk_range)
    }

    private IEnumerator buffer(float rest_timer)
    {
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public DumbMovement state;
    public EnemyHealth health;
    public Vector2 shoot;

    public bool ranged_z = true;
    public bool chase_z = false;

    public int atk_range = 0;
    public float atk_timer = 0f;
    public float rest_timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        state = this.GetComponent<DumbMovement>();
        health = this.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase_z)
        {
            atk_range = 1;
            if (state.rest_state == false && state.touch == true)
            {
                state.rest_state = true;
                atk_timer = 0f;
                StartCoroutine(fire(atk_range, atk_timer));
            }
            else if (state.moving == true)
            {
                state.moving = false;
                rest_timer = 2f;
                StartCoroutine(buffer(rest_timer));
            }
        }

        if (ranged_z)
        {
            atk_range = 10;
            //Debug.Log("ranged");
            if (state.rest_state == false && (state.seeing == true || state.touch == true))
            {
                state.rest_state = true;
                atk_timer = (float)Random.Range(4, 6);
                StartCoroutine(fire(atk_range, atk_timer));
            }
            else if (state.moving == true)
            {
                state.moving = false;
                rest_timer = (float)Random.Range(2, 4);
                StartCoroutine(buffer(rest_timer));
            }
        }
    }

    public void attack(int atk_range)
    {
        RaycastHit2D hit = Physics2D.Raycast(state.shootpt.position, state.shootpt.up, atk_range);
        if (hit.transform == null || hit.transform.CompareTag("Player") == false)
        {
            //Debug.Log("miss");
        }
        else
        {
            //Debug.Log("hit");
            hit.transform.GetComponent<PlayerController>().take_dmg(2, health);
        }
    }

    private IEnumerator fire(int atk_range, float atk_timer)
    {
        //Debug.Log("working");
        float start = 0f;
        while (start <= atk_timer)
        {
            state.coord = new Vector2(0, 0);
            start += Time.deltaTime;
            yield return null;
        }
        attack(atk_range);
        state.moving = true;
        //Debug.Log("atk once");

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
        state.rest_state = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public PlayerController controller;
    public BoxCollider2D bc;
    public SpriteRenderer gun;
    public Card curr_card;
    public Camera cam;

    Vector2 coord;
    float horizontal_move = 0f;
    float vertical_move = 0f;
    public float run_speed = 10f;

    
    public float dash_speed = 15f;
    public float dash_timer = .3f;
    public float dash_dir = 0f;
    public float rest_timer = 10f;

    public float shoot_timer = 0.25f;
    public float reload_timer = 2f;

    

    


    // Update is called once per frame
    void Update()
    {
        //gets horizontal axis, at base, a = -1, d = 1, still = 0

        

        if (controller.reload_state)
        {
            controller.reload_state = false;
            gun.enabled = false;
            run_speed -= 2;
            StartCoroutine(countdown_reload(reload_timer));
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curr_card = controller.hand[0];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curr_card = controller.hand[1];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curr_card = controller.hand[2];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }



        //if (Input.GetKey(KeyCode.C))
        //{
        //    coord = new Vector2(0, 0);
        //    controller.crouch();
        //}

        else if (Input.GetKeyDown(KeyCode.LeftShift) && controller.resting == false)
        {
            controller.dash_state = true;
            controller.resting = true;
            coord = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dash_dir = Mathf.Atan2(coord.y, coord.x);
            StartCoroutine(dash(dash_speed, dash_timer, dash_dir));
            StartCoroutine(rest(rest_timer));
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && controller.reloading == false)
        {
            controller.attack_state = true;
            StartCoroutine(countdown_attack(shoot_timer));
        }

        else
        {
            horizontal_move = Input.GetAxisRaw("Horizontal");
            vertical_move = Input.GetAxisRaw("Vertical");

            coord = new Vector2(horizontal_move, vertical_move).normalized;
        }

    }

    private void FixedUpdate()
    {
        if (controller.dash_state == true)
        {
            return;
        }
        else
        {
            controller.move(coord.x * run_speed, coord.y * run_speed);
        }
    }



    private IEnumerator countdown_attack(float timer)
    {
        float start = 0f;
        while (start <= timer)
        {
            coord = new Vector2(0, 0);
            start += Time.deltaTime;
            yield return null;
        }
        controller.attack();
    }

    private IEnumerator countdown_reload(float timer)
    {
        float start = 0f;

        while (start <= timer)
        {
            //Debug.Log("reloading");
            start += Time.deltaTime;
            yield return null;
        }
        controller.reload();
        gun.enabled = true;
        run_speed += 2;
    }

    private IEnumerator dash(float dash_speed, float dash_timer, float dash_dir)
    {
        float start = 0f;
        coord = new Vector2((float)Mathf.Cos(dash_dir), (float)Mathf.Sin(dash_dir)).normalized;
        controller.move(coord.x * dash_speed, coord.y * dash_speed);
        while (start <= dash_timer)
        {
            start += Time.deltaTime;
            Debug.Log("dashing");
            yield return null;
        }
        controller.dash_state = false;
    }

    private IEnumerator rest(float rest_timer)
    {
        float start = 0f;
        while (start <= rest_timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
        controller.resting = false;
    }
}

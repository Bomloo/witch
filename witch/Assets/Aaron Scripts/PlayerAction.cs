using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public PlayerController controller;
    public BoxCollider2D bc;

    float horizontal_move = 0f;
    float vertical_move = 0f;
    public float run_speed = 10f;
    public float shoot_timer = 0f;
    public float reload_timer = 0f;
    public Card curr_card;
    

    Vector2 coord;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //gets horizontal axis, at base, a = -1, d = 1, still = 0

        if (controller.reload_state)
        {
            
            controller.reload_state = false;
            StartCoroutine(countdown_reload(reload_timer));
        }



        if (Input.GetKey(KeyCode.Alpha1))
        {
            curr_card = controller.hand[0];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            curr_card = controller.hand[1];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            curr_card = controller.hand[2];
            if (curr_card.isActive)
            {
                curr_card.Active(controller);
            }
        }



        if (Input.GetKey(KeyCode.C))
        {
            coord = new Vector2(0, 0);
            controller.crouch();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && controller.reloading == false)
        {
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
        controller.move(coord.x * run_speed, coord.y * run_speed);
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
            Debug.Log("reloading");
            start += Time.deltaTime;
            yield return null;
        }
        controller.reload();
    }
}

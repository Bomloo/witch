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
    

    Vector2 coord;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //gets horizontal axis, at base, a = -1, d = 1, still = 0

        if (controller.ammo == 0)
        {
            StartCoroutine(countdown(reload_timer));
            controller.reload();
        }

        if (Input.GetKey(KeyCode.C))
        {
            coord = new Vector2(0, 0);
            controller.crouch();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && controller.ammo > 0)
        {
            StartCoroutine(freeze_countdown(shoot_timer));
            controller.attack();
        }

        else
        {
            horizontal_move = Input.GetAxisRaw("Horizontal");
            vertical_move = Input.GetAxisRaw("Vertical");

            coord = new Vector2(horizontal_move, vertical_move).normalized;
        }

        //hold c 
    }

    private void FixedUpdate()
    {
        controller.move(coord.x * run_speed, coord.y * run_speed);
    }

    private IEnumerator freeze_countdown(float timer)
    {
        float start = 0f;

        while (start <= timer)
        {
            coord = new Vector2(0, 0);
            start += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator countdown(float timer)
    {
        float start = 0f;

        while (start <= timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
    }
}

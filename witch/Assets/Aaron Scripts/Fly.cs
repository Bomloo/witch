using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    public float dmg = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move(speed);
    }

    private void move(float speed)
    {
        rb.velocity = new Vector2(-1 * speed, 0);
    }

    private void attack(float dmg)
    {

    }
}

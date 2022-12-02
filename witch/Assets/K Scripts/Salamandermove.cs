using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salamandermove : MonoBehaviour
{

    #region Movment_vars
    [SerializeField]
    [Tooltip("Changes what the normal move speed is")]
    private float movespeed;
    private Rigidbody2D salRB;
    //private Transform pc;
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float distance;
    private bool forward;
    private Vector2 objective;
    #endregion

    #region Attack_vars
    [SerializeField]
    [Tooltip("The ammount of damage salamander does on hit")]
    private int dmg;
    [SerializeField]
    [Tooltip("Amount of time between attacks")]
    private float attTimer;
    #endregion


    #region Unity_funcitons
    // Start is called before the first frame update
    void Start()
    {
        salRB = GetComponent<Rigidbody2D>();
        //pc = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        attTimer = 0;
        forward = true;
        objective = (Vector2) transform.position + (direction.normalized * distance);
        Debug.Log((direction.normalized * distance));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }
    #endregion

    #region Movement_funcitons
    private void Move()
    {
        if((objective - (Vector2) transform.position).magnitude < 1)
        {
            if (forward)
            {
                objective = objective - direction.normalized * distance;
                forward = !forward;
            }
            else
            {
                objective = objective + direction.normalized * distance;
                forward = !forward;
            }
        }
        if (forward)
        {
            salRB.velocity = direction.normalized * movespeed;
        }
        else
        {
            salRB.velocity = direction.normalized * movespeed * -1;
        }
      
    }
    #endregion

    #region Attack_functions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")){
            if(attTimer <= 0)
            {
                StartCoroutine(Attack());
            }
        }
    }
    IEnumerator Attack()
    {
        // insert animation here
        //point of contact
        attTimer = 1f;
        yield return new WaitForSeconds(.5f);
        //RaycastHit2D[] hits = Physics2D.BoxCastAll(this.transform.position + direction, )
        yield return new WaitForSeconds(.5f);
        attTimer = 0;
        //transform.GetComponent<PlayerController>()
        //finish animation

    }

    #endregion
}

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
    private Transform pc;
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
        pc = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        attTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if((pc.position - this.transform.position).magnitude < 2)
        {
            Attack();
        }
    }
    #endregion

    #region Movement_funcitons
    private void Move()
    {
        Vector3 distance = pc.position - this.transform.position;
        salRB.velocity = distance.normalized * movespeed;
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
        pc.transform.GetComponent<PlayerController>().take_dmg(dmg);
        yield return new WaitForSeconds(.5f);
        attTimer = 0;
        //transform.GetComponent<PlayerController>()
        //finish animation

    }

    #endregion
}

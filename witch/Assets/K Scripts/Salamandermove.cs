using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salamandermove : MonoBehaviour
{
    #region Health_vars
    [SerializeField]
    [Tooltip("Changes what the starting health for salamnder will be ")]
    private float maxhealth;
    private float curhealth;
    #endregion

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
    private float dmg;
    [SerializeField]
    [Tooltip("Amount of time between attacks")]
    private float attTimer;
    #endregion


    #region Unity_funcitons
    // Start is called before the first frame update
    void Start()
    {
        curhealth = maxhealth;
        salRB = GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerController>().GetComponent<Transform>();
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

    #region Health_functions
    public void TakeDamage(float d)
    {
        curhealth -= d;
        if(curhealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Attack_functions
    private void Attack()
    {
        // insert animation here
        //point of contact
        //transform.GetComponent<PlayerController>()
        //finish animation

    }

    #endregion
}

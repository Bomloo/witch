using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKid : MonoBehaviour
{
    #region Movement_vars
    private Transform pc;
    private Rigidbody2D SKRB;
    [SerializeField]
    private float movespeed;
    #endregion

    #region Damage_vars
    [SerializeField]
    private float damage;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        SKRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    #region Movement_funcs
    public void setPlayer(Transform player)
    {
        pc = player;
    }

    private void Move()
    {
        if (pc != null)
        {
            Vector3 distance = pc.position - this.transform.position;
            SKRB.velocity = distance.normalized * movespeed;
        }

    
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Health_funcs
    [SerializeField]
    [Tooltip("Changes what the starting health for an enemy will be ")]

    private float maxHP;
    private float curHP;
    public GameObject heart;
    public Rigidbody2D rb;
    public Transform player;
    //private bool spawned = false;
    private int count = 0;
    private float knock_force = 1f;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }


    public void TakeDamage(float i, bool hitdrop = false, bool deathdrop = false,  bool knockback = false, Vector3 force = new Vector3(), bool reflect = false)
    {
        Debug.Log("took damage");
        curHP -= i;
        if (reflect)
        {
            //Debug.Log("r");
            if (curHP <= 0)
            {
                if (deathdrop)
                {
                    Instantiate(heart, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }

        if (knockback)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(-transform.up * knock_force);
        }

        else
        {
            //Debug.Log("s");
            if (curHP <= 0)
            {
                if (deathdrop)
                {
                    Instantiate(heart, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }

            if (hitdrop)
            {
                count++;

                if (count == 3)
                {
                    Vector3 spawn_pos = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * 3;
                    //while (spawned == false)
                    //{
                    //    if (!Physics2D.OverlapCircle(spawn_pos, 0.7f))
                    //    {
                    //        Instantiate(heart, spawn_pos, Quaternion.identity);
                    //        spawned = true;
                    //    }
                    //}
                    if (!Physics2D.OverlapCircle(spawn_pos, 0.7f))
                    {
                        Instantiate(heart, spawn_pos, Quaternion.identity);
                    }
                    //spawned = false;
                    count = 0;
                }
            }

            else
            {
                count = 0;
            }
        }
        //Debug.Log(count);
    }

    //private IEnumerator knock()
    //{

    //} 
}

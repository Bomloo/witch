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
    public Movement movement;
    public Transform player;
    //private bool spawned = false;
    private int count = 0;
    private float knock_force = 20f;
    private float knock_timer = 0.15f;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        movement = this.GetComponent<Movement>();
    }


    public void TakeDamage(float i, bool hitdrop = false, bool deathdrop = false,  bool knockback = false, bool reflect = false)
    {
        //Debug.Log("took damage");
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
            movement.knock = true;
            Vector2 direction = (transform.position - player.transform.position).normalized;
            rb.AddForce(direction * knock_force, ForceMode2D.Impulse);
            StartCoroutine(reset());
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

    private IEnumerator reset()
    {
        float start = 0f;
        while (start <= knock_timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
        rb.velocity = Vector3.zero;

        movement.knock = false;
    }
}

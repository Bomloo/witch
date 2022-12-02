using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralMovement : MonoBehaviour
{
    #region Smart_vars
    public NavMeshAgent Agent;

    [SerializeField]
    private PlayerController pc;
    private float timer;
    #endregion

    #region Dumb_vars
    public Rigidbody2D rb;
    public Transform player;
    public Transform shootpt;
    public LayerMask inquire;
    public Vector2 coord;
    public float run_speed = 2f;
    public int range = 10;

    public bool seeing = false;
    public bool rest_state = false;
    public bool moving = false;
    public bool touch = false;
    #endregion

    public bool smart = false;
    public bool dumb = true;

    // Start is called before the first frame update
    private void Start()
    {
        if (smart)
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.updateRotation = false;
            Agent.updateUpAxis = false;
        }
    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (smart)
        {
            bool move = true;
            if ((pc.transform.position - this.transform.position).magnitude <= 1)
            {
                move = false;
            }

            if (timer <= 0 && move)
            {
                Findandmovetwoardsplayer();
                timer = 1;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (dumb)
        {
            RaycastHit2D hit = Physics2D.Raycast(shootpt.position, shootpt.up, range, inquire);
            if (hit.transform == null || hit.transform.CompareTag("Player") == false || touch)
            {
                coord = new Vector2(0, 0);
                seeing = false;
                //Debug.Log("blind");
            }
            else
            {
                coord = player.position - transform.position;
                coord = coord.normalized;
                seeing = true;
                //Debug.Log("spot");
            }
        }
    }

    private void FixedUpdate()
    {
        if (dumb)
        {
            rb.velocity = new Vector2(coord.x * run_speed, coord.y * run_speed);
        }

    }

    public virtual void Findandmovetwoardsplayer()
    {
        //Debug.Log(Agent);
        Agent.SetDestination(pc.transform.position);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            touch = true;
        }
        else
        {
            touch = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof( NavMeshAgent))]
public class SmartMovement : MonoBehaviour
{
    #region Movement_vars
    public NavMeshAgent Agent;

    [SerializeField]
    private PlayerController pc;
    private float timer;
    #endregion

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        bool move = true;
        if( (pc.transform.position - this.transform.position).magnitude <= 1)
        {
            move = false;
        }

        if(timer <= 0 && move)
        {
            Findandmovetwoardsplayer();
            timer = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void Findandmovetwoardsplayer()
    {
        Debug.Log(Agent);
        Agent.SetDestination(pc.transform.position);
    }
}

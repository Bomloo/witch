using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKid : MonoBehaviour
{
    #region Movement_vars
    [SerializeField]
    private Transform pc;
    private SmartMovement move;
    #endregion

    #region Damage_vars
    [SerializeField]
    private float damage;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<SmartMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Movement_funcs
    public void setPlayer(Transform player)
    {
        pc = player;
        move = GetComponent<SmartMovement>();
        move.setPlayer(player);
    }

    
    #endregion
}

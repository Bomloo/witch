using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    #region Name_Vars
    public string suit;
    public int number;
    public bool used;
    #endregion

    public bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Name_funcs
    //universal so we can set the suit and number and acess them later
    public void SetSuitandNumber(string s, int n)
    {
        suit = s;
        number = n;
    }

    #endregion

    #region Card_Funcs
    //will be overided
    public virtual void Active(PlayerController play) { }


    //will be overided
    public virtual void StartPassive(PlayerController play) { }
    #endregion

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {

        }
    }
}

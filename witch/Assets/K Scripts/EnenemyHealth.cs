using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenemyHealth : MonoBehaviour
{
    #region Health_funcs
    [SerializeField]
    [Tooltip("Changes what the starting health for an enemy will be ")]

    private float maxHP;
    private float curHP;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }


    public void TakeDamage(float i)
    {
        curHP -= i;
        if(curHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

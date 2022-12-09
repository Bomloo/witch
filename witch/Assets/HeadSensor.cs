using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSensor : MonoBehaviour
{
    [SerializeField]
    private Salamandermove sm;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            sm.StartBiteAttack();
        }
    }
}

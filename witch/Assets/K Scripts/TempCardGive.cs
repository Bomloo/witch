using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCardGive : MonoBehaviour
{
    public CardManager cm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            cm.DrawCardPlayer();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

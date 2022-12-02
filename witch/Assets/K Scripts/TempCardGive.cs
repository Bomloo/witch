using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCardGive : MonoBehaviour
{
    public CardManager cm;
    [SerializeField]
    private SceneLoader sc;
    [SerializeField]
    private int scene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            cm.DrawCardPlayer();
        }
        if(scene == 1)
        {
            sc.levelone();
        }
        else if( scene ==2)
        {
            sc.LevelTwo();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTest : MonoBehaviour
{
    [SerializeField]
    private ChoseUICard[] CardChoices;
    [SerializeField]
    private Canvas Cards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Fire2") >0){
            if(Time.timeScale > 0)
            {
                Time.timeScale = 0;
                Cards.gameObject.SetActive(true);
                for (int i = 0; i < 3; i++)
                {
                    CardChoices[i].DrawCard();
                }
               
            }
           
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseUICard : MonoBehaviour
{

    private Card held_card;
    private Image suit_color;
    //private CardManager CM;
    // Start is called before the first frame update
    void Start()
    {
        suit_color = GetComponent<Image>();
        //CM = FindObjectOfType<CardManager>();
        //Debug.Log(CM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        //Debug.Log(CM.DrawCardtemp());
        suit_color = GetComponent<Image>();
        CardManager CM = FindObjectOfType<CardManager>();
        
        held_card = CM.DrawCardtemp();
       
        if (held_card.suit == " Heart" || held_card.suit == "Diamond")
        {
            suit_color.color = Color.red;
        }
        else
        {
            suit_color.color = Color.black;
        }
    }

    public void chose_Card()
    {
        Time.timeScale = 1;
        CardManager CM = FindObjectOfType<CardManager>();
        CM.UIKeepCard(held_card);
        //Time.timeScale = 1;
    }
}

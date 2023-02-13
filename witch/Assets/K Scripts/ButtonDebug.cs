using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDebug : MonoBehaviour
{
    [SerializeField]
    private Sprite[] cardImages;
    string Suit;

    public void setSuit(string s)
    {
        Suit = s;
    }


   
    public void Whynowork()
    {
        Debug.Log("Button Pressed");
    }
}

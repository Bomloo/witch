using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOneCard : MonoBehaviour
{

    CardManager cm;
    [SerializeField]
    CardInteractor ci;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CardManager>();
        Card c = cm.DrawCardtemp();
        ci.SetCard(c);
        ci.SetCardManager(cm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

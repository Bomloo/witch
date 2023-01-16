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
        CardInteractor cardi = Instantiate<CardInteractor>(ci);
        cardi.SetCard(c);
        cardi.SetCardManager(cm);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

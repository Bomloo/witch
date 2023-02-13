using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteractor : MonoBehaviour
{
    private Card c;
    private CardManager cm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(Card card)
    {
        c = card;
        Sprite image = GetComponent<Sprite>();
    }

    public void SetCardManager(CardManager cardm) {
        cm = cardm;
    }
        

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().add_hand(c);
        }
        cm.keepCard(c);
        CardInteractor[] interactors = FindObjectsOfType<CardInteractor>();
        foreach(CardInteractor ci in interactors)
        {
            if(ci != this)
            {
                ci.DestoyConnections();
            }
        }
        Destroy(this.gameObject);
    }

    public void DestoyConnections()
    {
        
        Destroy(this.gameObject);
    }

}

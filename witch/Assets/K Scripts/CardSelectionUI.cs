using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectionUI : MonoBehaviour
{
    [SerializeField]
    private CardManager CM;

    [SerializeField]
    private Canvas choices;
    // Start is called before the first frame update
    void Start()
    {
        CM =FindObjectOfType<CardManager>(); 
    }

    public void activateCardsandPause()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

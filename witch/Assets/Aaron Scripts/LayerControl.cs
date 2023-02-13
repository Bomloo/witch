using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerControl : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        sprite.sortingOrder = 2;
        sprite.color = new Color32(57, 77, 22, 180);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = 0;
        sprite.color = new Color32(57, 77, 22, 255);
    }
}

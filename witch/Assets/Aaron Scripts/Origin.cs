using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    public Camera cam;

    Vector2 mousepos;

    // Update is called once per frame
    void Update()
    {
        // get the pointer position
        // get the x and y
        // normalize
        // set origin position to x and y x buffer distance
        // rotate origin position to angle of pointer

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        transform.rotation = Quaternion.Euler(0, 0,  Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg - 90f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play)
    {
        if (number == 8)
        {
            // play.addmaxshield(8);
            //play.addshield(8);
        }
    }
}

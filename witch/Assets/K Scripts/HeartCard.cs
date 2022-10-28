using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play) {
        if(number == 8)
        {
            // play.addmaxhp(+15);
            //play.addhp(+15);
        }
    }
}

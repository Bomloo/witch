using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play) {
        int i = number;
        switch (i)
        {
            case 5:
                play.add_health(+30);
                break;
            case 6:
                play.add_health(+25);
                break;
            case 7:
                play.add_health(+20);
                break;
            case 8:
                play.add_health(+15);
                break;
            case 9:
                play.add_health(+10);
                break;
            case 10:
                play.add_health(+5);
                break;

        }

     
    }
}

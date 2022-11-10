using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCard : Card
{
    public override void Active(PlayerController play)
    {
        int i = number;
        switch (i)
        {
            case 4:
                play.heal(1);
                used = true;
                break;
            case 3:
                play.heal(2);
                used = true;
                break;
            case 2:
                play.heal(3);
                used = true;
                break;
        }
    }

    public override void StartPassive(PlayerController play) {
        int i = number;
        switch (i)
        {
            case 1:
                play.ace_hearts();
                break;
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

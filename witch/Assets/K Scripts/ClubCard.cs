using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play)
    {
        int i = number;
        switch (i)
        {
            case 2:
                play.add_crit_rate(10);
                break;
            case 3:
                play.add_crit_rate(9);
                break;
            case 4:
                play.add_crit_rate(8);
                break;
            case 5:
                play.add_crit_rate(7);
                break;
            case 6:
                play.add_crit_rate(6);
                break;
            case 7:
                play.add_crit_rate(5);
                break;
            case 8:
                play.add_crit_rate(4);
                break;
            case 9:
                play.add_crit_rate(3);
                break;
            case 10:
                play.add_crit_rate(2);
                break;
            case 12:
                play.add_crit_dmg(.2f);
                break;
            case 13:
                play.add_crit_dmg(.3f);
                break;

        }
    }
}

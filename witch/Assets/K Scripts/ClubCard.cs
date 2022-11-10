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
            case 1:
                play.ace_clubs();
                break;
            case 2:
                play.add_crit_rate(.1f);
                break;
            case 3:
                play.add_crit_rate(0.09f);
                break;
            case 4:
                play.add_crit_rate(0.08f);
                break;
            case 5:
                play.add_crit_rate(.07f);
                break;
            case 6:
                play.add_crit_rate(.06f);
                break;
            case 7:
                play.add_crit_rate(.05f);
                break;
            case 8:
                play.add_crit_rate(.04f);
                break;
            case 9:
                play.add_crit_rate(.03f);
                break;
            case 10:
                play.add_crit_rate(.02f);

                break;
            case 11:
                play.jack_clubs();


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

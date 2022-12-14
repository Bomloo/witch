using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play)
    {
        int i = number;
        switch (i)
        {
            case 2:
                play.dec_reload(.6f);
                break;
            case 3:
                play.dec_reload(.4f);
                break;
            case 4:
                play.dec_reload(.2f);
                break;
            case 5:
                play.add_ammo(1);
                break;
            case 6:
                play.add_ammo(1);
                break;
            case 7:
                play.add_ammo(1);
                break;
            case 8:
                play.add_ammo(1);
                break;
            case 9:
                play.add_ammo(1);
                break;
            case 10:
                play.add_ammo(1);
                break;
            case 11:
                play.jack_spades();
                break;
        }
    }
}

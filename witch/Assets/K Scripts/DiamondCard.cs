using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play)
    {
        int i = number;
        switch (i)
        {
            case 2:
                play.add_shields(20);
                break;
            case 3:
                play.add_shields(18);
                break;
            case 4:
                play.add_shields(16);
                break;
            case 5:
                play.add_shields(14);
                break;
            case 6:
                play.add_shields(12);
                break;
            case 7:
                play.add_shields(10);
                break;
            case 8:
                play.add_shields(8);
                break;
            case 9:
                play.add_shields(6);
                break;
            case 10:
                play.add_shields(4);
                break;
            case 13:
                play.add_shields(30);
                break;

        }
    }
}

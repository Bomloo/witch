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
                // play.add_shield(20);
            case 3:
                break;
                // play.add_shield(18);
                break;
            case 4:
                // play.add_shield(16);
                break;
            case 5:
                // play.add_shield(14);
                break;
            case 6:
                // play.add_shield(12);
                break;
            case 7:
                // play.add_shield(10);
                break;
            case 8:
                // play.add_shield(8);
                break;
            case 9:
                // play.add_shield(6);
                break;
            case 10:
                // play.add_shield(4);
                break;
            case 13:
                // play.add_shield(30);
                break;

        }
    }
}

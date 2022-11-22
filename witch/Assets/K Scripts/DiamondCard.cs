using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCard : Card
{
    public override void Active(PlayerController play) {
        play.ace_diamonds();
        used = true;
    }

    public override void StartPassive(PlayerController play)
    {
        int i = number;
        switch (i)
        {
            case 2:
                play.add_shields(20);
                description = "Gives the player 20 shield that renews every room";
                break;
            case 3:
                play.add_shields(18);
                description = "Gives the player 18 shield that renews every room";
                break;
            case 4:
                play.add_shields(16);
                description = "Gives the player 16 shield that renews every room";
                break;
            case 5:
                play.add_shields(14);
                description = "Gives the player 14 shield that renews every room";
                break;
            case 6:
                play.add_shields(12);
                description = "Gives the player 12 shield that renews every room";
                break;
            case 7:
                play.add_shields(10);
                description = "Gives the player 10 shield that renews every room";
                break;
            case 8:
                play.add_shields(8);
                description = "Gives the player 8 shield that renews every room";
                break;
            case 9:
                play.add_shields(6);
                description = "Gives the player 6 shield that renews every room";
                break;
            case 10:
                play.add_shields(4);
                description = "Gives the player 4 shield that renews every room";
                break;
            case 11:
                play.jack_diamonds();
                description = "When enemies hit you you deal 2 damage back automatically";
                break;
            case 12:
                play.queen_diamonds();
                description = "Lower all damage by 2";
                break;
            case 13:
                play.add_shields(30);
                description = "Gives the player 30 shield that renews every room";
                break;

        }
    }

    public override void SetSuitandNumber(string s, int n)
    {
        base.SetSuitandNumber(s, n);
        if(n == 1)
        {
            description = "When used gives the player invunerability for 2 sedonds";
        }
    }
}

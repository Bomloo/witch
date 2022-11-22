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
                description = "allows the player to heal when hitting an enemy";
                break;
            case 5:
                play.add_health(+30);
                description = "Increases the players max health by 30";
                break;
            case 6:
                play.add_health(+25);
                description = "Increases the players max health by 25";
                break;
            case 7:
                play.add_health(+20);
                description = "Increases the players max health by 20";
                break;
            case 8:
                play.add_health(+15);
                description = "Increases the players max health by 15";
                break;
            case 9:
                play.add_health(+10);
                description = "Increases the players max health by 10";
                break;
            case 10:
                play.add_health(+5);
                description = "Increases the players max health by 5";
                break;

        }

     
    }

    public override void SetSuitandNumber(string s, int n)
    {
        base.SetSuitandNumber(s, n);
        int i = n;
        switch (i)
        {
            case 4:
                description = "When used heals the player for a small amount of health";
                break;
            case 3:
                description = "When used heals the player for a medium amount of health";
                break;
            case 2:
                description = "When used heals the player for a large amount of health";
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubCard : Card
{
    public override void Active(PlayerController play) { }

    public override void StartPassive(PlayerController play)
    {
        if (number == 8)
        {
            // play.addcritrate(4);
        }
    }
}

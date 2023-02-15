using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSizeBallBuff : Buffs
{
    protected override void Active(PlayerMover playerMover)
    {       
        foreach (var ball in playerMover.Balls)
        {
            ball.transform.localScale *= 2;
        }
    }
}

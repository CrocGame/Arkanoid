using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedDebuff : Buffs
{
    protected override void Active(PlayerBalls playerBalls)
    {
        while (playerBalls.Balls.Count!=0)
        {
            playerBalls.DestroyBall(playerBalls.Balls[0]);
        }
    }
}

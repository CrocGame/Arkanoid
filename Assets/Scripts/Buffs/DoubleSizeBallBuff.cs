using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSizeBallBuff : Buffs
{
    protected override void Active(PlayerBalls playerBalls)
    {       
        foreach (var ball in playerBalls.Balls)
        {
            float size = ball.transform.localScale.x;
            size++;
            size=Mathf.Clamp(size, 1f, 4f);
            ball.transform.localScale = Vector3.one*size;
        }
    }
}

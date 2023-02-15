using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBallBuff : Buffs
{
    protected override void Active(PlayerMover playerMover)
    {
        List<Ball> balls = new List<Ball>();
        foreach (var ball in playerMover.Balls)
        {
            balls.Add(Instantiate(ball,playerMover.BallContainer));           
        }
        foreach (var ball in balls)
        {
            playerMover.Balls.Add(ball);
        }       
        Destroy(gameObject);
    }
}

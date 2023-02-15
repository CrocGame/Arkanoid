using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBallBuff : Buffs
{
    protected override void Active(PlayerBalls playerBalls)
    {
        List<Ball> balls = new List<Ball>();
        foreach (var ball in playerBalls.Balls)
        {
            var newball = Instantiate(ball, ball.transform.position,Quaternion.identity, playerBalls.BallContainer);
            newball.RunBall();
            balls.Add(newball);           
        }
        foreach (var ball in balls)
        {
            playerBalls.Balls.Add(ball);
        }       
    }
}

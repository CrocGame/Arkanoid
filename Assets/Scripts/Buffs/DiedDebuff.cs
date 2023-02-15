using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedDebuff : Buffs
{
    protected override void Active(PlayerMover playerMover)
    {
        for (int i = 0; i < playerMover.Balls.Count; i++)
        {
            playerMover.DestroyBall(playerMover.Balls[i]);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDebuff : Buffs
{
    protected override void Active(PlayerBalls playerBalls)
    {
        Vector3 size = playerBalls.gameObject.transform.localScale;
        size.x-= 0.3f;
        size.x = Mathf.Clamp(size.x,0.4f,1.6f);
        playerBalls.gameObject.transform.localScale = size;       
    }
}

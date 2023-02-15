using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBuff : Buffs
{
    protected override void Active(PlayerMover playerMover)
    {
        Vector3 size = playerMover.gameObject.transform.localScale;
        size.x += 0.3f;
        size.x = Mathf.Clamp(size.x, 0.4f, 1.6f);
        playerMover.gameObject.transform.localScale = size;
        Destroy(gameObject);
    }

}

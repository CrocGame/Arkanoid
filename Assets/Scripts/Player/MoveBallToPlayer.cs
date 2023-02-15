using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    public Ball Ball;

    private void LateUpdate()
    {
        if (Ball != null)
        Ball.transform.position=transform.position+ _offset;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    public Ball Ball;

    private void LateUpdate()
    {
        Ball.transform.position=transform.position+ _offset;
    }

}

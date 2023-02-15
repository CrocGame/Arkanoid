using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buffs : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public int ValueChance;

    private void FixedUpdate()
    {
        _rigidbody.velocity = -Vector3.forward * 5;
    }

    protected abstract void Active(PlayerBalls playerBalls);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBalls playerBalls))
        {
            Active(playerBalls);
            Destroy(gameObject);
        }             
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _damage;


    private Vector3 lastVelocity;
    private Vector3 currentDirection;


    private void FixedUpdate()
    {
        _rigidbody.velocity = currentDirection;
        lastVelocity = _rigidbody.velocity;
    }

    private void Ricoshet(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        currentDirection = direction * _speed;
        _rigidbody.AddForce(currentDirection * 2);

    }
    public void RunBall()
    {
        currentDirection = Vector3.forward * _speed;
    }
    public void BuffDamage(float buffDamage)
    {

        _damage += buffDamage;

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ricoshet(collision);
        if (collision.gameObject.TryGetComponent(out Blocks blocks))
        {
            blocks.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + currentDirection);
    }
}

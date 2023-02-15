using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _buffDamage;

    [SerializeField] private Joystick joystick;
    private PlayerControl _playerControl;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _playerControl.Enable();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.right * _playerControl.Player.Move.ReadValue<float>() * _speed;
        if(Mathf.Abs(joystick.Horizontal) >0)
        _rigidbody.velocity = Vector3.right * joystick.Horizontal * _speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            ball.BuffDamage(_buffDamage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _buffDamage;
    [SerializeField] private MoveBallToPlayer _moveBallToPlayer;

    private PlayerControl playerControl;

    [SerializeField] private Ball _ball;

    public List<Ball> Balls;
    public Transform BallContainer;


    private void Awake()
    {
        playerControl = new PlayerControl();
        playerControl.Enable();
        playerControl.Player.CreateBall.performed += ctx => CreateBall();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.right * playerControl.Player.Move.ReadValue<float>() * _speed;
    }

    private void CreateBall()
    {

        //foreach (var ball in Balls)
        //{
        //    if (ball != null)
        //        Destroy(ball.gameObject);
        //}
        //Ball newBall = Instantiate(_ball, BallContainer);
        //_moveBallToPlayer.Ball = newBall;
        //_moveBallToPlayer.enabled = true;
        //Balls = new List<Ball>
        //{
        //    newBall
        //};


        _moveBallToPlayer.enabled = false;
        Balls[0].RunBall();
    }

    public void DestroyBall(Ball ball)
    {       
        Balls.Remove(ball);
        ball.Destroy();
        CheckBall();
    }
    public void CheckBall()
    {
        bool GameEnd = true;
        foreach (var ball in Balls)
        {
            if (ball != null)
            {
                GameEnd = false;
            }
        }
        if (GameEnd)
        {
            Debug.Log("Fall");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            ball.BuffDamage(_buffDamage);
        }
    }
}

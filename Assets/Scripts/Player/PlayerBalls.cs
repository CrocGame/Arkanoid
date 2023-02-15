using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBalls : MonoBehaviour
{
    [SerializeField] private MoveBallToPlayer _moveBallToPlayer;
    [SerializeField] private Ball _ball;

    public List<Ball> Balls;
    public Transform BallContainer;

    public UnityAction BallsEmpty;

    public void CreateBall()
    {
        Ball newBall = Instantiate(_ball, BallContainer);
        _moveBallToPlayer.Ball = newBall;
        _moveBallToPlayer.enabled = true;
        Balls = new List<Ball>
        {
            newBall
        };
    }
    public void StartBall()
    {
        if (_moveBallToPlayer.enabled==true)
        {
            _moveBallToPlayer.enabled = false;
            Balls[0].RunBall();
        }
        
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
            BallsEmpty?.Invoke();
        }
    }

}

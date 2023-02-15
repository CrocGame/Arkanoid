using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _livePoint;
    public int LivePoint => _livePoint;

    [SerializeField] public PlayerBalls PlayerBalls;
    [SerializeField] public PlayerMover PlayerMover;

    private PlayerControl playerControl;

    public UnityAction SpentLivePoint;
    private void Awake()
    {
        playerControl = new PlayerControl();
        playerControl.Enable();
    }
    private void OnEnable()
    {
        playerControl.Player.CreateBall.performed += ctx => StartBall();
        PlayerBalls.BallsEmpty += ReduceLivePoint;
    }
    private void OnDisable()
    {
        playerControl.Player.CreateBall.performed -= ctx => StartBall();
        PlayerBalls.BallsEmpty -= ReduceLivePoint;
    }

    private void StartBall()
    {
        PlayerBalls.StartBall();
    }
    private void ReduceLivePoint()
    {
        _livePoint--;
        SpentLivePoint?.Invoke();
        if (_livePoint<=0)
        {
            GameOver();
            //PlayerBalls.CreateBall();
        }
        else
        {
            PlayerBalls.CreateBall();
        }
    }

    private void GameOver()
    {
        playerControl.Disable();
        Debug.Log("Game OVer");
    }

}

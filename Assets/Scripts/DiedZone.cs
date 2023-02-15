using UnityEngine;

public class DiedZone : MonoBehaviour
{
    [SerializeField] private PlayerBalls _playerBalls;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            _playerBalls.DestroyBall(ball);
        }
        if(collision.gameObject.TryGetComponent(out Buffs buff))
        {
            Destroy(buff.gameObject);
        }
    }
}

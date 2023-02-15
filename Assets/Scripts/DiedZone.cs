using UnityEngine;

public class DiedZone : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {           
            _playerMover.DestroyBall(ball);
            Destroy(gameObject);
        }
    }
}

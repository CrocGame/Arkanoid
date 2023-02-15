using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buffs : MonoBehaviour
{
    [SerializeField] private int _valueChance;


    private void Update()
    {
        transform.position -= Vector3.forward * 5 * Time.deltaTime;
    }

    protected abstract void Active(PlayerMover playerMover);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMover playerMover))
        {
            Active(playerMover);
            
        }
    }

}

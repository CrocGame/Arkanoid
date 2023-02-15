using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health-=damage;
        if (_health<=0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);    
    }
}

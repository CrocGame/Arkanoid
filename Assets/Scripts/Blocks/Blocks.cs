using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Blocks : MonoBehaviour
{
    [SerializeField] private float _health;
    public GameObject CanvasDamage;
    [SerializeField] private GameObject _textDamage;

    public UnityAction<Blocks> OnDestroy;

    public void TakeDamage(float damage)
    {
        _health-=damage;
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        GameObject textPoint =Instantiate(_textDamage, position,Quaternion.identity,CanvasDamage.transform);  
        var text = textPoint.GetComponentInChildren<TMP_Text>();
        text.text = (Mathf.Floor(damage*10)/10).ToString();

        if (_health<=0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        OnDestroy?.Invoke(this);
        Destroy(gameObject);    
    }
}

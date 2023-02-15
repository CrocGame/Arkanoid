using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisualDamage : MonoBehaviour
{
    [SerializeField] private GameObject _textDamage;


    public void CreateText(int damage)
    {
        var textDamage = Instantiate(_textDamage, transform);
        var text = textDamage.GetComponent<TMP_Text>();
        text.text = damage.ToString();
    }
}

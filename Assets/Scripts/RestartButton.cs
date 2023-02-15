using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;


    private void Start()
    {
        UpdateText();
        
    }
    private void OnEnable()
    {
        _player.SpentLivePoint += UpdateText;
    }
    private void OnDisable()
    {
        _player.SpentLivePoint -= UpdateText;
    }
    private void UpdateText()
    {
        if (_player.LivePoint > 0)
        {
            _text.text = "Live: " + _player.LivePoint;
        }
        else
        {
            _text.text = "Restart";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

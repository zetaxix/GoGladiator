using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    [SerializeField] Button _restartButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        });
    }

    private void OnEnable()
    {
        EventManager.onPlayerDied += OnPlayerDiedUI;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDied -= OnPlayerDiedUI;

    }

    private void OnPlayerDiedUI()
    {
        if (!_restartButton.gameObject.activeSelf) 
        {
            _restartButton?.gameObject.SetActive(true);
        }
    }
}

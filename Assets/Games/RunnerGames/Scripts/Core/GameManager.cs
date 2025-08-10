using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] CoinUI coinUI;
    [SerializeField] PlayerController player;
    private int coinCount;

    private bool _gameOver = false;
    public bool GameOver => _gameOver;

    [Header("Sound System")]
    [SerializeField] AudioSource stabbingSound;
    [SerializeField] AudioSource playerDeath;
    [SerializeField] AudioSource tigerEath;
    [SerializeField] AudioSource coinCollected;

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    private void HandlePlayerDied()
    {
        _gameOver = true;

        stabbingSound.Play();
        playerDeath.Play();
        tigerEath.Play();

        coinUI.SaveLastHighScore();

        Animator tigerAnimator = player.transform.Find("Tiger").GetComponent<Animator>();
        if (tigerAnimator != null) 
        {
            tigerAnimator.SetTrigger("EatTrigger");
        }

        Transform gladiator = player.transform.Find("Gladiator").GetComponent<Transform>();
        if (gladiator != null) 
        {
            gladiator.position = new Vector3(gladiator.position.x, gladiator.position.y + -0.20f, gladiator.position.z);
        }
    }

    private void HandleCoinCollected()
    {
        coinCollected.Play();

        coinCount++;
        Debug.Log($"Coin Deðeri Arttý! : {coinCount}");
    }

    private void OnEnable()
    {
        EventManager.onPlayerCollected += HandleCoinCollected;
        EventManager.onPlayerDied += HandlePlayerDied;
    }

    private void OnDisable()
    {
        EventManager.onPlayerCollected -= HandleCoinCollected;
        EventManager.onPlayerDied -= HandlePlayerDied;
    }
}

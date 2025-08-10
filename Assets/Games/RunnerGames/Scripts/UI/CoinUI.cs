using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _HighscoreText;

    private float scoreCount;
    public bool GameStart;

    private void Start()
    {
        _HighscoreText.gameObject.SetActive(true);
    }

    private void Update()
    {
        ShowHighScore();

        if (GameManager.Instance.GameOver) { return; }

        if (GameStart) 
        {
            scoreCount += Time.deltaTime;
            UpdateScore((int)scoreCount);
        }

    }

    public void GameStartScore()
    {
        GameStart = true;
    }

    public void ShowHighScore()
    {
        int lastHighScore = PlayerPrefs.GetInt("HighScore");
        _HighscoreText.text = lastHighScore.ToString();
    }

    public void UpdateScore(int currentScore)
    {
        _scoreText.text = currentScore.ToString();
    }

    public void SaveLastHighScore()
    {
        int lastScore = PlayerPrefs.GetInt("HighScore");
        if (scoreCount > lastScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)scoreCount);
        }
    }
}

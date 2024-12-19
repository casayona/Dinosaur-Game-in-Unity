using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameSpeed;
    public float gameIncreaseSpeed;

    public Dinosaur dinosaur;
    public SpawnManager _spawnManager;

    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;


    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public float score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        GameSpeed();
    }

    private void Update()
    {
        gameSpeed += gameIncreaseSpeed * Time.deltaTime;

        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void GameSpeed()
    {
        GameObject[] obstacleObjects = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject obstacleObject in obstacleObjects)
        {
            Destroy(obstacleObject.gameObject);
        }
        score = 0f;
        enabled = true;
        UpdateHighScore();

        dinosaur.gameObject.SetActive(true);
        _spawnManager.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameSpeed = 5f;

        if (dinosaur != null)
            dinosaur.gameObject.SetActive(false);

        if (_spawnManager != null)
            _spawnManager.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        enabled = false;

        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("highscore", 0);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highscore", highScore);
        }
        highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }
}



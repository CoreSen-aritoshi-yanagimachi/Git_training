using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool paused;

    public TextMeshProUGUI gameOverText;

    private GameObject player;
    public bool gameOver;

    public Button restartButton;

    public GameObject obstaclePrefab;
    public float spawnRate = 1f;
    public float spawnRange = 10.0f;

    public int score;
    public TextMeshProUGUI scoreText;

    public int obstacleCountInt;
    public TextMeshProUGUI obstacleRemainderText;

    public float timeRemainderFloat;
    public TextMeshProUGUI timeRemainderText;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnObstacle());

        UpdateScore(0);
        timeRemainderFloat = 20;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }

        if (!player)
        {
            GameOver();
        }

        obstacleCountInt = FindObjectsOfType<Obstacle>().Length;
        obstacleRemainderText.text = "Obstacle: " + obstacleCountInt;

        timeRemainderFloat -= Time.deltaTime;
        timeRemainderText.text = "Time: " + Mathf.Round(timeRemainderFloat);
        if (timeRemainderFloat < 0)
        {
            GameOver();
        }

    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //public void UpdateObstacleCountInt(int obstacleRemainder)
    //{
    //    obstacleCountInt = obstacleRemainder;
        
    //}

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(obstaclePrefab, GenerateSpawnPosition(), obstaclePrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(10, 20);
        float spawnPosZ = Random.Range(10, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}

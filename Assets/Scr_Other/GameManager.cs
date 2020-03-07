using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Control")]
    public bool waveEnabled;

    [Header("Wave Inputs")]
    public int wave = 1;
    public int initWaveEnemyNum = 5;
    public float spawnDelay = 1;
    public int initSpawnDelay = 1;
    public float waveDelay = 3;

    [Header("Wave Stats")]
    [ShowOnly] int waveEnemyNum;

    [Header("Object Refs")]
    public GameObject[] enemies;
    public Transform[] enemySpawnLocs;
    public GameObject killBox;      // For destroying all enemies on gameover lol

    [Header("UI Refs")]
    public GameObject scoreText;
    public GameObject retryButton;
    public GameObject finalScoreText;

    float nextWaveTimer;

    void Awake()
    {
        waveEnemyNum = initWaveEnemyNum;

        if (!waveEnabled) return;
        StartCoroutine("WaveSpawn");
    }

    public void GameOver()
    {
        StopAllCoroutines();
        Instantiate(killBox, gameObject.transform.position, Quaternion.identity);

        scoreText.SetActive(false);
        retryButton.SetActive(true);
        finalScoreText.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(initSpawnDelay);

        while(true)
        {
            for (int i = 0; i < waveEnemyNum; i++)
            {
                Instantiate(enemies[0], enemySpawnLocs[0].position, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
            
            yield return new WaitForSeconds(waveDelay);
        }
    }
}
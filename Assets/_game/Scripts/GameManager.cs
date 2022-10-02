using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Default Generator Values")]
    public float timeDelay = 10.0f;
    public string seed = "69420";
    public float smothingRNG = 0.1f;

    [Header("Default Difficulty Values")]
    public float difficulty = 1.0f;
    public float difficultyAdd = 0.1f;

    [Header("Default Enemy Values")]
    public float enemySpawnDelay = 2.5f;
    public float enemySpawnDelayMax = 5.0f;
    public float enemySpawnDelayMin = 0.5f;
    public float enemySpawn = 10f;

    private float startingEnemies;
    private GameSpawner gameSpawner;

    // Start is called before the first frame update
    void Start()
    {
        startingEnemies = enemySpawn;
        gameSpawner = GetComponent<GameSpawner>();
        Random.InitState(seed.GetHashCode());
        StartCoroutine(MainLoop());
        StartCoroutine(SpawnLoop());
    }

    IEnumerator MainLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeDelay);

            //TODO weapon change
            UpdateWorld();
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            //TODO spawn enemies with difficulty curve
            yield return new WaitForSeconds(enemySpawnDelay);

            gameSpawner.SpawnEnemies(enemySpawn, difficulty);
        }
    }

    private void UpdateWorld()
    {
        difficulty += difficultyAdd * Random.Range(0f, 1f);
        print(difficulty);

        enemySpawnDelay = Random.Range(enemySpawnDelayMin, enemySpawnDelayMax);
        print(enemySpawnDelay);

        enemySpawnDelayMin -= (difficulty-1) * Random.Range(0f, 1f) * smothingRNG;
        enemySpawnDelayMin = Mathf.Clamp(enemySpawnDelayMin, 0.01f, enemySpawnDelayMax);
        enemySpawnDelayMax -= (difficulty-1) * Random.Range(0f, 1f) * smothingRNG;
        enemySpawnDelayMax = Mathf.Clamp(enemySpawnDelayMax, 0.01f, enemySpawnDelayMax);

        print(enemySpawnDelayMin + ":" + enemySpawnDelayMax);

        enemySpawn += startingEnemies * difficulty;

        print(enemySpawn);
    }
}

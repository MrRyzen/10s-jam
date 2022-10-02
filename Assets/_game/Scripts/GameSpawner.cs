using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [Header("Default Spawner Values")]
    public List<Transform> spawnPoints = new();

    //public Enemies<>
    // Start is called before the first frame update

    public void SpawnEnemies(float amount, float difficulty)
    {
        print(amount);
        print(difficulty);
    }
}

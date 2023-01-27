using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int waveCount;

    [Header("Wave Shop")]
    [Space(20)]
    public int waveMoney;
    public List<EnemySpawnShop> enemies = new List<EnemySpawnShop>();
    private List<GameObject> enemiesToSpawn = new List<GameObject>();


    [Header("- Spawn Control")]
    [Space(20)]
    public Transform spawnPosition;
    [Header("Spawn Enemies")]
    public bool canSpawn;
    public float spawnInterval;
    private float spawnTimer;



    void Start()
    {
    }

    void FixedUpdate()
    {
        SpawnEnemies();
    }

    public void StartSpawner()
    {
        waveCount = 0;
        spawnTimer = 0;
        spawnInterval = 0.3f;

    }

    public void PrepareNextRoundSpawner()
    {
        //Stop Spawner
        canSpawn = false;

        //Level Up WaveCount
        waveCount++;

        //Store the Money
        waveMoney = PayWaveShop();
        GenerateEnemiesToSpawn();
    }

    public void GenerateEnemiesToSpawn()
    {
        // list of enemies to generate
        List<GameObject> generatedEnemies = new List<GameObject>();

        int enemiesBought = 0;

        while (waveMoney > 0)
        {

            //choose a random enemy and grab the cost
            int randomEnemyIndex = Random.Range(0, enemies.Count);
            int enemyCost = enemies[randomEnemyIndex].cost;

            if (waveMoney - enemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyIndex].enemyPrefab);

                enemiesBought++;
                waveMoney -= enemyCost;
            }
            else if (waveMoney <= 0)
            {
                break;
            }

        }
        
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;


        Debug.LogWarning("Inimigos Prontos para Spawn");
    }

    public int PayWaveShop()
    {
        return waveCount * 10;
    }

    public int RoundLevel()
    {
        return waveCount;
    }

    public void SpawnEnemies()
    {
        if (canSpawn)
        {
            //timer over
            if (spawnTimer <= 0)
            {
                //Have enemies to Spawn
                if (enemiesToSpawn.Count > 0)
                {
                    Instantiate(enemiesToSpawn[0], transform.position, Quaternion.identity);
                    Debug.Log("Start Spawning");
                    enemiesToSpawn.RemoveAt(0);
                    spawnTimer = spawnInterval;
                }
                else
                {
                    canSpawn = false;
                }
            }
            // count time
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
            }
        }
    }

}

[System.Serializable]
public class EnemySpawnShop
{
    public GameObject enemyPrefab;
    public int cost;
}

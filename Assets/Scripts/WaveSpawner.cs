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
    [Header("Wave Control")]
    public int waveDuration;
    public float waveTimer;
    [Header("Spawn Enemies")]
    public float spawnInterval;
    public float spawnTimer;



    void Start()
    {
        waveCount = 0;
        GenerateWave();
    }

    void FixedUpdate()
    {
        //timer over
        if (spawnTimer <= 0)
        {
            //Spawn enemy
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], transform.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
        }
        // count time
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveMoney = PayWaveShop();
        GenerateEnemies();
    }

    public void GenerateEnemies()
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

                Debug.Log("Comprei " + generatedEnemies[enemiesBought].name);
                enemiesBought++;
                waveMoney -= enemyCost;
            }
            else if (waveMoney <= 0)
            {
                Debug.Log("Parei de comprar");
                break;
            }

        }
        
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    public int PayWaveShop()
    {
        waveCount++;
        return waveCount * 10;
    }
}

[System.Serializable]
public class EnemySpawnShop
{
    public GameObject enemyPrefab;
    public int cost;
}

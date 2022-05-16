using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //in the future make it a array for different enemies
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 3f;
    private float countdown = 5f;

    public int waveIndex = 0;
    public static int AliveCounter = 0;


    void Update()
    {
       /* TODO - first need to be implemented in all stages, before calling it here
       if(AliveCounter > 0 )
        {
            return;
        }*/

       if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;

        }

        //reduce countdown by 1 every second
        countdown -= Time.deltaTime;

    }
    
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        AliveCounter++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    //in the future make it a array for different enemies
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 10f;

    public int waveIndex = 0;
    public static int AliveCounter = 0;
    
    

    public Text waveCounterText;
    public Text waveCountdownText;


    void Update()
    {
       /* TODO - first need to be implemented in all stages, before calling it here
       if(AliveCounter > 0 )
        {
            return;
        }*/

       if (countdown <= 0f)
        {
            //Makes the SpawnWave timing is independent to the main time for the script 
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;

        }

        //reduce countdown by 1 every second
        countdown -= Time.deltaTime;
        //Mathf cut the dezimals
        waveCountdownText.text = "Next Wave: " + Mathf.Floor(countdown).ToString();

    }
    
    //must be a Inumerator to can be called as a subroutine
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        waveCounterText.text = "Wave: " + (waveIndex + 1).ToString();

        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            //Time between the different Enemies
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

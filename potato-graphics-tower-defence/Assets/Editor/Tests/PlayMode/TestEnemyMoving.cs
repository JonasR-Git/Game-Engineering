using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools.Utils;
using System;
using UnityEditor;

public class TestEnemyMoving
{
    private int timeTillFirstWave = 8;


    [UnityTest]
    public IEnumerator EnemySpawnsInFirstWave()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();


        Assert.IsNotNull(enemy, "SpawnTest failed. No enemy is spawned after " + timeTillFirstWave + " seconds");
    }

    [UnityTest]
    public IEnumerator EnemyMovesAfterGameStarts()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        Vector3 position = enemy.transform.position;

        yield return new WaitForSeconds(0.2f);

        Vector3 newPosition = enemy.transform.position;

        Assert.AreNotEqual(newPosition, position, "MoveTest failed. Enemy position ist " + position + " and " + newPosition);
    }


    [UnityTest]
    public IEnumerator EnemyChangesDirection()
    {
        SceneManager.LoadScene("musterscene");

        var comparer = new Vector3EqualityComparer(0.05f);

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();
       
        Vector3 position1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 position2 = enemy.transform.position;


        yield return new WaitForSeconds(2f);


        Vector3 newPosition1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 newPosition2 = enemy.transform.position;

        

        Assert.That((position2 - position1) , Is.Not.EqualTo(newPosition2 - newPosition1).Using(comparer), "MoveTest failed. Enemy changed doen't changed his moving direction: " + (position2 - position1) + " after: " + (newPosition2 - newPosition1));
    }

    [UnityTest]
    public IEnumerator EnemyGettingSlowed()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        var enemyStartSpeed = enemy.speed;

        enemy.Slow(0.5f);

        //Wait a second so you can check it visual
        yield return new WaitForSecondsRealtime(1);

        var enemySpeedSlow = enemy.speed;
        var expectedSpeedSlow = enemyStartSpeed * 0.5f;


        Assert.AreEqual(enemySpeedSlow, expectedSpeedSlow /*, "SlowTest failed.Enemy has the speed of " + gameObject.GetComponent<Enemy>().speed + " instead of " + gameObject.GetComponent<Enemy>().startSpeed * (1f - 0.1f) */);

    }

    [UnityTest]
    public IEnumerator EnemyGettingFaster()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        var enemyStartSpeed = enemy.speed;

        enemy.Fast(0.5f);

        //Wait a second so you can check it visual
        yield return new WaitForSecondsRealtime(1); 

        var enemySpeedSlow = enemy.speed;
        var expectedSpeedSlow = enemyStartSpeed * 1.5f;


        Assert.AreEqual(enemySpeedSlow, expectedSpeedSlow /*, "SlowTest failed.Enemy has the speed of " + gameObject.GetComponent<Enemy>().speed + " instead of " + gameObject.GetComponent<Enemy>().startSpeed * (1f - 0.1f) */);

    }

    [UnityTest]
    public IEnumerator EnemyGettingNormalSpeed()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        var enemyStartSpeed = enemy.speed;

        enemy.Slow(0.5f);
        enemy.normalSpeed();

        var enemySpeedSlow = enemy.speed;
        var expectedSpeedSlow = enemyStartSpeed;


        Assert.AreEqual(enemySpeedSlow, expectedSpeedSlow /*, "SlowTest failed.Enemy has the speed of " + gameObject.GetComponent<Enemy>().speed + " instead of " + gameObject.GetComponent<Enemy>().startSpeed * (1f - 0.1f) */);

    }
}

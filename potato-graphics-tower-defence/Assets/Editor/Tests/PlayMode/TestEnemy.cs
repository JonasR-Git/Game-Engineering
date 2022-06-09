using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools.Utils;
using System;
using UnityEditor;

public class TestEnemy
{

    //These are tests for the combined enemy from EnemyMovement and Enemy


    private int timeTillFirstWave = 1;


   
    [UnityTest]
    public IEnumerator EnemyTakeDamageAliveAfter()
    {
        SceneManager.LoadScene("Testscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        enemy.TakeDamage(enemy.getHealth() * 0.5f);

        var currentHealth = enemy.getHealth();
        var expectedHealth = enemy.getStartHealth() * 0.5f;

        //yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual(currentHealth, expectedHealth, "TakeDamageTest failed, Enemy has " + currentHealth + "instead of " + expectedHealth);
    }

    [UnityTest]
    public IEnumerator EnemyTakeDamageDeadAfter()
    {
        SceneManager.LoadScene("Testscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        enemy.TakeDamage(enemy.getHealth() + 1f);



        Assert.IsNotNull(enemy);
    }

    [UnityTest]
    public IEnumerator TestIncreaseMoneyUponEnemyKilledIncreasedBounty()
    {
        SceneManager.LoadScene("BountyTestScene");
        yield return new WaitForSecondsRealtime(timeTillFirstWave);
        var enemy = GameObject.FindObjectOfType<Enemy>();
        var player = enemy.getPlayer();
        var startmoney = player.getMoney();
        enemy.Died();
        yield return new WaitForSecondsRealtime(11);
        enemy = GameObject.FindObjectOfType<Enemy>();
        enemy.Died();

        Assert.AreEqual(startmoney + 30, player.getMoney());
    }
}
